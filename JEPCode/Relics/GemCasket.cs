using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Relics;
using BaseLib.Abstracts;
using JEP.JEPCode.Extensions;
namespace JEP.JEPCode.Relics;
[Pool(typeof(MegaCrit.Sts2.Core.Models.RelicPools.SharedRelicPool))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization",
    Justification = "<Pending>")]
public sealed class GemCasket : CustomRelicModel
{ public override RelicRarity Rarity => RelicRarity.Shop;
    public override string PackedIconPath => "gem_casket.png".RelicImagePath();
    protected override string PackedIconOutlinePath => "gem_casket_outline.png".RelicImagePath();
    protected override string BigIconPath => "big/gem_casket.png".RelicImagePath();
    public async Task OnPotionUsed(PotionModel potion)
    { var player = this.Owner; if (this.Owner != null) { this.Flash(); await CreatureCmd.Heal(player.Creature, 5); } } }