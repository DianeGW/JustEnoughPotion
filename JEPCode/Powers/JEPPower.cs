using BaseLib.Abstracts;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Powers;
using JEP.JEPCode.Extensions;
using MegaCrit.Sts2.Core.Entities.Creatures;

namespace JEP.JEPCode.Powers;
public abstract class JEPPower : CustomPowerModel
{

    public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
    public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
    public abstract override PowerType Type { get; }
    public abstract override PowerStackType StackType { get; }
}