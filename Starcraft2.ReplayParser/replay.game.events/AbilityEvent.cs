﻿// -----------------------------------------------------------------------
// <copyright file="AbilityEvent.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Starcraft2.ReplayParser
{
    using System;

    using Streams;
    using Version;

    /// <summary>
    /// A player ability action.
    /// </summary>
    public class AbilityEvent : GameEventBase
    {
        public AbilityEvent(BitReader bitReader, Replay replay)
        {
            var flags = bitReader.Read(18);
            Queued = (flags & 2) != 0;
            RightClick = (flags & 8) != 0;
            WireframeClick = (flags & 0x20) != 0;
            ToggleAbility = (flags & 0x40) != 0;
            EnableAutoCast = (flags & 0x80) != 0;
            AbilityUsed = (flags & 0x100) != 0;
            WireframeUnload = (flags & 0x200) != 0;
            WireframeCancel = (flags & 0x400) != 0;
            MinimapClick = (flags & 0x10000) != 0;
            AbilityFailed = (flags & 0x20000) != 0;

            if ((flags & 0xf815) != 0) // Debug for unknown flags
            {
                var zero = 0d;
            }

            DefaultAbility = (bitReader.Read(1) == 0);
            if (!DefaultAbility)
            {
                AbilityType = AbilityData.GetAbilityType(
                    (int)bitReader.Read(16),
                    (int)bitReader.Read(5),
                    replay.ReplayBuild);
                DefaultActor = (bitReader.Read(1) == 0);
                if (!DefaultActor) // guessing
                {
                    var id = (int)bitReader.Read(32);
                    var unit = replay.GetUnitById(id);
                    if (unit == null)
                    {
                        unit = new Unit(id, UnitType.Unknown);
                        replay.GameUnits.Add(id, unit);
                    }
                }
            }

            var targetType = bitReader.Read(2);
            if (targetType == 1) // Location target
            {
                var targetX = bitReader.Read(20);
                var targetY = bitReader.Read(20);
                var targetZ = bitReader.Read(32);
                TargetLocation = Location.FromEventFormat(targetX, targetY, targetZ);
            }
            else if (targetType == 2) // Unit + Location target
            {
                TargetFlags = (int)bitReader.Read(8);
                WireframeIndex = (int)bitReader.Read(8);

                var unitId = (int)bitReader.Read(32);
                var unit = replay.GetUnitById(unitId);
                var unitTypeId = (int)bitReader.Read(16);
                if (unit == null)
                {
                    var unitType = UnitData.GetUnitType(unitTypeId, replay.ReplayBuild);
                    unit = new Unit(unitId, unitType);
                    replay.GameUnits.Add(unitId, unit);
                }

                var targetHasPlayer = bitReader.Read(1) == 1;
                if (targetHasPlayer)
                {
                    TargetPlayer = (int)bitReader.Read(4);
                }
                var targetHasTeam = bitReader.Read(1) == 1;
                if (targetHasTeam)
                {
                    TargetTeam = (int)bitReader.Read(4);
                }

                var targetX = bitReader.Read(20);
                var targetY = bitReader.Read(20);
                var targetZ = bitReader.Read(32);
                TargetLocation = Location.FromEventFormat(targetX, targetY, targetZ);
            }
            else if (targetType == 3) // Unit target
            {
                var id = (int)bitReader.Read(32);
            }

            var lastBit = bitReader.Read(1);
            if (lastBit == 1)
            {
                var zero = 0d;
            }
        }

        // ----------- flags ------------

        /// <summary>
        /// True if the event was created as a queued
        /// ability, i.e. by holding down Shift
        /// </summary>
        public bool Queued { get; private set; }

        /// <summary>
        /// True if the event was created using right click
        /// </summary>
        public bool RightClick { get; private set; }

        /// <summary>
        /// True if the event was created using a button
        /// on the wireframe and not the command card
        /// </summary>
        public bool WireframeClick { get; private set; }

        /// <summary>
        /// True if the event was created by toggling an ability's auto-cast
        /// functionality, i.e. by holding Alt or right clicking the command card
        /// </summary>
        public bool ToggleAbility { get; private set; }

        /// <summary>
        /// True if the event turns on auto-cast for the ability
        /// </summary>
        public bool EnableAutoCast { get; private set; }

        /// <summary>
        /// True if the ability was used.
        /// </summary>
        public bool AbilityUsed { get; private set; }

        /// <summary>
        /// True if the event was created by clicking a unit in the
        /// wireframe in a Transport unit (i.e. unloading a single unit)
        /// </summary>
        public bool WireframeUnload { get; private set; }

        /// <summary>
        /// True if the event was created by clicking a queue item in the
        /// wireframe (as opposed to simply pressing Cancel)
        /// </summary>
        public bool WireframeCancel { get; private set; }

        /// <summary>
        /// True if the ability target was chosen through the minimap
        /// </summary>
        public bool MinimapClick { get; private set; }

        /// <summary>
        /// True if the ability failed to complete
        /// </summary>
        public bool AbilityFailed { get; private set; }

        // --------- data ----------

        /// <summary>
        /// True if the ability is a default ability, such as harvest
        /// for SCVs, produced by right clicking with a unit selected
        /// </summary>
        public bool DefaultAbility { get; private set; }

        /// <summary>
        /// The type of an ability if not default, otherwise Unknown
        /// </summary>
        public AbilityType AbilityType { get; private set; }

        /// <summary>
        /// True if the actor is default:  Sometimes maphackers use blink
        /// hacks that could trigger this, and sometimes people are really
        /// good at micro.
        /// </summary>
        public bool DefaultActor { get; private set; }

        /// <summary>
        /// The actor if not default or null
        /// </summary>
        public Unit Actor { get; private set; }

        /// <summary>
        /// True if the event uses a default target, e.g. for self-cast abilities
        /// </summary>
        public bool DefaultTarget { get; private set; }

        /// <summary> 8 bits of flags used in Unit+Location targets.  Unknown. </summary>
        public int TargetFlags { get; private set; }

        /// <summary> The wireframe index of the target unit (unconfirmed) </summary>
        public int WireframeIndex { get; private set; }

        /// <summary> The target unit of the ability or null </summary>
        public Unit TargetUnit { get; private set; }

        /// <summary> The target location of the ability or null </summary>
        public Location TargetLocation { get; private set; }

        public int TargetPlayer { get; private set; }

        public int TargetTeam { get; private set; }
    }
}
