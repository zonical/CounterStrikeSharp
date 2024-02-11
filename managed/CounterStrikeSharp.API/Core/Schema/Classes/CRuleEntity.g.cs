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

public partial class CRuleEntity : CBaseModelEntity
{
    public CRuleEntity (IntPtr pointer) : base(pointer) {}

	// m_iszMaster
	[SchemaMember("CRuleEntity", "m_iszMaster")]
	public string Master
	{
		get { return Schema.GetUtf8String(this.Handle, "CRuleEntity", "m_iszMaster"); }
		set { Schema.SetString(this.Handle, "CRuleEntity", "m_iszMaster", value); }
	}

}