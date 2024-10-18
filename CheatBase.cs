
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;


namespace CheatBase
{
    public static  class CheatBase
    {

        //patch=install/uninstall,HarmonyMethod=prefix/postfix, type:typeof(class),Methodname:Original Method name, mymethodclass:typeof(class),mymethodName:patch method name
        static bool PatchMethod(bool patch, String HarmonyMethod, Type type, String Methodname, Type mymethodclass = null, String mymethodName = null)
        {
            var harmony = new HarmonyLib.Harmony("harmony");


            MethodInfo original = AccessTools.Method(type, Methodname);
            if (original == null)
            {
                
                Debug.LogError($"Method {Methodname} not found in {type}");
                return false;
            }

            if (patch)
            {

                if (HarmonyMethod == "prefix")
                {
                    harmony.Patch(
                    original: AccessTools.Method(type, Methodname),//hook
                    prefix: new HarmonyMethod(mymethodclass, mymethodName)//patch
                 );
                }
                return true;
            }
            else//unpatch
            {
                if (HarmonyMethod == "prefix")
                {
                    harmony.Unpatch(
                    original: AccessTools.Method(type, Methodname),
                    HarmonyPatchType.Prefix,
                    harmony.Id
                );
                }
                return false;
            }
        }
    }
}
