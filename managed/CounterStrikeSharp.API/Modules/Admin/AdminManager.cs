﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Commands;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace CounterStrikeSharp.API.Modules.Admin
{
    public partial class AdminData
    {
        [JsonPropertyName("auth_type")] public string AuthType { get; set; }
        [JsonPropertyName("identity")] public string Identity { get; set; }
        [JsonPropertyName("flags")] public List<string> Flags { get; set; }
    }

    public static class AdminManager
    {
        private static Dictionary<string, AdminData> _admins = new Dictionary<string, AdminData>();

        static AdminManager()
        {
            CommandUtils.AddStandaloneCommand("css_admins_reload", "Reloads the admin file.", ReloadAdminsCommand, false);
        }

        [PermissionHelper("can_reload_admins")]
        private static void ReloadAdminsCommand(CCSPlayerController? player, CommandInfo command)
        {
            _admins.Clear();
            var rootDir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent;
            Load(Path.Combine(rootDir.FullName, "configs", "admins.json"));
        }

        public static void Load(string adminDataPath)
        {
            try
            {
                _admins = JsonSerializer.Deserialize<Dictionary<string, AdminData>>(File.ReadAllText(adminDataPath));

                Console.WriteLine($"Loaded admin data with {_admins.Count} admins.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load admin data: {ex.ToString()}");
            }
        }

        /// <summary>
        /// Grabs the admin data for a player that was loaded from "configs/admins.json".
        /// </summary>
        /// <param name="steamid">SteamID object of the player.</param>
        /// <returns>AdminData class if data found, null if not.</returns>
        public static AdminData? GetPlayerAdminData(SteamID steamid)
        {
            foreach (var admin in _admins)
            {
                Console.WriteLine($"{admin.Value.AuthType}, {admin.Value.Identity}");
                var authType = admin.Value.AuthType;

                var steamidFromFile = (authType == "steamid64") ? new SteamID(ulong.Parse(admin.Value.Identity)) : new SteamID(admin.Value.Identity);
                switch (authType)
                {
                    case "steamid64": if (steamidFromFile.SteamId64 == steamid.SteamId64) return admin.Value; break;
                    case "steamid3": if (steamidFromFile.SteamId3 == steamid.SteamId3) return admin.Value; break;
                    case "steamid2": if (steamidFromFile.SteamId2 == steamid.SteamId2) return admin.Value; break;
                    default: return null;
                }
            }

            // For players who have no admin data, we just return null.
            return null;
        }

        /// <summary>
        /// Grabs the admin data for a player that was loaded from "configs/admins.json".
        /// </summary>
        /// <param name="adminName">Name of the admin. This value is set by the key of the AdminData object in the JSON file.</param>
        /// <returns>AdminData class if data found, null if not.</returns>
        public static AdminData? GetPlayerAdminData(string adminName)
        {
            return _admins.GetValueOrDefault(adminName);
        }

        /// <summary>
        /// Checks to see if a player has access to a certain set of permission flags.
        /// </summary>
        /// <param name="player">Player or server console.</param>
        /// <param name="flags">Flags to look for in the players permission flags.</param>
        /// <returns>True if flags are present, false if not.</returns>
        public static bool PlayerHasPermissions(CCSPlayerController? player, params string[] flags)
        {
            // This is here for cases where the server console is attempting to call commands.
            // The server console should have access to all commands, regardless of permissions.
            if (player == null) return true;
            if (!player.IsValid || player.Connected != PlayerConnectedState.PlayerConnected || player.IsBot) { return false; }
            var data = GetPlayerAdminData(new SteamID(player.SteamID));
            if (data == null) return false;

            return data.Flags.Intersect(flags).Count() == flags.Count();
        }

        /// <summary>
        /// Checks to see if a player has access to a certain set of permission flags.
        /// </summary>
        /// <param name="steamid">Steam ID object.</param>
        /// <param name="flags">Flags to look for in the players permission flags.</param>
        /// <returns>True if flags are present, false if not.</returns>
        public static bool PlayerHasPermissions(SteamID steamid, params string[] flags)
        {
            var data = GetPlayerAdminData(steamid);
            if (data == null) return false;

            return data.Flags.Intersect(flags).Count() == flags.Count();
        }
        
        /// <summary>
        /// Temporarily adds a permission flag to the player. These flags are not saved to
        /// "configs/admins.json".
        /// </summary>
        /// <param name="player">Player controller to add a flag to.</param>
        /// <param name="flags">Flags to add for the player.</param>
        public static void AddPlayerPermissions(CCSPlayerController? player, params string[] flags)
        {
            if (player == null) return;
            if (!player.IsValid || player.Connected != PlayerConnectedState.PlayerConnected || player.IsBot) return;

            var steamID = new SteamID(player.SteamID);
            var data = GetPlayerAdminData(steamID);
            if (data == null)
            {
                data = new AdminData();
                data.Flags = new List<string>();
                data.Flags.AddRange(flags);

                data.AuthType = "steamid3";
                data.Identity = steamID.SteamId3;

                _admins[player.PlayerName] = data;
                return;
            }
            else
            {
                foreach (var flag in flags)
                {
                    if (!data.Flags.Contains(flag)) data.Flags.Add(flag);
                }
            }
        }

        /// <summary>
        /// Temporarily removes a permission flag to the player. These flags are not saved to
        /// "configs/admins.json".
        /// </summary>
        /// <param name="player">Player controller to add a flag to.</param>
        /// <param name="flags">Flags to remove from the player.</param>
        public static void RemovePlayerPermissions(CCSPlayerController? player, params string[] flags)
        {
            if (player == null) return;
            if (!player.IsValid || player.Connected != PlayerConnectedState.PlayerConnected || player.IsBot) return;

            var data = GetPlayerAdminData(new SteamID(player.SteamID));
            if (data == null) return;
            foreach (var flag in flags)
            {
                if (data.Flags.Contains(flag)) data.Flags.Remove(flag);
            }
        }
    }
}
