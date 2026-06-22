using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Potions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Creatures;
using JEP.JEPCode.Potions;
namespace JEP.JEPCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public class CleansingPotion : JEPPotion
{
    public override PotionRarity Rarity => PotionRarity.Rare;
    public override PotionUsage Usage => PotionUsage.CombatOnly   ;
    public override TargetType TargetType => TargetType.AnyPlayer; 
   protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
{
    if (target != null)
    {
        var activePowers = target.Powers.ToList(); 
        foreach (var power in activePowers)
        {
            if (power.Type == PowerType.Debuff)
            {
                await PowerCmd.Remove(power);
            }
        }
    }
}
}