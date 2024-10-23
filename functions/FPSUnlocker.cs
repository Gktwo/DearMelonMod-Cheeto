using UnityEngine;
using MelonLoader;
using DmmCheatMod.GuiUtil;

namespace DmmCheatMod.functions
{
    internal static class FPSUnlocker
    {
        public static bool fpsunlocker = false;
        public static int fps = 60;

        public static void Gui(Rect pos, Rect pos2)
        {
            if (Widget.Checkbox("FPS解锁", pos, ref FPSUnlocker.fpsunlocker))
            {
                if (FPSUnlocker.fpsunlocker)
                {
                    Set();
                }
                else
                {
                    FPSUnlocker.fps = 60;
                    Set();
                }

            }
            if (Widget.IntHSlider(pos2, ref fps, 30, 360) && FPSUnlocker.fpsunlocker)
            {
                Set();
            }
        }
        public static void Set()
        {
            UnityEngine.Application.targetFrameRate = (int)fps;
            MelonLogger.Msg("[FPSUnlocker]Set to " + fps.ToString());
        }
    }
}
