using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace SpectatorCameraConfig.Patches
{
  [HarmonyPatch(typeof(PlayerControllerB))]
  internal class CameraPatch
  {
    [HarmonyPatch("LateUpdate")]
    [HarmonyPostfix]
    private static void LateUpdate(PlayerControllerB __instance)
    {
      if (__instance.spectatedPlayerScript != null)
      {
        Transform spectateCameraPivot = __instance.spectateCameraPivot;
        Transform spectateCamera = spectateCameraPivot.Find("SpectateCamera");

        Vector3 newPosition = spectateCamera.position + spectateCamera.transform.forward * SpectatorCameraConfig.Distance.Value;
        spectateCamera.position = newPosition;
      }
    }
  }
}
