﻿using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;
using UnityEngine.Playables;
using Il2Cpp;



namespace DmmCheat
{
    public class Loader : MelonMod
    {
       // public CheatGui cheatGui;
        public static GameObject IsRunning = null;


        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<CheatGui>();
            //cheatGui = new CheatGui();
        }
        //private Rect windowRect = new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 250, 300);
        //private bool windowVisible = true;
        //private int currentLayout = 0;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("DMM Cheat Mod Loaded");
        }

        public override void OnGUI()
        {
            //cheatGui.OnGUI(); // 调用 CheatGui 的 OnGUI 方法
        }

        public void Start()
        {

        }
        public override void OnUpdate()
        {
            //cheatGui.OnUpdate();
            if (Loader.IsRunning == null)
            {
                Loader.IsRunning = new GameObject();
                Loader.IsRunning.AddComponent<CheatGui>();
                global::UnityEngine.Object.DontDestroyOnLoad(Loader.IsRunning);
            }
        }

    }
}
