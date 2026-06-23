using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;

namespace JEP.JEPCode.Powers;
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization",
    Justification = "<Pending>")]
public sealed class BlueRosePower : JEPPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public override int DisplayAmount => Amount;
    public override async Task AfterSideTurnStart(CombatSide side, IReadOnlyList<Creature> participants,
        ICombatState combatState)
    {
        if (!participants.Contains(base.Owner)) return;
        int damageAmount = (int)Math.Floor((decimal)base.Amount / 2m);
        if (damageAmount > 0)
        {
            await CreatureCmd.Damage(
                new ThrowingPlayerChoiceContext(),
                base.Owner,
                (decimal)damageAmount,
                ValueProp.Unblockable | ValueProp.Unpowered,
                base.Owner
            );
            await PowerCmd.ModifyAmount(
                new ThrowingPlayerChoiceContext(), this, -damageAmount, base.Owner, null, false);
            Flash();
        }
    }
}