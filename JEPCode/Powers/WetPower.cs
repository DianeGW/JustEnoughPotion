
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Combat;
using Godot;
using MegaCrit.Sts2.Core.Nodes.Rooms;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace JEP.JEPCode.Powers;
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]

public sealed class WetPower : JEPPower
{

 public override int DisplayAmount => Amount;

    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;

protected override IEnumerable<IHoverTip> ExtraHoverTips => 
        new List<IHoverTip> { HoverTipFactory.Static(StaticHoverTip.Block) };

    public override decimal ModifyBlockMultiplicative(Creature target, decimal block, ValueProp props, MegaCrit.Sts2.Core.Models.CardModel? cardSource, CardPlay? cardPlay)
    {
    if (target != base.Owner || !props.IsPoweredCardOrMonsterMoveBlock()) 
        return 1m;
    if (block > 0)
    {
        NCombatRoom.Instance?.PlaySplashVfx(this.Owner, new Color("78a7ff"));
        this.Flash();
    }
        if (target != base.Owner || !props.IsPoweredCardOrMonsterMoveBlock()) return 1m;
        return 0.5m;
    }

    public override async Task AfterSideTurnStart(CombatSide side, IReadOnlyList<Creature> participants, ICombatState combatState)
    {
        if (participants.Contains(base.Owner))
        {
            await PowerCmd.Decrement(this);
        }
    }
}