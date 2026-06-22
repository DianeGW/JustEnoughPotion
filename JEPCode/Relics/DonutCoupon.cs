using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Saves.Runs;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.HoverTips;
using JEP.JEPCode.Potions;
namespace JEP.JEPCode.Relics;
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class DonutCoupon : JEPRelic
{private int _maxHpIncreases;
    public override RelicRarity Rarity => RelicRarity.Uncommon;
    public override bool ShowCounter => true;
    public override int DisplayAmount => _maxHpIncreases;
    protected override IEnumerable<IHoverTip> ExtraHoverTips => 
        new List<IHoverTip> { HoverTipFactory.FromPotion(ModelDb.Potion<Donut>()) };
    [SavedProperty]
    public int MaxHpIncreases
    {
        get => _maxHpIncreases;
        private set
        { AssertMutable(); if (_maxHpIncreases != value)
            {
                _maxHpIncreases = value;
                InvokeDisplayAmountChanged();
            }
        }
    }
    public override async Task AfterObtained()
    {
        await base.AfterObtained();
        Owner.Creature.MaxHpChanged += OnMaxHpChanged;
    }
    public override async Task AfterRemoved()
    {
        await base.AfterRemoved();
        Owner.Creature.MaxHpChanged -= OnMaxHpChanged;
    }
    private void OnMaxHpChanged(int oldHp, int newHp)
    {
        if (newHp > oldHp)
        { NotifyMaxHpIncreased(); }
    }
    public void NotifyMaxHpIncreased()
    { MaxHpIncreases++; if (MaxHpIncreases >= 3) { Flash(); MaxHpIncreases = 0; TaskHelper.RunSafely(ObtainDonut()); }
    } private async Task ObtainDonut()
    { await PotionCmd.TryToProcure<Donut>(Owner); }
}