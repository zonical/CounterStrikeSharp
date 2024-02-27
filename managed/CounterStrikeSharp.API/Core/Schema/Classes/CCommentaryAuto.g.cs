// <auto-generated />
#nullable enable
#pragma warning disable CS1591

using System;
using System.Diagnostics;
using System.Drawing;
using CounterStrikeSharp;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Core.Attributes;

namespace CounterStrikeSharp.API.Core;

public partial class CCommentaryAuto : CBaseEntity
{
    public CCommentaryAuto (IntPtr pointer) : base(pointer) {}

	// m_OnCommentaryNewGame
	[SchemaMember("CCommentaryAuto", "m_OnCommentaryNewGame")]
	public CEntityIOOutput OnCommentaryNewGame => Schema.GetDeclaredClass<CEntityIOOutput>(this.Handle, "CCommentaryAuto", "m_OnCommentaryNewGame");

	// m_OnCommentaryMidGame
	[SchemaMember("CCommentaryAuto", "m_OnCommentaryMidGame")]
	public CEntityIOOutput OnCommentaryMidGame => Schema.GetDeclaredClass<CEntityIOOutput>(this.Handle, "CCommentaryAuto", "m_OnCommentaryMidGame");

	// m_OnCommentaryMultiplayerSpawn
	[SchemaMember("CCommentaryAuto", "m_OnCommentaryMultiplayerSpawn")]
	public CEntityIOOutput OnCommentaryMultiplayerSpawn => Schema.GetDeclaredClass<CEntityIOOutput>(this.Handle, "CCommentaryAuto", "m_OnCommentaryMultiplayerSpawn");

}
