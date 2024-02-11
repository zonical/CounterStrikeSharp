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

public partial class CPathParticleRope : CBaseEntity
{
    public CPathParticleRope (IntPtr pointer) : base(pointer) {}

	// m_bStartActive
	[SchemaMember("CPathParticleRope", "m_bStartActive")]
	public ref bool StartActive => ref Schema.GetRef<bool>(this.Handle, "CPathParticleRope", "m_bStartActive");

	// m_flMaxSimulationTime
	[SchemaMember("CPathParticleRope", "m_flMaxSimulationTime")]
	public ref float MaxSimulationTime => ref Schema.GetRef<float>(this.Handle, "CPathParticleRope", "m_flMaxSimulationTime");

	// m_iszEffectName
	[SchemaMember("CPathParticleRope", "m_iszEffectName")]
	public string EffectName
	{
		get { return Schema.GetUtf8String(this.Handle, "CPathParticleRope", "m_iszEffectName"); }
		set { Schema.SetString(this.Handle, "CPathParticleRope", "m_iszEffectName", value); }
	}

	// m_PathNodes_Name
	[SchemaMember("CPathParticleRope", "m_PathNodes_Name")]
	public NetworkedVector<string> PathNodes_Name => Schema.GetDeclaredClass<NetworkedVector<string>>(this.Handle, "CPathParticleRope", "m_PathNodes_Name");

	// m_flParticleSpacing
	[SchemaMember("CPathParticleRope", "m_flParticleSpacing")]
	public ref float ParticleSpacing => ref Schema.GetRef<float>(this.Handle, "CPathParticleRope", "m_flParticleSpacing");

	// m_flSlack
	[SchemaMember("CPathParticleRope", "m_flSlack")]
	public ref float Slack => ref Schema.GetRef<float>(this.Handle, "CPathParticleRope", "m_flSlack");

	// m_flRadius
	[SchemaMember("CPathParticleRope", "m_flRadius")]
	public ref float Radius => ref Schema.GetRef<float>(this.Handle, "CPathParticleRope", "m_flRadius");

	// m_ColorTint
	[SchemaMember("CPathParticleRope", "m_ColorTint")]
	public Color ColorTint
	{
		get { return Schema.GetCustomMarshalledType<Color>(this.Handle, "CPathParticleRope", "m_ColorTint"); }
		set { Schema.SetCustomMarshalledType<Color>(this.Handle, "CPathParticleRope", "m_ColorTint", value); }
	}

	// m_nEffectState
	[SchemaMember("CPathParticleRope", "m_nEffectState")]
	public ref Int32 EffectState => ref Schema.GetRef<Int32>(this.Handle, "CPathParticleRope", "m_nEffectState");

	// m_iEffectIndex
	[SchemaMember("CPathParticleRope", "m_iEffectIndex")]
	public CStrongHandle<InfoForResourceTypeIParticleSystemDefinition> EffectIndex => Schema.GetDeclaredClass<CStrongHandle<InfoForResourceTypeIParticleSystemDefinition>>(this.Handle, "CPathParticleRope", "m_iEffectIndex");

	// m_PathNodes_Position
	[SchemaMember("CPathParticleRope", "m_PathNodes_Position")]
	public NetworkedVector<Vector> PathNodes_Position => Schema.GetDeclaredClass<NetworkedVector<Vector>>(this.Handle, "CPathParticleRope", "m_PathNodes_Position");

	// m_PathNodes_TangentIn
	[SchemaMember("CPathParticleRope", "m_PathNodes_TangentIn")]
	public NetworkedVector<Vector> PathNodes_TangentIn => Schema.GetDeclaredClass<NetworkedVector<Vector>>(this.Handle, "CPathParticleRope", "m_PathNodes_TangentIn");

	// m_PathNodes_TangentOut
	[SchemaMember("CPathParticleRope", "m_PathNodes_TangentOut")]
	public NetworkedVector<Vector> PathNodes_TangentOut => Schema.GetDeclaredClass<NetworkedVector<Vector>>(this.Handle, "CPathParticleRope", "m_PathNodes_TangentOut");

	// m_PathNodes_Color
	[SchemaMember("CPathParticleRope", "m_PathNodes_Color")]
	public NetworkedVector<Vector> PathNodes_Color => Schema.GetDeclaredClass<NetworkedVector<Vector>>(this.Handle, "CPathParticleRope", "m_PathNodes_Color");

	// m_PathNodes_PinEnabled
	[SchemaMember("CPathParticleRope", "m_PathNodes_PinEnabled")]
	public NetworkedVector<bool> PathNodes_PinEnabled => Schema.GetDeclaredClass<NetworkedVector<bool>>(this.Handle, "CPathParticleRope", "m_PathNodes_PinEnabled");

	// m_PathNodes_RadiusScale
	[SchemaMember("CPathParticleRope", "m_PathNodes_RadiusScale")]
	public NetworkedVector<float> PathNodes_RadiusScale => Schema.GetDeclaredClass<NetworkedVector<float>>(this.Handle, "CPathParticleRope", "m_PathNodes_RadiusScale");

}