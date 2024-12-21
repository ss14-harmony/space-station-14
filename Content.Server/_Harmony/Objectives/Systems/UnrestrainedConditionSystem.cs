using Content.Server._Harmony.Objectives.Components;
using Content.Server.Cuffs;
using Content.Server.Mind;
using Content.Shared.Cuffs.Components;
using Content.Shared.Mind;
using Content.Shared.Objectives.Components;

namespace Content.Server._Harmony.Objectives.Systems;

public sealed class UnrestrainedConditionSystem : EntitySystem
{
    [Dependency] private readonly CuffableSystem _cuffableSystem = default!;
    [Dependency] private readonly MindSystem _mindSystem = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<UnrestrainedConditionComponent, ObjectiveGetProgressEvent>(OnGetProgress);
    }

    private void OnGetProgress(EntityUid uid, UnrestrainedConditionComponent comp, ref ObjectiveGetProgressEvent args)
    {
        args.Progress = GetProgress((args.MindId, args.Mind));
    }

    private float GetProgress(Entity<MindComponent> mind)
    {
        if (mind.Comp.OwnedEntity is not {} entity || _mindSystem.IsCharacterDeadIc(mind))
            return 0f;

        if (!TryComp<CuffableComponent>(entity, out var cuffable))
            return 0f;

        return _cuffableSystem.IsCuffed((entity, cuffable)) ? 0f : 1f;
    }
}
