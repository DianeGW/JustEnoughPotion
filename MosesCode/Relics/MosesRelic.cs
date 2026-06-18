using BaseLib.Abstracts;
using BaseLib.Utils;
using BaseLib.Extensions;
using Moses.MosesCode.Extensions;
namespace Moses.MosesCode.Relics;

[Pool(typeof(MegaCrit.Sts2.Core.Models.RelicPools.SharedRelicPool))]
public abstract class MosesRelic : CustomRelicModel
{
    public override string PackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicImagePath();
    protected override string PackedIconOutlinePath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png".RelicImagePath();
    protected override string BigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath();
}