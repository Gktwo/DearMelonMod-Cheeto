using System;
using UnityEngine;

namespace DmmCheatMod.GuiUtil
{
    internal static class Widget
    {
        public static bool Checkbox(string label, Rect pos, ref bool state)
        {
            // 使用 GUI.Toggle 来绘制复选框
            bool newState = GUI.Toggle(pos, state, label);

            // 检查状态是否有改变
            if (newState != state)
            {
                // 更新状态并返回 true，表示状态已改变
                state = newState;
                return true;
            }

            // 返回 false，表示状态未改变
            return false;
        }


        public static bool FloatHSlider(Rect pos, ref float value, float minValue, float maxValue)
        {

            float v = GUI.HorizontalSlider(pos, value, minValue, maxValue);
            GUI.Label(new Rect(pos.x + pos.width + 30, pos.y, 100, 30), value.ToString("F2"));
            if (v != value)
            {
                value = v;
                return true;
            }

            return false;
        }

        public static bool IntHSlider(Rect pos, ref int value, int minValue, int maxValue)
        {

            int v = (int)GUI.HorizontalSlider(pos, value, (float)minValue, (float)maxValue);
            GUI.Label(new Rect(pos.x + pos.width + 30, pos.y, 100, 30), value.ToString());
            if (v != value)
            {
                value = v;
                return true;
            }
            return false;
        }

    }
}

