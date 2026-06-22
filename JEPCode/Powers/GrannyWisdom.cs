using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Combat.History.Entries;
namespace JEP.JEPCode.Powers;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization",
    Justification = "<Pending>")]
public class GrannyWisdomPower : JEPPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public override int DisplayAmount => Amount;
    public override async Task AfterSideTurnStartLate(CombatSide side, IReadOnlyList<Creature> participants,
        ICombatState combatState)
    {
        if (!Owner.IsMonster)
        {
            MainFile.Logger.Warn($"The power {Id.Entry} should only ever be on Creatures of Type Monster!");
            await PowerCmd.Remove(this);
            return;
        }
        if (side != CombatSide.Player) return;
        var previousState = CombatManager.Instance.History.Entries.Where(e => e.Actor == Owner)
            .OfType<MonsterPerformedMoveEntry>().Select(e => e.Move).LastOrDefault();
        if (previousState != null)
            Owner.Monster!.SetMoveImmediate(previousState, true);
        await PowerCmd.TickDownDuration(this);
    }
}