using Content.Shared.Roles;

namespace Content.Server._Harmony.Roles;

/// <summary>
///     Added to mind role entities to tag that they are a perma prisoner.
/// </summary>
[RegisterComponent]
public sealed partial class PermaPrisonerRoleComponent : BaseMindRoleComponent;
