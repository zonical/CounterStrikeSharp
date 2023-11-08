﻿using System;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Utils;

namespace CounterStrikeSharp.API.Core;

public partial class CBaseEntity
{
    public Vector AbsVelocity => Schema.GetDeclaredClass<Vector>(this.Handle, "CBaseEntity", "m_vecAbsVelocity");
    
    public void Teleport(Vector position, QAngle angles, Vector velocity)
    {
        VirtualFunction.CreateVoid<IntPtr, IntPtr, IntPtr, IntPtr>(Handle, GameData.GetOffset("CBaseEntity_Teleport"))(
            Handle, position.Handle, angles.Handle, velocity.Handle);
    }

    /// <summary>
    /// Shorthand for accessing an entity's CBodyComponent?.SceneNode?.AbsOrigin;
    /// </summary>
    public Vector? AbsOrigin => CBodyComponent?.SceneNode?.AbsOrigin;
    
    /// <summary>
    /// Shorthand for accessing an entity's CBodyComponent?.SceneNode?.AbsRotation;
    /// </summary>
    public QAngle? AbsRotation => CBodyComponent?.SceneNode?.AbsRotation;

}