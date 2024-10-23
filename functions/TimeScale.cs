using UnityEngine;
using MelonLoader;
using DmmCheatMod.GuiUtil;

namespace DmmCheatMod.functions
{
    internal static class TimeScale
    {

        public static bool timescale = false;
        public static float rate = 1.0f;

        public static void Gui(Rect pos, Rect pos2)
        {
            if (Widget.Checkbox("时间膨胀", pos, ref TimeScale.timescale))
            {
                if (TimeScale.timescale)
                {
                    Set();
                }
                else
                {
                    TimeScale.rate = 1.0f;
                    Set();
                }

            }
            if (Widget.FloatHSlider(pos2, ref rate, 1.0f, 15.0f) && TimeScale.timescale)
            {
                Set();
            }
        }
        private static void Set()
        {
            UnityEngine.Time.timeScale = rate;
            MelonLogger.Msg("[TimeScale]Set to: "+rate.ToString("F1"));
        }
    }
}
