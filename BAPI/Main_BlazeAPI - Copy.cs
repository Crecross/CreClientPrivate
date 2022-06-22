using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using VRC;
using MelonLoader;
using VRC.UI.Elements.Menus;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRC.Core;
using CreClientTest.Settings;
using System.IO;
using CreClientTest.Modules;
using CreClientTest.MURDER;
using CreClientTest.GHOST;
using TMPro;
using VRC.SDKBase;
using VRC.UI.Elements;
using UnityEngine.Networking;
using UnityEngine.UI;
using WTFBlaze;



[assembly: MelonLoader.MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(CreClientTest.Main_BlazeAPI), "CreClient", "1.0", " Crecross#9901", "https://github.com/Crecross/CreClient/releases/download/Mods/CreClientTest.dll")]
[assembly: MelonColor(ConsoleColor.Blue)]

namespace CreClientTest

{
    
    public class Main_BlazeAPI : MelonMod
    {        
        internal static Sprite ButtonImage = null;
        internal static Sprite GhostImage = null;
        internal static Sprite MurderImage = null;
        internal static Sprite MicOn = null;
        internal static Sprite MicOff = null;

        
        public override void OnApplicationStart()
        {

            MelonCoroutines.Start(StartUiManagerInitIEnumerator());
        }
        public static IEnumerator StartUiManagerInitIEnumerator()
        {          
            while (UnityEngine.Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() == null) yield return null;
            QuickMenuInitialized();          
            Logs.LogGeneral("Menu's Initialized! :)", false);           
        }


        public static void QuickMenuInitialized()
        {          
            GameObject.Destroy(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners"));
            GameObject.Destroy(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/ThankYouCharacter"));         
            var CreClienTarget = new QMNestedButton("Menu_SelectedUser_Local", 2, -0.5f, "CCTarget", "Targeted Functions", "CCTarget", true);
            var MainMenu = new QMTabMenu("Opens CreClient", "CreClient", ButtonImage);
            var ExploitsMenu = new QMNestedButton(MainMenu, 2.5f, 0, "World Exploits", "World Cheats", "CreClient", true);
            var MurderExploits = new QMNestedButton(ExploitsMenu, 1f, 0f, "Murder Exploits", "Sorry Jar", "CreClient", true);
            var GhostExploits = new QMNestedButton(ExploitsMenu, 2f, 0f, "Ghost Exploits", "Sorry NoLife", "CreClient", true);
            var PrisonBreakExploits = new QMNestedButton(ExploitsMenu, 3f, 0f, "Prison Escape Exploits", "Sorry Ostinyo", "CreClient", true);
            var AmongUsExploits = new QMNestedButton(ExploitsMenu, 4f, 0f, "Among Us Exploits", "Sorry Jar", "CreClient", true);         
        }              
    }
}
