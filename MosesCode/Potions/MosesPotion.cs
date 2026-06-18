using BaseLib.Abstracts;
using BaseLib.Utils;
using BaseLib.Extensions;
using Moses.MosesCode.Extensions;
namespace Moses.MosesCode.Potions;

[Pool(typeof(MegaCrit.Sts2.Core.Models.PotionPools.SharedPotionPool))]
public abstract class MosesPotion : CustomPotionModel
{
    public override string? CustomPackedImagePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png"
            .PotionImagePath();
    public override string? CustomPackedOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png"
            .PotionOutlineImagePath();
}