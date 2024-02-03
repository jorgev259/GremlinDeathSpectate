using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace GremlinDeathSpectate
{
  [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

  public class SpectateCameraPullPatch : BaseUnityPlugin
  {
    private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
    private static SpectateCameraPullPatch Instance;
    public static ConfigEntry<float> Distance = null;

    public static ConfigEntry<float> RightOffset = null;

    public static ConfigEntry<float> UpOffset = null;
    public static ConfigEntry<float> RotateSpeed = null;

    private void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
      }

      Distance = Config.Bind("Camera Settings", "Distance", 2f, "Distance of the camera from the player.");
      RightOffset = Config.Bind("Camera Settings", "Right-Offset", 0.6f, "Offset of the camera to the right from the player.");
      UpOffset = Config.Bind("Camera Settings", "Up-Offset", 0.1f, "Offset of the camera upwards from the player.");
      RotateSpeed = Config.Bind("Camera Settings", "Rotate-Speed", 300f, "Speed at which the spectator camera moves around.");

      // Plugin startup logic
      Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
      harmony.PatchAll();
    }
  }
}
