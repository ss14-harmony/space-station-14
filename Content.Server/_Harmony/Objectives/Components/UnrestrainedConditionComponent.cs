using Content.Server._Harmony.Objectives.Systems;

namespace Content.Server._Harmony.Objectives.Components;

/// <summary>
/// Requires that the player is unrestrained.
/// </summary>
[RegisterComponent, Access(typeof(UnrestrainedConditionSystem))]
public sealed partial class UnrestrainedConditionComponent : Component;
