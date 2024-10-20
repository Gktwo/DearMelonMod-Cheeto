using UnityEngine;
using MelonLoader;

namespace DmmCheatMod.functions
{
    public static class TimeScale
    {

        public static void SetTimeScale(float rate) { 
            UnityEngine.Time.timeScale = rate;
        }
    }
}
