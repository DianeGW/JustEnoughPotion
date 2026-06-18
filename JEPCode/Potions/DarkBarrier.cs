using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Potions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Creatures;


namespace JEP.JEPCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public class DarkBarrier : JEPPotion
{
    public override PotionRarity Rarity => PotionRarity.Common;
    public override PotionUsage Usage => PotionUsage.CombatOnly   ;
    public override TargetType TargetType => TargetType.Self; 
     protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
    if (target != null)
    {
 await PowerCmd.Apply<Powers.DarkBarrier>
 ( choiceContext, 
            new[] { base.Owner.Creature }, 
            1m, 
            base.Owner.Creature, 
            null
        );
    }
}
}