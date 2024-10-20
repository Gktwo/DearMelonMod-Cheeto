using UnhollowerRuntimeLib;
using UnityEngine;
using MelonLoader;
using DmmCheatMod.functions;
using DmmCheat;

public class CheatGui : MonoBehaviour
{
    public CheatGui(global::System.IntPtr ptr)
        : base(ptr)
    {
    }

    public CheatGui()
        : base(ClassInjector.DerivedConstructorPointer<CheatGui>())
    {
        ClassInjector.DerivedConstructorBody(this);
    }

    private Rect windowRect = new Rect(200, 200, 400, 400);
    private bool windowVisible = true;
    private int currentLayout = 0;
    private bool godmode = false;

    public void OnUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F11)) // 检查F11键是否被按下
        {
            windowVisible = !windowVisible; // 切换窗口的显示
            MelonLogger.Msg("CheatWindow:" + windowVisible);

        }
    }
    public void OnGUI()
    {
        if (windowVisible)
        {
            windowRect = GUI.Window(0, windowRect, new global::System.Action<int>(MyWindow), "DMM Melon Cheeto  Ver0.01");
        }
    }

    public void MyWindow(int windowID)
    {
        // 一行四个按钮
        float buttonWidth = 70;
        float buttonHeight = 30;
        float spacing = 10;
        GUI.DragWindow(new Rect(0, 0, windowRect.width, 30));


        if (GUI.Button(new Rect(15 + (buttonWidth + spacing) * 1, 30, buttonWidth, buttonHeight), "玩家"))
        {
            currentLayout = 0; // 切换布局
        }
        if (GUI.Button(new Rect(15 + (buttonWidth + spacing) * 2, 30, buttonWidth, buttonHeight), "世界"))
        {
            currentLayout = 1; // 切换布局
        }

       
        // 根据当前布局显示不同内容
        GUI.Label(new Rect(15, 70, 400, 30), new string('-', 30 * 3));
        switch (currentLayout)
        {
            case 0:
                player();

                break;
            case 1:
                GUI.Label(new Rect(15, 100, 250, 30), "这是页面 2");
                break;
            default:
                break;
        }


    }

    private void player()
    {
        Godmode.godmode = GUI.Toggle(new Rect(15, 130, 250, 30), godmode, "无敌模式");
        if (Godmode.godmode != godmode)
        {
            godmode = !godmode;
            Godmode.Patch();
        }

       // GUI.Toggle(new Rect(15, 160, 250, 30), Godmode.godmode, "倍数伤害");

    }
}
