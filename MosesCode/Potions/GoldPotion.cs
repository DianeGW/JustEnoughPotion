
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Rooms;
namespace Moses.MosesCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
public sealed class GoldPotion : MosesPotion
{
    public override PotionRarity Rarity => PotionRarity.Common;
    public override PotionUsage Usage => PotionUsage.AnyTime;
    public override TargetType TargetType => TargetType.AnyPlayer;
protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
        int currentGold = base.Owner.Gold; 
        int goldGain = Math.Min((int)(currentGold * 0.5f), 50);
        await PlayerCmd.GainGold(goldGain, base.Owner);
    }
}