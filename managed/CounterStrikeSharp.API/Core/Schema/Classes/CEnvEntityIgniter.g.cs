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

public partial class CEnvEntityIgniter : CBaseEntity
{
    public CEnvEntityIgniter (IntPtr pointer) : base(pointer) {}

	// m_flLifetime
	[SchemaMember("CEnvEntityIgniter", "m_flLifetime")]
	public ref float Lifetime => ref Schema.GetRef<float>(this.Handle, "CEnvEntityIgniter", "m_flLifetime");

}
