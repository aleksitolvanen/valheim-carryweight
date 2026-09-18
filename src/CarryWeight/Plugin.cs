using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace CarryWeight;

[BepInPlugin(Guid, Name, Version)]
public class CarryWeightPlugin : BaseUnityPlugin
{
    public const string Guid = "needlemods.valheim.carryweight";
    public const string Name = "CarryWeight";
    public const string Version = "1.0.0";

    internal const float VanillaBase = 300f;

    internal static ConfigEntry<float> BaseCarryWeight;

    private void Awake()
    {
        BaseCarryWeight = Config.Bind("General", "BaseCarryWeight", 1000f,
            "Base max carry weight, replacing the game's default of 300. Bonuses like Megingjord still add on top.");
        new Harmony(Guid).PatchAll();
        Logger.LogInfo($"{Name} {Version} loaded, base carry weight {BaseCarryWeight.Value}");
    }
}

[HarmonyPatch(typeof(Player), nameof(Player.GetMaxCarryWeight))]
internal static class GetMaxCarryWeightPatch
{
    private static void Postfix(ref float __result) =>
        __result += CarryWeightPlugin.BaseCarryWeight.Value - CarryWeightPlugin.VanillaBase;
}
