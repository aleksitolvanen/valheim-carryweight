using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace CarryWeight;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class CarryWeightPlugin : BaseUnityPlugin
{
    internal static ConfigEntry<float> BaseCarryWeight = null!;

    private void Awake()
    {
        BaseCarryWeight = Config.Bind("General", "BaseCarryWeight", 1000f,
            new ConfigDescription(
                "Base max carry weight, replacing the game's default. Bonuses like Megingjord still add on top.",
                new AcceptableValueRange<float>(300f, 10000f)));
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harmony.PatchAll();
        var patched = harmony.GetPatchedMethods().Count();
        if (patched == 0)
            Logger.LogError("No methods patched — a game update likely changed Player.GetMaxCarryWeight");
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} {MyPluginInfo.PLUGIN_VERSION} loaded, {patched} patch(es), base carry weight {BaseCarryWeight.Value}");
    }
}

[HarmonyPatch(typeof(Player), nameof(Player.GetMaxCarryWeight))]
internal static class GetMaxCarryWeightPatch
{
    private static void Postfix(Player __instance, ref float __result) =>
        __result += CarryWeightPlugin.BaseCarryWeight.Value - __instance.m_maxCarryWeight;
}
