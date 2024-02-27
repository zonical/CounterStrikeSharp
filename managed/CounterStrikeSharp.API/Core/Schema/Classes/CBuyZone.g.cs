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

public partial class CBuyZone : CBaseTrigger
{
    public CBuyZone (IntPtr pointer) : base(pointer) {}

	// m_LegacyTeamNum
	[SchemaMember("CBuyZone", "m_LegacyTeamNum")]
	public ref Int32 LegacyTeamNum => ref Schema.GetRef<Int32>(this.Handle, "CBuyZone", "m_LegacyTeamNum");

}
