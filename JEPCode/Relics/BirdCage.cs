using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Saves.Runs;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using JEP.JEPCode.Potions;
namespace JEP.JEPCode.Relics;
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class BirdCage : JEPRelic
{
    private decimal _damageReceivedThisTurn;
    private int _hpLostCounter;
    private bool _wasUsed;
    public override RelicRarity Rarity => RelicRarity.Uncommon;
    protected override IEnumerable<IHoverTip> ExtraHoverTips => 
        new List<IHoverTip> { HoverTipFactory.FromPotion(ModelDb.Potion<BoomPotion>()) };
    public override bool IsUsedUp => _wasUsed;
    public override bool ShowCounter => !_wasUsed;
    public override int DisplayAmount => _hpLostCounter;
    [SavedProperty]
    private bool WasUsed
    {
        get => _wasUsed;
        set { AssertMutable(); _wasUsed = value; if (IsUsedUp) Status = RelicStatus.Disabled; }
    }
    [SavedProperty]
    public int HpLostCounter
    { get => _hpLostCounter;
        private set
        { AssertMutable(); if (_hpLostCounter != value)
            { _hpLostCounter = value; InvokeDisplayAmountChanged(); }
        }
    }
    public override Task BeforeCombatStart()
    { WasUsed = false;
        Status = RelicStatus.Normal;
        _damageReceivedThisTurn = 0m;
        HpLostCounter = 0;
        return Task.CompletedTask;
    }
    public override Task BeforeSideTurnStart(PlayerChoiceContext choiceContext, CombatSide side, IReadOnlyList<Creature> participants, ICombatState combatState)
    {
        if (participants.Contains(Owner.Creature) && !WasUsed)
        {
            _damageReceivedThisTurn = 0m;
            HpLostCounter = 0;
        }
        return Task.CompletedTask;
    }
    public override async Task AfterDamageReceived(PlayerChoiceContext choiceContext, Creature target, DamageResult result, ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        if (WasUsed || target != Owner.Creature) return;
        _damageReceivedThisTurn += result.UnblockedDamage;
        HpLostCounter = (int)_damageReceivedThisTurn;
        if (_damageReceivedThisTurn >= 20m)
        {
            WasUsed = true;
            Flash();
            await PotionCmd.TryToProcure<BoomPotion>(Owner);
        }
    }
}