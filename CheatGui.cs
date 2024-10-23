using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using UnityEngine;
using DmmCheatMod.functions;
using DmmCheatMod.GuiUtil;
using DmmCheat;
using System.Linq;

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
    //player
    private bool godmode = false;
    private bool demagehack = false;

    //WORLD
    private bool fpsunlocker = false;
    private bool timescale = false;
    //private float deltaTime = 0.0f;
    public void Update()
    {
        // deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
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
        // 可拖动的窗口
        GUI.DragWindow(new Rect(0, 0, windowRect.width, 30));

        // 定义按钮属性
        float buttonWidth = 70;
        float buttonHeight = 30;
        float spacing = 10;

        // 绘制一个 Box 来包含按钮
        GUI.Box(new Rect(10, 30, windowRect.width - 20, 100), "菜单");

        // 定义按钮和布局的关联
        string[] buttonNames = { "关于", "玩家", "世界", "视觉" };
        int[] layoutIndices = { 0, 1, 2, 3 };

        // 循环创建按钮（显示在 Box 内）
        for (int i = 0; i < buttonNames.Length; i++)
        {
            if (GUI.Button(new Rect(20 + (buttonWidth + spacing) * i, 60, buttonWidth, buttonHeight), buttonNames[i]))
            {
                currentLayout = layoutIndices[i]; // 根据按钮切换布局
            }
        }

        // 绘制一个 Box 来包含内容
        GUI.Box(new Rect(10, 140, windowRect.width - 20, windowRect.height - 150), buttonNames[currentLayout]);

        // 根据当前布局显示不同内容
        switch (currentLayout)
        {
            case 0:
                About();
                break;
            case 1:
                Player();
                break;
            case 2:
                World();
                break;
            case 3:
                Visual();
                break;
            default:
                About();
                break;
        }
    }

    private void About()
    {
        // 显示在内容框内
        GUI.Label(new Rect(20, 160, windowRect.width - 40, 30), "这是免费的,如果你是购买获得,那么你被骗了");
    }

    private void Player()
    {
        // 此处可以放置玩家相关的内容
    }



    private void World()
    {
        //// 将控件位置调整到内容框内


        //时间膨胀
        TimeScale.Gui(new Rect(20, 160, 100, 30), new Rect(20, 190, 200, 30));



    }

    private void Visual()
    {
        //fps解锁
        FPSUnlocker.Gui(new Rect(20, 160, 100, 30), new Rect(20, 190, 200, 30));
    }
}
