using BaseLib.Abstracts;
using Moses.MosesCode.Extensions;

namespace Moses.MosesCode.Character;

public class MosesPotionPool : CustomPotionPoolModel
{
//Copied from someone else's code, I don't know what it does but will keep it until I figure it out.///
    public override string BigEnergyIconPath => "icons/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "icons/text_energy.png".ImagePath();
}