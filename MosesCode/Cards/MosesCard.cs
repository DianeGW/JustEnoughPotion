using BaseLib.Abstracts;
using BaseLib.Extensions;
using Moses.MosesCode.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace Moses.MosesCode.Cards;

public abstract class MosesCard(int cost, CardType type, CardRarity rarity, TargetType target) :
    CustomCardModel(cost, type, rarity, target)
{
    public override string CustomPortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();
    public override string BetaPortraitPath => $"beta/{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();
}
//not working on this rn.