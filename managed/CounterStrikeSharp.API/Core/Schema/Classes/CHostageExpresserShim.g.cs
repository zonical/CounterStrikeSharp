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

public partial class CHostageExpresserShim : CBaseCombatCharacter
{
    public CHostageExpresserShim (IntPtr pointer) : base(pointer) {}

	// m_pExpresser
	[SchemaMember("CHostageExpresserShim", "m_pExpresser")]
	public CAI_Expresser? Expresser => Schema.GetPointer<CAI_Expresser>(this.Handle, "CHostageExpresserShim", "m_pExpresser");

}