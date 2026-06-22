using BaseLib.Abstracts;
using BaseLib.Extensions;
using JEP.JEPCode.Extensions;
namespace JEP.JEPCode.Powers;
public abstract class JEPPower : CustomPowerModel
{ public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
    public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath(); }