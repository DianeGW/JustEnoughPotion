using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.HoverTips;
using JEP.JEPCode.Powers;
namespace JEP.JEPCode.Potions;
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public class AzureSeaPotion : JEPPotion
{
    public override PotionRarity Rarity => PotionRarity.Rare;
    public override PotionUsage Usage => PotionUsage.CombatOnly;
    public override TargetType TargetType => TargetType.AnyEnemy;
    public override IEnumerable<IHoverTip> ExtraHoverTips => 
        new List<IHoverTip> 
        { 
            HoverTipFactory.FromPower(ModelDb.Power<AzureSeaPower>()), 
            HoverTipFactory.FromPower(ModelDb.Power<BlueRosePower>()) 
        };
    protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
        if (target == null) return;
        var playerCreature = this.Owner.Creature;
        {
            await PowerCmd.Apply<AzureSeaPower>(choiceContext, target, 3, playerCreature, null);
        }
    }
}