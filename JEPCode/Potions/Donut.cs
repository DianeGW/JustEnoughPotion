using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace JEP.JEPCode.Potions;
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class Donut : JEPPotion
{
    public override PotionRarity Rarity => PotionRarity.Common;
    public override PotionUsage Usage => PotionUsage.AnyTime;
    public override TargetType TargetType => TargetType.AnyPlayer;
    public override bool CanBeGeneratedInCombat => false;
    
    protected override IEnumerable<DynamicVar> CanonicalVars => 
        new List<DynamicVar> { new MaxHpVar(1m) };

    protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
    {
        JEPPotion.AssertValidForTargetedPotion(target);
        await CreatureCmd.GainMaxHp(target, (int)this.DynamicVars.MaxHp.BaseValue);
    }
}