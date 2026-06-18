using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models; 
using MegaCrit.Sts2.Core.Entities.Relics;
using Moses.MosesCode.Extensions;

namespace MosesCode.Relics;
[Pool(typeof(MegaCrit.Sts2.Core.Models.RelicPools.SharedRelicPool))] 
public sealed class AuxiliaryBag : CustomRelicModel 
{
    private const string _potionSlotsKey = "PotionSlots";
    private const string _potionCountKey = "Potions";

    public override RelicRarity Rarity => RelicRarity.Shop;

    public override string PackedIconPath => "auxiliary_bag.png".RelicImagePath();
    protected override string PackedIconOutlinePath => "auxiliary_bag_outline.png".RelicImagePath();
    protected override string BigIconPath => "big/auxiliary_bag.png".RelicImagePath();
    public override bool HasUponPickupEffect => true;

    protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[]
    {
        new DynamicVar(_potionSlotsKey, 1m),
        new DynamicVar(_potionCountKey, 1m)
    };
    public override async Task AfterObtained()
    {
        await PlayerCmd.GainMaxPotionCount(base.DynamicVars[_potionSlotsKey].IntValue, base.Owner);
    }
    public override async Task BeforeCombatStart() 
    {
        Flash();
        List<PotionModel> list = PotionFactory.CreateRandomPotionsOutOfCombat(
            base.Owner, 
            base.DynamicVars[_potionCountKey].IntValue, 
            base.Owner.RunState.Rng.CombatPotionGeneration
        );
        foreach (PotionModel item in list)
        {
            await PotionCmd.TryToProcure(item.ToMutable(), base.Owner);
        }
    }
}