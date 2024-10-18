using UnhollowerRuntimeLib;
using UnityEngine;

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

    public void OnUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F11)) // 检查F11键是否被按下
        {
            windowVisible = !windowVisible; // 切换窗口的显示
            Debug.Log("CheatWindow:" + windowVisible);
        }
    }
    public void OnGUI()
    {
        if (windowVisible)
        {
            windowRect=GUI.Window(0, windowRect, new global::System.Action<int>(MyWindow), "DMM Melon Cheeto  Ver0.01");
        }
    }

    public void MyWindow(int windowID)
    {
        // 一行四个按钮
        float buttonWidth = 70;
        float buttonHeight = 30;
        float spacing = 10;
        GUI.DragWindow(new Rect(0, 0, windowRect.width, 30));
        for (int i = 0; i < 4; i++)
        {
            if (GUI.Button(new Rect(15 + (buttonWidth + spacing) * i, 30, buttonWidth, buttonHeight), $"按钮 {i + 1}"))
            {
                currentLayout = i; // 切换布局
            }
        }

        // 根据当前布局显示不同内容
        GUI.Label(new Rect(15, 70, 250, 30), $"当前页面: {currentLayout + 1}");
        switch (currentLayout)
        {
            case 0:
                GUI.Label(new Rect(15, 100, 250, 30), "这是页面 1");
                break;
            case 1:
                GUI.Label(new Rect(15, 100, 250, 30), "这是页面 2");
                break;
            case 2:
                GUI.Label(new Rect(15, 100, 250, 30), "这是页面 3");
                break;
            case 3:
                GUI.Label(new Rect(15, 100, 250, 30), "这是页面 4");
                break;
        }
       

    }
}
