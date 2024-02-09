using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace SpectatorCameraConfig
{
  [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

  public class SpectatorCameraConfig : BaseUnityPlugin
  {
    private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
    private static SpectatorCameraConfig Instance;
    public static ConfigEntry<float> Distance = null;

    private void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
      }

      Distance = Config.Bind("Camera Settings", "Distance", -1.5f, "Distance of the camera from the player.");

      // Plugin startup logic
      Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
      harmony.PatchAll();
    }

    private void OnDestroy()
    {
      harmony.UnpatchSelf();
    }
  }
}
