using BaseLib.Abstracts;
using JEP.JEPCode.Extensions;

namespace JEP.JEPCode.Character;

public class JEPPotionPool : CustomPotionPoolModel
{
//Copied from someone else's code, I don't know what it does but will keep it until I figure it out.///
    public override string BigEnergyIconPath => "icons/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "icons/text_energy.png".ImagePath();
}