using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Models; 
namespace JEP.JEPCode.Relics;
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class BirdCage : JEPRelic
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;
    protected override IEnumerable<DynamicVar> CanonicalVars => 
        new List<DynamicVar> { new DamageVar(5m, ValueProp.Unpowered) };
    public override async Task AfterPotionUsed(PotionModel potion, Creature? target) 
    { if (target == null) return;
        this.Flash();
        await CreatureCmd.Damage(null, target, this.DynamicVars.Damage, this.Owner.Creature
        );
    }
}