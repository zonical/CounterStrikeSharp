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

public partial class SimpleConstraintSoundProfile : NativeObject
{
    public SimpleConstraintSoundProfile (IntPtr pointer) : base(pointer) {}

	// m_keyPoints
	[SchemaMember("SimpleConstraintSoundProfile", "m_keyPoints")]
	public Span<float> KeyPoints => Schema.GetFixedArray<float>(this.Handle, "SimpleConstraintSoundProfile", "m_keyPoints", 2);

	// m_reversalSoundThresholds
	[SchemaMember("SimpleConstraintSoundProfile", "m_reversalSoundThresholds")]
	public Span<float> ReversalSoundThresholds => Schema.GetFixedArray<float>(this.Handle, "SimpleConstraintSoundProfile", "m_reversalSoundThresholds", 3);

}
