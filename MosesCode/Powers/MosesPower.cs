using BaseLib.Abstracts;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Powers;
using Moses.MosesCode.Extensions;

namespace Moses.MosesCode.Powers;
public abstract class MosesPower : CustomPowerModel
{    public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
    public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
    public abstract override PowerType Type { get; }
    public abstract override PowerStackType StackType { get; }
}