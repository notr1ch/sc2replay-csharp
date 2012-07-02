﻿// -----------------------------------------------------------------------
// <copyright file="UnitType.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Starcraft2.ReplayParser
{
    /// <summary>
    /// The version-independent type of a unit.
    /// </summary>
    public enum UnitType
    {
        // Unknown
        Unknown = 0,

        // Neutral units
        XelNagaTower,
        MineralField,
        RichMineralField,
        VespeneGeyser,
        SpacePlatformGeyser,
        RichVespeneGeyser,
        // Neutral units - Destructible
        MengskStatue,
        DestructibleDoodad,
        BraxisAlphaDestructible1x1,
        BraxisAlphaDestructible2x2,
        DestructibleDebris4x4,
        DestructibleDebris6x6,
        DestructibleRock2x4Vertical,
        DestructibleRock2x4Horizontal,
        DestructibleRock2x6Vertical,
        DestructibleRock2x6Horizontal,
        DestructibleRock4x4,
        DestructibleRock6x6,
        DestructibleRampDiagonalHugeULBR,
        DestructibleRampDiagonalHugeBLUR,
        DestructibleRampVerticalHuge,
        DestructibleRampHorizontalHuge,
        DestructibleDebrisRampDiagonalHugeULBR,
        DestructibleDebrisRampDiagonalHugeBLUR,
        // Neutral units - Critters
        Lyote,
        CarrionBird,
        Karak,
        Ursadak,
        UtilityBot,
        CommentatorBot,
        Scantipede,

        // Terran units
        SCV,
        MULE,
        Marine,
        Marauder,
        Reaper,
        Ghost,
        SiegeTank,
        SiegeTankSieged,
        Thor,
        Hellion,
        Medivac,
        Banshee,
        VikingFighter,
        VikingAssault,
        Raven,
        Battlecruiser,

        // Protoss units
        Probe,
        Zealot,
        Stalker,
        Sentry,
        HighTemplar,
        DarkTemplar,
        Archon,
        Immortal,
        Observer,
        WarpPrism,
        WarpPrismPhasing,
        Colossus,
        Phoenix,
        VoidRay,
        Mothership,
        Carrier,
        Interceptor,

        // Zerg units
        Larva,
        Egg,
        Drone,
        DroneBurrowed,
        Queen,
        QueenBurrowed,
        Zergling,
        ZerglingBurrowed,
        BanelingCocoon,
        Baneling,
        BanelingBurrowed,
        Roach,
        RoachBurrowed,
        Overlord,
        OverlordCocoon,
        Overseer,
        Changeling,
        ChangelingZealot,
        ChangelingMarine,
        ChangelingZergling,
        Hydralisk,
        HydraliskBurrowed,
        Mutalisk,
        Infestor,
        InfestorBurrowed,
        InfestedTerransEgg,
        InfestorTerran,
        InfestorTerranBurrowed,
        Corruptor,
        BroodLordCocoon,
        BroodLord,
        Broodling,
        Ultralisk,
        UltraliskBurrowed,

        // Terran buildings
        CommandCenter,
        CommandCenterFlying,
        OrbitalCommand,
        OrbitalCommandFlying,
        PlanetaryFortress,
        SupplyDepot,
        SupplyDepotLowered,
        Refinery,
        Barracks,
        BarracksFlying,
        Factory,
        FactoryFlying,
        Starport,
        StarportFlying,
        TechLab,
        BarracksTechLab,
        FactoryTechLab,
        StarportTechLab,
        Reactor,
        BarracksReactor,
        FactoryReactor,
        StarportReactor,
        Bunker,
        MissileTurret,
        SensorTower,
        GhostAcademy,
        EngineeringBay,
        Armory,
        FusionCore,
        AutoTurret,
        PointDefenseDrone,

        // Protoss buildings
        Nexus,
        Pylon,
        Assimilator,
        Gateway,
        Forge,
        FleetBeacon,
        TwilightCouncil,
        PhotonCannon,
        Stargate,
        TemplarArchive,
        DarkShrine,
        RoboticsBay,
        RoboticsFacility,
        CyberneticsCore,
        WarpGate,
        ForceField,

        // Zerg buildings
        Hatchery,
        Lair,
        Hive,
        Extractor,
        CreepTumor,
        CreepTumorBurrowed,
        EvolutionChamber,
        SpawningPool,
        BanelingNest,
        RoachWarren,
        HydraliskDen,
        Spire,
        InfestationPit,
        NydusNetwork,
        NydusCanal,
        UltraliskCavern,
        SpineCrawler,
        SpineCrawlerUprooted,
        SporeCrawler,
        SporeCrawlerUprooted,
        GreaterSpire
    }
}
