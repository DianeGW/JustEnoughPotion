
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models; 
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.Entities.Relics;

namespace JEP.JEPCode.Relics;
[Pool(typeof(MegaCrit.Sts2.Core.Models.RelicPools.SharedRelicPool))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class GemCasket : JEPRelic
{ public override RelicRarity Rarity => RelicRarity.Shop;
private int _usesThisCombat = 0;
    private const int MaxUses = 3;
    public GemCasket() : base() { }
    public void OnPotionUsed(PotionModel potion)
   { if (_usesThisCombat < MaxUses)
        {
            this.Flash();
            var player = this.Owner; 
            if (player != null)
            { CreatureCmd.Heal(this.Owner.Creature, 5); }
            _usesThisCombat++; }}
    public override async Task AfterCombatEnd(CombatRoom room)
    { _usesThisCombat = 0;}
}