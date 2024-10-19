
using HarmonyLib;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;


namespace CheatBase
{
    public static class CheatBase
    {

        //patch=install/uninstall,HarmonyMethod=prefix/postfix, type:typeof(class),Methodname:Original Method name, mymethodclass:typeof(class),mymethodName:patch method name
        static bool PatchPre(bool patch, Type originalClass, string methodName, Type myMethodClass = null, string myMethodName = null)
        {
            var harmony = new HarmonyLib.Harmony("harmony");

            MethodInfo original = AccessTools.Method(originalClass, methodName);
            if (original == null)
            {
                MelonLogger.Error($"Method {methodName} not found in {originalClass}");
                return false;
            }

            try
            {
                if (patch)
                {
                    harmony.Patch(
                        original: original,
                        prefix: new HarmonyMethod(myMethodClass, myMethodName)
                    );
                    MelonLogger.Msg($"Patched method {methodName} with prefix in {originalClass}");

                    return true;
                }
                else
                {
                    harmony.Unpatch(
                        original: original,
                        HarmonyPatchType.Prefix,
                        harmony.Id
                    );
                    MelonLogger.Msg($"Unpatched method {methodName} with prefix in {originalClass}");

                    return false;
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"Error while hook method {methodName} in {originalClass}: {ex.Message}");
                return false;
            }
        }
        public static bool PatchPost(bool patch, Type originalClass, string methodName, Type myMethodClass = null, string myMethodName = null)
        {
            var harmony = new HarmonyLib.Harmony("harmony");
            MethodInfo original = AccessTools.Method(originalClass, methodName);
            if (original == null)
            {
                MelonLogger.Error($"Method {methodName} not found in {originalClass}");
                return false;
            }

            try
            {
                if (patch)
                {
                    harmony.Patch(
                        original: original,
                        postfix: new HarmonyMethod(myMethodClass, myMethodName)
                    );
                    MelonLogger.Msg($"Patched method {methodName} with postfix in {originalClass}");

                    return true;
                }
                else
                {
                    harmony.Unpatch(
                        original: original,
                        HarmonyPatchType.Postfix,
                        harmony.Id
                    );
                    MelonLogger.Msg($"Unpatched method {methodName} with postfix in {originalClass}");

                    return false;
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"Error while hooking method {methodName} in {originalClass}: {ex.Message}");
                return false;
            }
        }
    }
}
