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

public partial class CAttributeManager : NativeObject
{
    public CAttributeManager (IntPtr pointer) : base(pointer) {}

	// m_Providers
	[SchemaMember("CAttributeManager", "m_Providers")]
	public NetworkedVector<CHandle<CBaseEntity>> Providers => Schema.GetDeclaredClass<NetworkedVector<CHandle<CBaseEntity>>>(this.Handle, "CAttributeManager", "m_Providers");

	// m_iReapplyProvisionParity
	[SchemaMember("CAttributeManager", "m_iReapplyProvisionParity")]
	public ref Int32 ReapplyProvisionParity => ref Schema.GetRef<Int32>(this.Handle, "CAttributeManager", "m_iReapplyProvisionParity");

	// m_hOuter
	[SchemaMember("CAttributeManager", "m_hOuter")]
	public CHandle<CBaseEntity> Outer => Schema.GetDeclaredClass<CHandle<CBaseEntity>>(this.Handle, "CAttributeManager", "m_hOuter");

	// m_bPreventLoopback
	[SchemaMember("CAttributeManager", "m_bPreventLoopback")]
	public ref bool PreventLoopback => ref Schema.GetRef<bool>(this.Handle, "CAttributeManager", "m_bPreventLoopback");

	// m_ProviderType
	[SchemaMember("CAttributeManager", "m_ProviderType")]
	public ref attributeprovidertypes_t ProviderType => ref Schema.GetRef<attributeprovidertypes_t>(this.Handle, "CAttributeManager", "m_ProviderType");

}