using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Potions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

using MegaCrit.Sts2.Core.Entities.Creatures;

namespace Moses.MosesCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
public class WitchsCupcake : MosesPotion
{
    public override PotionRarity Rarity => PotionRarity.Uncommon;
    public override PotionUsage Usage => PotionUsage.AnyTime;
    public override TargetType TargetType => TargetType.AnyPlayer; 
     protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
    if (target != null)
    {
        await CreatureCmd.Heal(target, 15m);
    }
 }
}