using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.HoverTips;
namespace JEP.JEPCode.Powers;
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class AzureSeaPower : JEPPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public override PowerInstanceType InstanceType => PowerInstanceType.Instanced;
    protected override IEnumerable<IHoverTip> ExtraHoverTips => 
        new List<IHoverTip> 
        { 
            HoverTipFactory.FromPower(ModelDb.Power<BlueRosePower>()) 
        };
    public override int DisplayAmount => Amount;
    public override async Task BeforeDeath(Creature creature)
    {
        await base.BeforeDeath(creature);
        if (creature == base.Owner)
        {
            await PowerCmd.Remove(this);
        }
    }
    public override async Task AfterRemoved(Creature owner)
    {
        await base.AfterRemoved(owner);
        var enemies = base.CombatState?.HittableEnemies?.ToList();
        if (enemies == null || enemies.Count == 0) return;
        foreach (Creature enemy in enemies)
        {
            int stacksOnEnemy = enemy.GetPowerAmount<BlueRosePower>();
            if (stacksOnEnemy > 0)
            {
                await PowerCmd.Remove<BlueRosePower>(enemy);
                await Cmd.CustomScaledWait(0.1f, 0.1f);
                await CreatureCmd.Damage(
                        new ThrowingPlayerChoiceContext(),
                        enemy,
                        (decimal)stacksOnEnemy,
                        ValueProp.Unblockable | ValueProp.Unpowered,
                        (Creature?)null 
                    );
            }
        }
    }
    public override async Task AfterDamageReceived(PlayerChoiceContext choiceContext, Creature target,
        DamageResult result, ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        if (target != base.Owner || CombatState.CurrentSide != CombatSide.Player) return;
        int x = this.Amount; 
        var enemies = CombatState.HittableEnemies;
        foreach (Creature enemy in enemies)
        {
            await PowerCmd.Apply<BlueRosePower>(new ThrowingPlayerChoiceContext(), enemy, 2, Owner, null);
        }
        Flash();
    }
    public override async Task AfterSideTurnEnd(PlayerChoiceContext choiceContext, CombatSide side, IEnumerable<Creature> participants)
    {
        if (side == CombatSide.Enemy)
        {
            await PowerCmd.TickDownDuration(this);
        }
    }
}