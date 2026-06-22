using Godot;
using MegaCrit.Sts2.Core.Modding;
namespace JEP.JEPCode;

[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "JEP"; //Used for resource filepath
    public const string ResPath = $"res://{ModId}";

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; }
        = new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        HarmonyLib.Harmony harmonyInstance = new(ModId);
        harmonyInstance.PatchAll();
    }
}
