using BaseLib.Abstracts;
using BaseLib.Utils;
using BaseLib.Extensions;
using JEP.JEPCode.Extensions;
namespace JEP.JEPCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
public abstract class JEPPotion : CustomPotionModel
{
    public override string? CustomPackedImagePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png"
            .PotionImagePath();
    public override string? CustomPackedOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png"
            .PotionOutlineImagePath();
}