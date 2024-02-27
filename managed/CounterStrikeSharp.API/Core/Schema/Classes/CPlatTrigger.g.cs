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

public partial class CPlatTrigger : CBaseModelEntity
{
    public CPlatTrigger (IntPtr pointer) : base(pointer) {}

	// m_pPlatform
	[SchemaMember("CPlatTrigger", "m_pPlatform")]
	public CHandle<CFuncPlat> Platform => Schema.GetDeclaredClass<CHandle<CFuncPlat>>(this.Handle, "CPlatTrigger", "m_pPlatform");

}
