﻿/*
 *  This file is part of CounterStrikeSharp.
 *  CounterStrikeSharp is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  CounterStrikeSharp is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with CounterStrikeSharp.  If not, see <https://www.gnu.org/licenses/>. *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Menu;

namespace CounterStrikeSharp.API.Core
{
    public sealed class GlobalContext
    {
        private static GlobalContext _instance = null;
        public static GlobalContext Instance => _instance;

        private DirectoryInfo rootDir;

        private List<PluginContext> _loadedPlugins = new List<PluginContext>();

        public GlobalContext()
        {
            rootDir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent;
            _instance = this;
        }

        ~GlobalContext()
        {
            foreach (var plugin in _loadedPlugins)
            {
                plugin.Unload();
            }
        }

        public void OnNativeUnload()
        {
            foreach (var plugin in _loadedPlugins)
            {
                plugin.Unload();
            }
        }
        public void InitGlobalContext()
        {
            Console.WriteLine("Loading GameData");
            GameData.Load(Path.Combine(rootDir.FullName, "gamedata", "gamedata.json"));

            for (int i = 1; i <= 9; i++)
            {
                AddCommand("css_" + i, "Command Key Handler", (player, info) =>
                {
                    if (player == null) return;
                    var key = Convert.ToInt32(info.GetArg(0).Split("_")[1]);
                    ChatMenus.OnKeyPress(player, key);
                });
            }

            Console.WriteLine("Loading C# plugins...");
            int pluginCount = LoadAllPlugins();
            Console.WriteLine($"All managed modules were loaded. {pluginCount} plugins loaded.");

            RegisterPluginCommands();
        }

        public void LoadPlugin(string path)
        {
            var plugin = new PluginContext(path);

            foreach (var existingPlugin in _loadedPlugins)
            {
                if (plugin.Name == existingPlugin.Name)
                {
                    throw new Exception("Plugin is already loaded.");
                }
            }
            plugin.Load();
            _loadedPlugins.Add(plugin);
        }

        public int LoadAllPlugins()
        {
            DirectoryInfo modules_directory_info;
            try
            {
                modules_directory_info = new DirectoryInfo(Path.Combine(rootDir.FullName, "plugins"));
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unable to access .NET modules directory: " + e.GetType().ToString() + " " + e.Message);
                return 0;
            }

            DirectoryInfo[] proper_modules_directories;
            try
            {
                proper_modules_directories = modules_directory_info.GetDirectories();
            }
            catch
            {
                proper_modules_directories = new DirectoryInfo[0];
            }

            var filePaths = proper_modules_directories
                .Where(d => d.GetFiles().Any((f) => f.Name == d.Name + ".dll"))
                .Select(d => d.GetFiles().First((f) => f.Name == d.Name + ".dll").FullName)
                .ToArray();

            foreach (var path in filePaths)
            {
                try
                {
                    LoadPlugin(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to load plugin {path} with error {e}");
                }
            }

            return _loadedPlugins.Count;
        }

        public void UnloadAllPlugins()
        {
            foreach (var plugin in _loadedPlugins)
            {
                plugin.Unload();
                _loadedPlugins.Remove(plugin);
            }
        }

        public PluginContext FindPluginByType(Type moduleClass)
        {
            var plugin = _loadedPlugins.FirstOrDefault(x => x.PluginType == moduleClass);
            return plugin;
        }

        public void OnCSSCommand(CCSPlayerController? caller, CommandInfo info)
        {
            Utilities.ReplyToCommand(caller, "  CounterStrikeSharp was created and is maintained by Michael \"roflmuffin\" Wilson.\n" +
                "  Counter-Strike Sharp uses code borrowed from SourceMod, Source.Python, FiveM, Saul Rennison and CS2Fixes.\n" +
                "  See ACKNOWLEDGEMENTS.md for more information.", true);
            return;
        }

        public void OnCSSPluginCommand(CCSPlayerController? caller, CommandInfo info)
        {
            switch (info.GetArg(1))
            {
                case "list":
                {
                    Utilities.ReplyToCommand(caller, "List of all plugins currently loaded by CounterStrikeSharp: ", true);
                    if (_loadedPlugins.Count() == 0)
                    {
                        Utilities.ReplyToCommand(caller, $"  0 plugins loaded.", true);
                    }
                    else
                    {
                        int pluginCount = 1;
                        foreach (var plugin in _loadedPlugins)
                        {
                            Utilities.ReplyToCommand(caller, $"  [{pluginCount}/{_loadedPlugins.Count()}]: \"{plugin.Name}\" (\"{plugin.Version}\")", true);
                            pluginCount++;
                        }
                    }

                    break;
                }
                case "start":
                case "load":
                {
                    if (info.ArgCount < 2)
                    {
                        Utilities.ReplyToCommand(caller, "Valid usage: css_plugins start/load [absolute plugin path] (e.g \"plugins/TestPlugin/TestPlugin.dll\")\n", true);
                        break;
                    }
                    var aboslutePluginPath = Path.Combine(rootDir.FullName, info.GetArg(2));
                    LoadPlugin(aboslutePluginPath);
                    
                    break;
                }

                case "stop":
                case "unload":
                {
                    var pluginName = info.GetArg(2); // MUST match output from plugin.Name
                    var plugin = _loadedPlugins.Find(x => x.Name == pluginName);
                    if (plugin == null)
                    {
                        Utilities.ReplyToCommand(caller, $"Could not unload plugin \"{pluginName}\")", true);
                        break;
                    }
                    plugin.Unload();
                    _loadedPlugins.Remove(plugin);
                    break;
                }

                case "restart":
                case "reload":
                {
                    var pluginName = info.GetArg(2); // MUST match output from plugin.Name
                    var plugin = _loadedPlugins.Find(x => x.Name == pluginName);
                    if (plugin == null)
                    {
                        Utilities.ReplyToCommand(caller, $"Could not reload plugin \"{pluginName}\")", true);
                        break;
                    }
                    plugin.Unload(true);
                    plugin.Load(true);
                    break;
                }

                default:
                    Utilities.ReplyToCommand(caller, "Valid usage: css_plugins [option]\n" +
                        "  list - List all plugins currently loaded.\n" +
                        "  start / load - Loads a plugin not currently loaded.\n" +
                        "  stop / unload - Unloads a plugin currently loaded.\n" +
                        "  restart / reload - Reloads a plugin currently loaded."
                        , true);
                    break;
            }

        }

        public void RegisterPluginCommands()
        {
            AddCommand("css", "Counter-Strike Sharp options.", OnCSSCommand);
            AddCommand("css_plugins", "Counter-Strike Sharp plugin options.", OnCSSPluginCommand);
        }

        /**
         * Temporary way for base CSS to add commands without a plugin context
         */
        private void AddCommand(string name, string description, CommandInfo.CommandCallback handler)
        {
            var wrappedHandler = new Action<int, IntPtr>((i, ptr) =>
            {
                var command = new CommandInfo(ptr);
                if (i == -1)
                {
                    handler?.Invoke(null, command);
                    return;
                }

                var entity = new CCSPlayerController(NativeAPI.GetEntityFromIndex(i + 1));
                handler?.Invoke(entity.IsValid ? entity : null, command);
            });

            var subscriber = new BasePlugin.CallbackSubscriber(handler, wrappedHandler, () => { });
            NativeAPI.AddCommand(name, description, false, (int)ConCommandFlags.FCVAR_LINKED_CONCOMMAND,
                subscriber.GetInputArgument());
        }
    }
}