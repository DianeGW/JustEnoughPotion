using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models; 
namespace JEP.JEPCode.Relics;
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class Dye : JEPRelic
{
    public override RelicRarity Rarity => RelicRarity.Shop;
    public override async Task AfterObtained()
    {
        var p = Owner;
        if (p != null)
        {
            var targetRelic = p.Relics
                .Where(r => r.Rarity != RelicRarity.Starter && r.Id != this.Id).LastOrDefault();
            if (targetRelic != null)
            {
                var newRelic = ModelDb.GetById<RelicModel>(targetRelic.Id).ToMutable();
                await RelicCmd.Obtain(newRelic, p);
                Flash();
            }
        }
    }
}