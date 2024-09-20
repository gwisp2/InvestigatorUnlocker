using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace InvestigatorUnlocker
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;

        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} is loaded!");
            // Patch the methods
            var harmony = new Harmony("InvestigatorUnlocker");
            harmony.PatchAll();
        }
    }
}
