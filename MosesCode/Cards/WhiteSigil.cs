using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Models.CardPools;
using BaseLib.Abstracts;
namespace Moses.MosesCode.Cards;

[Pool(typeof(TokenCardPool))]
public class WhiteSigil: CustomCardModel
{
public override int MaxUpgradeLevel => 0;
    public override IEnumerable<CardKeyword> CanonicalKeywords => new List<CardKeyword> 
    { 
        CardKeyword.Exhaust, 
        CardKeyword.Retain 
    };

    public WhiteSigil() : base(1, CardType.Status, CardRarity.Status, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {

        await base.OnPlay(choiceContext, cardPlay);
    }
}
