using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Models; 

namespace JEP.JEPCode.Relics;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization",
    Justification = "<Pending>")]
public sealed class BirdCage : JEPRelic
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        new List<DynamicVar> { new DamageVar(5m, ValueProp.Unpowered) };

    public override async Task AfterPotionUsed(PotionModel potion, Creature? target) 
    { 
        if (target == null || this.Owner == null)return;
        this.Flash();
        dynamic dynamicTarget = target;
        dynamic choiceContext = dynamicTarget.CombatState?.ChoiceContext;
        if (choiceContext == null)
        { dynamic dynamicOwner = this.Owner; choiceContext = dynamicOwner.ChoiceContext ?? dynamicOwner.RunState?.ChoiceContext; }
        IEnumerable<DamageResult> damageResults = await CreatureCmd.Damage(choiceContext, target, this.DynamicVars.Damage, this.Owner.Creature);
    }
}