using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Potions;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Combat.History.Entries;
using MegaCrit.Sts2.Core.Nodes.Vfx;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Nodes.Rooms;


namespace JEP.JEPCode.Potions;
[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
//if u delete the line below it keep giving an error, idk how to fix it, if u know how pls let me know!
[System.Diagnostics.CodeAnalysis.SuppressMessage("Localization", "STS001:Symbol missing localization", Justification = "<Pending>")]
public sealed class BoomPotion : JEPPotion

{
    public override PotionRarity Rarity => PotionRarity.Uncommon; //.Rare;
    public override PotionUsage Usage => PotionUsage.CombatOnly;
    public override TargetType TargetType => TargetType.None;
protected override async Task OnUse(PlayerChoiceContext choiceContext, Creature? target)
{
  var player = base.Owner?.Creature;
 if (player == null) return;
 int totalUnblockedDamage = (int)CombatManager.Instance.History.Entries.OfType<DamageReceivedEntry>().Where(e => e.Receiver == player && e.Result.UnblockedDamage > 0).Sum(e => e.Result.UnblockedDamage);
if (totalUnblockedDamage <= 0) return;
 var combat = player.CombatState;
 if (combat?.Creatures == null) return;
 foreach (var creature in combat.Creatures.ToList()) {if (creature == null || creature == player || creature.CurrentHp <= 0) continue;
 if (creature is Creature)
 {
   NCombatRoom.Instance?.CombatVfxContainer.AddChildSafely(NGroundFireVfx.Create(creature));}
    await CreatureCmd.Damage(choiceContext,  creature, (decimal)totalUnblockedDamage, ValueProp.Unpowered, player );
    }
}}