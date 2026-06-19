using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Potions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

using MegaCrit.Sts2.Core.Entities.Creatures;

namespace JEP.JEPCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public class WitchsCupcake : JEPPotion
{
    public override PotionRarity Rarity => PotionRarity.Uncommon;
    public override PotionUsage Usage => PotionUsage.AnyTime;
    public override TargetType TargetType => TargetType.AnyPlayer; 
    public override bool CanBeGeneratedInCombat => false;
     protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
    if (target != null)
    { await CreatureCmd.Heal(target, 15m);}
 }
}