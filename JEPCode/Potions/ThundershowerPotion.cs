using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Nodes.Rooms;
using MegaCrit.Sts2.Core.Entities.Cards;
using JEP.JEPCode.Powers;

namespace JEP.JEPCode.Potions;
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]

public sealed class ThundershowerPotion : JEPPotion

{
    public override PotionRarity Rarity => PotionRarity.Rare;
    public override PotionUsage Usage => PotionUsage.CombatOnly;
    public override TargetType TargetType => TargetType.None;

    protected override IEnumerable<DynamicVar> CanonicalVars => 
        new List<DynamicVar> { new PowerVar<WeakPower>(1m) };

    protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
   {
        var playerCreature = base.Owner.Creature;
        var combat = playerCreature.CombatState;

        if (combat == null) return;

        foreach (var enemy in combat.Enemies)
        {
            // Visual Effect
            NCombatRoom.Instance?.PlaySplashVfx(enemy, new Color("78a7ff"));
            await PowerCmd.Apply<WeakPower>(choiceContext, enemy, (int)base.DynamicVars.Weak.BaseValue, playerCreature, null);
            await PowerCmd.Apply<Wet>(choiceContext, enemy, 3, playerCreature, null);

            // 2. Block Removal Logic
            // Using base.Owner.Creature for HP check
            //float hpPercent = (float)playerCreature.CurrentHp / playerCreature.MaxHp;
            //int blockToRemove = (hpPercent < 0.5f) 
            //    ? enemy.Block 
            //    : (int)System.Math.Floor(enemy.Block * 0.5f);
            //if (blockToRemove > 0)
            //{
            //    await CreatureCmd.LoseBlock(enemy, blockToRemove);
            //}
        }
    }
}