using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpectateCameraPullPatch.Patches
{
  [HarmonyPatch(typeof(PlayerControllerB))]
  internal class SpectateCameraPullPatch
  {
    private const float UpOffset = 0.1f;
    private const float RightOffset = 0.6f;
    private const float Distance = 1.8f;
    private const float TurnSpeed = 300f;

    [HarmonyPatch("LateUpdate")]
    [HarmonyPostfix]
    private static void LateUpdate(PlayerControllerB __instance)
    {
      if (__instance.spectatedPlayerScript != null)
      {
        Camera visorCamera = __instance.spectatedPlayerScript.visorCamera;
        Transform specPivotTransform = __instance.spectateCameraPivot.transform;

        Vector3 val = visorCamera.transform.forward * -1f; // pull back
        Vector3 val2 = visorCamera.transform.TransformDirection(Vector3.right) * RightOffset; // move right
        Vector3 val3 = Vector3.up * UpOffset; // move up
        float value = Distance;

        specPivotTransform.position = visorCamera.transform.position + val * value + val2 + val3;
        // specPivotTransform.rotation = Quaternion.LookRotation(visorCamera.transform.forward);

        // Rotate around visor
        /* float inputSpeed = Mouse.current.delta.x.ReadValue();
        if (inputSpeed > 0 || inputSpeed > 0)
        {
          specPivotTransform.RotateAround(
             visorCamera.transform.position,
             Vector3.up,
             inputSpeed * TurnSpeed * Time.deltaTime
           );
        } */
      }
    }
  }
}
