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

public partial class CEntityIdentity : NativeObject
{
    public CEntityIdentity (IntPtr pointer) : base(pointer) {}

	// m_nameStringableIndex
	[SchemaMember("CEntityIdentity", "m_nameStringableIndex")]
	public ref Int32 NameStringableIndex => ref Schema.GetRef<Int32>(this.Handle, "CEntityIdentity", "m_nameStringableIndex");

	// m_name
	[SchemaMember("CEntityIdentity", "m_name")]
	public string Name
	{
		get { return Schema.GetUtf8String(this.Handle, "CEntityIdentity", "m_name"); }
		set { Schema.SetString(this.Handle, "CEntityIdentity", "m_name", value); }
	}

	// m_designerName
	[SchemaMember("CEntityIdentity", "m_designerName")]
	public string DesignerName
	{
		get { return Schema.GetUtf8String(this.Handle, "CEntityIdentity", "m_designerName"); }
		set { Schema.SetString(this.Handle, "CEntityIdentity", "m_designerName", value); }
	}

	// m_flags
	[SchemaMember("CEntityIdentity", "m_flags")]
	public ref UInt32 Flags => ref Schema.GetRef<UInt32>(this.Handle, "CEntityIdentity", "m_flags");

	// m_worldGroupId
	[SchemaMember("CEntityIdentity", "m_worldGroupId")]
	public WorldGroupId_t WorldGroupId => Schema.GetDeclaredClass<WorldGroupId_t>(this.Handle, "CEntityIdentity", "m_worldGroupId");

	// m_fDataObjectTypes
	[SchemaMember("CEntityIdentity", "m_fDataObjectTypes")]
	public ref UInt32 DataObjectTypes => ref Schema.GetRef<UInt32>(this.Handle, "CEntityIdentity", "m_fDataObjectTypes");

	// m_PathIndex
	[SchemaMember("CEntityIdentity", "m_PathIndex")]
	public ChangeAccessorFieldPathIndex_t PathIndex => Schema.GetDeclaredClass<ChangeAccessorFieldPathIndex_t>(this.Handle, "CEntityIdentity", "m_PathIndex");

	// m_pPrev
	[SchemaMember("CEntityIdentity", "m_pPrev")]
	public CEntityIdentity? Prev => Schema.GetPointer<CEntityIdentity>(this.Handle, "CEntityIdentity", "m_pPrev");

	// m_pNext
	[SchemaMember("CEntityIdentity", "m_pNext")]
	public CEntityIdentity? Next => Schema.GetPointer<CEntityIdentity>(this.Handle, "CEntityIdentity", "m_pNext");

	// m_pPrevByClass
	[SchemaMember("CEntityIdentity", "m_pPrevByClass")]
	public CEntityIdentity? PrevByClass => Schema.GetPointer<CEntityIdentity>(this.Handle, "CEntityIdentity", "m_pPrevByClass");

	// m_pNextByClass
	[SchemaMember("CEntityIdentity", "m_pNextByClass")]
	public CEntityIdentity? NextByClass => Schema.GetPointer<CEntityIdentity>(this.Handle, "CEntityIdentity", "m_pNextByClass");

}
