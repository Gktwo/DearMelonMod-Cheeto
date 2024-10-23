using UnityEngine;
using MelonLoader;

namespace DmmCheatMod.functions
{
    public static class TimeScale
    {

        public static bool timescale = false;
        public static bool timescale2 = false;

        public static float rate = 1.0f;
        public static float rate2 = 1.0f;
        public static void SetTimeScale()
        {
            if (timescale != timescale2)
            {
                if (timescale)
                {
                    Set();
                    timescale2 = timescale;
                }
                else
                {
                    UnityEngine.Time.timeScale = 1.0f;
                    MelonLogger.Msg("[TimeScale]Set to: 1.00");
                    timescale2 = timescale;
                    rate = 1.0f;
                    rate2 = 1.0f;
                }

            }
            else if (timescale&&rate != rate2)
            {
                Set();
                rate2 = rate;

            }
            

        }
        private static void Set()
        {
            UnityEngine.Time.timeScale = rate;
            MelonLogger.Msg("[TimeScale]Set to: "+rate.ToString("F2"));
        }
    }
}
