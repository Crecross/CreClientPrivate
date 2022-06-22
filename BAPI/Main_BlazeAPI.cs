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
using CreClient.Settings;
using System.IO;
using CreClient.Modules;
using CreClient.MURDER;
using CreClient.GHOST;
using TMPro;
using VRC.SDKBase;
using VRC.UI.Elements;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;
using WTFBlaze;
using Harmony;
using AzuraClient;
using System.Windows.Forms;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;

[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(CreClient.Main_BlazeAPI), "CreClient", "0.0.1", " Crecross#9901", "https://github.com/Crecross/CreClient/releases/download/Mods/CreClientTest.dll")]
[assembly: MelonColor(ConsoleColor.Blue)]

namespace CreClient

{

    public class Main_BlazeAPI : MelonMod
    {
        public static List<CreModule> Credules = new();
        public static QMTabMenu MainMenuPub;
        public static QMTabMenu MainMenuPriv;
        public static QMNestedButton CreClienTarget;
        public static QMNestedButton MurderExploits;
        public static QMNestedButton GhostExploits;
        public static QMNestedButton PrisonBreakExploits;
        public static QMNestedButton AmongUsExploits;
        public static QMNestedButton CreInfo;
        public static QMNestedButton GeneralUtils;
        public static QMSingleButton ForceClose;
        public static QMSingleButton Restart;
        public static QMSingleButton Hop;
        public static QMSingleButton DeletePortals;
        public static QMNestedButton ExploitsMenu;
        public static QMNestedButton Credits;
        public static QMSingleButton CCDisc;
        public static QMNestedButton PickupUtils;
        public static QMNestedButton Movement;
        public static QMSingleButton DropAll;
        public static QMSingleButton RespawnPicks;
        public static QMSingleButton BringAll;
        public static QMSingleButton MurderExploitsFake;
        public static QMToggleButton ToggleCC;
        public static QMSingleButton BruhTog;
        public static QMNestedButton TargetedGeneral;
        public static QMNestedButton TargetedMurder;
        public static QMNestedButton annoyanceMenu;
        public static QMSingleButton TeleportTo;
        public static QMSingleButton TargetPlayer;
        public static QMSingleButton MenuOn;
        public static QMSingleButton MenuOn1;
        public static QMNestedButton CCSettings;
        public static List<Utils.ModTag> Tags = new();
        public static List<Utils.ModTag> OtherBCUsers = new();

        internal static Sprite ButtonImage = null;
        internal static Sprite GhostImage = null;
        internal static Sprite MurderImage = null;
        //internal static Sprite MicOn = null;
        //internal static Sprite MicOff = null;
        internal static AudioClip BleeBlient = null;

        #region Watermark
        private static void Watermark()
        {
            Console.Clear();
            Logs.LogGeneral(" .--.             .--. .-.   _              .-. ", false);
            Logs.LogGeneral(": .--'           : .--': :  :_;            .' `.", false);
            Logs.LogGeneral(": :   .--.  .--. : :   : :  .-. .--. ,-.,-.`. .'", false);
            Logs.LogGeneral(": :__ : ..'' '_.': :__ : :_ : :' '_.': ,. : : : ", false);
            Logs.LogGeneral("`.__.':_;  `.__.'`.__.'`.__;:_;`.__.':_;:_; :_; ", false);
            if (APIUser.CurrentUser.id == "usr_d1db6b4d-ee0a-46f9-bd5e-82875fd5f661")
            {
                Logs.LogGeneral("Welcome back master Cretard", false);  
            }
            else if (APIUser.CurrentUser.id == "usr_d03c860d-a627-4ea0-a67e-b1fa280a85ec")
            {
                Logs.LogGeneral("Imagine trying to trick me into paying YOU to use Private (Crying Emoji)", false);
            }

            else if (APIUser.CurrentUser.id == "usr_6b514394-5717-4c9b-8868-2668b4bb01fb")
            {
                Logs.LogGeneral("Beanie low-key built like Wumpus", false);
            }
            else if (APIUser.CurrentUser.id == "usr_30504759-6d18-48ee-b81a-94109832f192")
            {
                Logs.LogGeneral("I present to you, the Roblox god..The Victor", false);
            }
            else if (APIUser.CurrentUser.id == "usr_05d7aa59-38f6-48c8-a2d7-051794350b7a")
            {
                Logs.LogGeneral("Trashy, Become a youtuber", false);
            }
            else if (APIUser.CurrentUser.id == "usr_c9830966-ec6a-4659-8d97-af0a215292c8")
            {
                Logs.LogGeneral("EAT ICECREAM AND GO TO SLEEEEP EEEEEEE!", false);
            }
            else if (APIUser.CurrentUser.id == "usr_ff2557d4-15c9-4cdb-baef-d22eb66c2c20")
            {
                Logs.LogGeneral("Welcome back Fingie Ingie", false);
            }
            else if (APIUser.CurrentUser.id == "usr_8e71ef66-8095-4b34-aa57-cf4d6e5a9708")
            {
                Logs.LogGeneral("I didnt want the fat chunky milk, I wanted the tall, skinny milk :(", false);
            }
            else if (APIUser.CurrentUser.id == "usr_6eb7f0ee-b71c-47a1-b37f-d2c6567a940e")//Mai
            {
                Logs.LogGeneral("Hey Mai, You're Cute ;)", false);
            }
            else if (APIUser.CurrentUser.id == "usr_9eab6470-f0df-4e7b-8d3b-e5491e0d731a")//Racer
            {
                Logs.LogGeneral("RACER OMG, CAN I HAVE AN AUTOGRAPH", false);
            }
            else if (APIUser.CurrentUser.id == "usr_ad2464ce-0b6b-4a95-8b2e-4fbccfad1a00")//TNE
            {
                Logs.LogGeneral("Yuh, alright, uh...Alright im now about to get on this bitch.." +
                    "Yes, how are you a quest user and then you're fucking on boys..? " +
                    "Yeah, you can barely even afford thaht fucking toy on your headset.." +
                    "Yeah, you know..I'm on your girl like a headrest.." +
                    "Yeah, and then I see you, then i'm like put him to bedrest.", false);
            }         
            else if (APIUser.CurrentUser.id == "usr_994f156a-9c2d-4885-8bb4-61c3195a5182")//Aliyyah
            {
                Logs.LogGeneral("Welcome back Cutie ;)", false);
            }
            else
            {
                Logs.LogGeneral("You are not Crecross, but carry on :(", false);
                Logs.LogGeneral("If you need your UserID it is " + APIUser.CurrentUser.id, false);
            }

        }
        #endregion
        #region FilePrep
        public static IEnumerator FilePrep()
        {         
            Logs.LogGeneral("CreClient files not located, creating now.", false);
            yield return new WaitForSeconds(4);
            Logs.LogGeneral("CreClient files created!", false);
            MethodsTwo.ForceRestart();
        }
        #endregion
        #region OnAppStart
        public override void OnApplicationStart()
        {
            Logs.LogGeneral("Checking for updates", false);
            SettingsP.UpdateCheck();
            Logs.LogGeneral("There are no Updates", false);
            if (!Directory.Exists("CreClient"))
            {
                Directory.CreateDirectory("CreClient");
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CreClient\\Images");
                MelonCoroutines.Start(FilePrep());
                
            }
            
            MelonCoroutines.Start(IDCheck.StartIDCheck());
            MelonCoroutines.Start(IDCheck.BlackListCheck());
            //MelonCoroutines.Start(StartUiManagerInitIEnumerator());
            //MelonCoroutines.Start(StartUiManagerInitIEnumeratorPrivate());

            Credules.Add(new MurderAnnoy());
            //ClassInjector.RegisterTypeInIl2Cpp<TouchStuff>();
        }
        #endregion
        private static IEnumerator WaitForHUD()
        {
            while (GameObject.Find("UserInterface/UnscaledUI/HudContent_Old/Hud") == null) yield return null;           
            yield break;
        }
        #region UIPub
        public static IEnumerator StartUiManagerInitIEnumerator()
        {
            while (UnityEngine.Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() == null) yield return null;    
            WaitForHUD();
            Logs.LogGeneral("Menu's Initialized! :)", false);
            QuickMenuInitialized();
            MurderMenu.MurderMenuInitialized();
            CreClient.Modules.Movement.QuickMenuInitializedMovement();           
            yield break;
        }
        #endregion
        #region UIPriv
        public static IEnumerator StartUiManagerInitIEnumeratorPrivate()
        {
            while (UnityEngine.Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() == null) yield return null;
            WaitForHUD();
            Logs.LogGeneral("Private Menu's Initialized! :)", false);
            QuickMenuInitializedPrivate();
            MurderMenu.MurderMenuInitialized();
            MurderMenu.SecretInitM();
            CreClient.MURDER.GodMurderMono.StartUniversal();
            CreClient.Modules.Movement.QuickMenuInitializedMovement();           
            yield break;         
        }
        #endregion
        public static void GetCurrentTime()
        {
            string time = DateTime.Now.ToString("F");
            Logs.LogGeneral(time, false);
        }
        public static AudioClip LoadAudioClip(string path)
        {
            return Resources.Load<AudioClip>(path);
        }
        #region Target
        public static void TargetButtons()
        {
            CreClienTarget = new QMNestedButton("Menu_SelectedUser_Local", 0, 0, "", "CreClient Target", "CreClient");
            CreClienTarget.GetMainButton().SetActive(false);
            var selfOpenBtn = UnityEngine.Object.Instantiate(
                AzuraClient.API.APIStuff.GetQuickMenuInstance().transform.Find("Container/Window/QMParent/Menu_SelectedUser_Local/Header_H1/RightItemContainer/Button_QM_Expand").gameObject,
                AzuraClient.API.APIStuff.GetQuickMenuInstance().transform.Find("Container/Window/QMParent/Menu_SelectedUser_Local/Header_H1/RightItemContainer"), false);
            selfOpenBtn.GetComponentInChildren<Image>().sprite = Utils.MakeSpriteFromImage(Utils.GetImageFromResources("CCButton.png"));
            selfOpenBtn.GetComponentInChildren<Image>().overrideSprite = Utils.MakeSpriteFromImage(Utils.GetImageFromResources("CCButton.png"));
            selfOpenBtn.GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            selfOpenBtn.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            selfOpenBtn.GetComponent<Button>().onClick.AddListener(new Action(() =>
            {
                Shared.TargetPlayer = UtilsP.GetSelectedUser()._player;
                CreClienTarget.OpenMe();
            }));

            var otherOpenBtn = UnityEngine.Object.Instantiate(
                AzuraClient.API.APIStuff.GetQuickMenuInstance().transform.Find("Container/Window/QMParent/Menu_SelectedUser_Remote/Header_H1/RightItemContainer/Button_QM_Expand").gameObject,
                AzuraClient.API.APIStuff.GetQuickMenuInstance().transform.Find("Container/Window/QMParent/Menu_SelectedUser_Remote/Header_H1/RightItemContainer"), false);
            otherOpenBtn.GetComponentInChildren<Image>().sprite = Utils.MakeSpriteFromImage(Utils.GetImageFromResources("CCButton.png"));
            otherOpenBtn.GetComponentInChildren<Image>().overrideSprite = Utils.MakeSpriteFromImage(Utils.GetImageFromResources("CCButton.png"));
            otherOpenBtn.GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            otherOpenBtn.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            otherOpenBtn.GetComponent<Button>().onClick.AddListener(new Action(() =>
            {
                Shared.TargetPlayer = UtilsP.GetSelectedUser()._player;
                CreClienTarget.OpenMe();
            }));
        }
        #endregion
        #region CREMPub
        public static void QuickMenuInitialized()
        {

            Watermark();
            GameObject.Destroy(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners"));
            //MainMenu = new QMNestedButton("Menu_Dashboard", 3f, -0.5f, "CreClient", "CreClient by Crecross#9901", "CreClient");
            //CreClienTarget = new QMNestedButton("Menu_SelectedUser_Local", 2.3f, -0.5f, "<color=#FF0000>CreTarget</color>", "Targeted Functions", "CCTarget", true);
            TargetButtons();
            var MainMenu = new QMTabMenu("Opens CreClient Private", "CreClient", Utils.MakeSpriteFromImage(Utils.GetImageFromResources("CCButton.png")));
            var ExploitsMenu = new QMNestedButton(MainMenu, 1.5f, 0, "World Exploits", "World Cheats", "CreClient", true);
            MurderExploits = new QMNestedButton(ExploitsMenu, 1f, 0f, "Murder Exploits", "Sorry Jar", "CreClient", true);
            GhostExploits = new QMNestedButton(ExploitsMenu, 2f, 0f, "Ghost Exploits", "Sorry NoLife", "CreClient", true);
            PrisonBreakExploits = new QMNestedButton(ExploitsMenu, 3f, 0f, "Prison Escape Exploits", "Sorry Ostinyo", "CreClient", true);
            AmongUsExploits = new QMNestedButton(ExploitsMenu, 4f, 0f, "Among Us Exploits", "Sorry Jar", "CreClient", true);


            PickupUtils = new QMNestedButton(MainMenu, 1f, 1f, "Pickup Utils", "GameObject Utilities", "CreClient");
            DropAll = new QMSingleButton(PickupUtils, 1, 0, "Drop All", delegate
            {
                MethodsTwo.DropPickups();
            }, "Drops Pickups");
            RespawnPicks = new QMSingleButton(PickupUtils, 2, 0, "Respawn All", delegate
            {
                MethodsTwo.RespawnPickups();
            }, "Respawns Pickips");
            BringAll = new QMSingleButton(PickupUtils, 3, 0, "Bring All", delegate
            {
                MethodsTwo.BringPickups();
            }, "Brings Pickups");

            annoyanceMenu = new QMNestedButton(ExploitsMenu, 1, 0.5f, "Murder Annoyance", "Float Values", "CreClient", true);
            GeneralUtils = new QMNestedButton(MainMenu, 2, 1, "General Utils", "Utility", "CreClient");

            new QMSingleButton(GeneralUtils, 1, 1, "Join Room ID", delegate
            {
                UtilsUI.InputPopup("Join World", "Input World ID", delegate (string result)
                {

                    if (UtilsUI.IsValidWorldID(result))
                    {
                        Networking.GoToRoom(result);
                        Logs.LogGeneral("Joining world", false);
                        return;
                    }
                    Logs.LogError("NOT VALID", false);
                });
            }, "<color=#FF0000>FORCE JOIN</color>", true);
            new QMSingleButton(GeneralUtils, 1, 1.5f, "Copy Room ID", delegate
            {
                Clipboard.SetText(RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.instanceId);

            }, "For Force Joining", true);
            ForceClose = new QMSingleButton(GeneralUtils, 1, 0, "<color=#FF0000>Force Close</color>", delegate
            {
                /*UtilsUI.AlertV2("Really, Close game?", "<color=#FF0000>Close</color>", delegate
                {
                    MethodsTwo.ForceClose();
                }, "<color=#50C878>No</color>", UtilsUI.HideCurrentPopUp);*/
                MethodsTwo.ForceClose();

            }, "Closes Game");
            Restart = new QMSingleButton(GeneralUtils, 2, 0, "<color=#FFA500>Force Restart</color>", delegate
            {
                /*UtilsUI.AlertV2("Really, Restart game?", "<color=#FF0000>Restart</color>", delegate
                {
                    MethodsTwo.ForceRestart();
                }, "<color=#50C878>No</color>", UtilsUI.HideCurrentPopUp);*/
                MethodsTwo.ForceRestart();

            }, "Restarts Game");
            Hop = new QMSingleButton(GeneralUtils, 3, 0, "Give Hop", delegate
            {
                MethodsTwo.ForceJump();
            }, "Krelena Won't give me hop..");
            DeletePortals = new QMSingleButton(GeneralUtils, 4, 0, "Delete portals", delegate
            {
                MethodsTwo.DeletePortals();
            }, "No Pormals :(");

            Movement = new QMNestedButton(MainMenu, 3, 1, "Movement", "Movement Menu", "CreClient");

            CreInfo = new QMNestedButton(MainMenu, 3.5f, 0, "Info", "CreClientInfo", "CreClient", true);
            CCDisc = new QMSingleButton(CreInfo, 1, 0, "CreClient Discord", delegate
            {
                Process.Start("https://discord.gg/Tk9wJsK3A3");

            }, "Joins the CreClient discord even though you should be in it anyway :(");
            var CCDiscme = new QMSingleButton(CreInfo, 2, 0, "Crecross Discord", delegate
            {
                Process.Start("discord:https://discordapp.com/users/708919057243570186/");
            }, "Add me!");



            CCSettings = new QMNestedButton(MainMenu, 4, 1, "Settings", "CreClient Settings", "CreClient");





            BruhTog = new QMSingleButton(PickupUtils, 4, 0, "Bruh", delegate
            {
                var bruh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var bruhRenderer = bruh.GetComponent<Renderer>();
                bruhRenderer.material.SetColor("_Color", UnityEngine.Color.red);
                GameObject.Instantiate(bruh);
                bruh.gameObject.SetActive(true);
                bruh.gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
            }, "Big Red Ball");

            TargetedGeneral = new QMNestedButton(CreClienTarget, 1, 0, "General", "General Target Functions", "CreClient");
            /*TargetPlayer = new QMSingleButton("Menu_SelectedUser_Local", 1.38f, -0.5f, "<color=#FF0000>Target Player</color>", delegate
            {
                //Shared.TargetPlayer = Utils.GetPlayer(QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0.displayName);
                Shared.TargetPlayer = UtilsP.GetCurrentlySelectedPlayer();

            }, "You must target to use targeted functions", true);*/
            TeleportTo = new QMSingleButton(TargetedGeneral, 1, 0, "Teleport", delegate
            {
                var Me = Player.prop_Player_0;
                Player targetPlayer = Shared.TargetPlayer;
                //Me.transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.1f, 0f);
                Me.transform.position = targetPlayer.transform.position + new Vector3(0, 0.3f, 0);



            }, "Teleports to player");


            TargetedMurder = new QMNestedButton(CreClienTarget, 2, 0, "Murder", "Target Murder Menu", "CreClient");

            MenuOn = new QMSingleButton(CCSettings, 1, 0, "Custom Menu 1", delegate
            {
                MelonCoroutines.Start(BehindScenes.TexturesQm());
                //MelonCoroutines.Start(BehindScenes.CreMenu());
            }, "Toggles Custom Menu");
            MenuOn1 = new QMSingleButton(CCSettings, 2, 0, "Custom Menu 2", delegate
            {
                MelonCoroutines.Start(BehindScenes.TexturesQm1());
                //MelonCoroutines.Start(BehindScenes.CreMenu());
            }, "Toggles Custom Menu");
            var MenuOn2 = new QMSingleButton(CCSettings, 3, 0, "Custom Menu 3", delegate
            {
                MelonCoroutines.Start(BehindScenes.TexturesQmHaunted());
                //MelonCoroutines.Start(BehindScenes.CreMenu());
            }, "Toggles Custom Menu, thanks AkumaChan!");


        }
        #endregion
        public static Text InvisTXT;
        public static GameObject InvisLabel;
        /*public static void Target()
        {
            var menu = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard");
            var target = new AzuraClient.API.QM.QMInfo(menu.transform, 100, -50, 350, 900, "Why you got the gun pointed at me Ugleahh?")
            {
                InfoText =
                    {
                        color = UnityEngine.Color.white,
                        supportRichText = true,
                        fontSize = 30,
                        fontStyle = UnityEngine.FontStyle.Normal,
                        alignment = TextAnchor.UpperRight
                    },
                InfoBackground =
                    {
                        color = new UnityEngine.Color(0, 0, 0, 0.65f),
                    }
            };


        }*/
        public static void QuickMenuInitializedPrivate()
        {
            
            Watermark();
            GameObject.Destroy(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners"));
            //MainMenu = new QMNestedButton("Menu_Dashboard", 3f, -0.5f, "CreClient", "CreClient by Crecross#9901", "CreClient");
            //CreClienTarget = new QMNestedButton("Menu_SelectedUser_Local", 2.3f, -0.5f, "<color=#FF0000>CreTarget</color>", "Targeted Functions", "CCTarget", true);
            TargetButtons();
            //Target();
            var MainMenu = new QMTabMenu("Opens CreClient Private", "CreClient", Utils.MakeSpriteFromImage(Utils.GetImageFromResources("CCButtonpriv.png")));
            var ExploitsMenu = new QMNestedButton(MainMenu, 1.5f, 0, "World Exploits", "World Cheats", "CreClient", true);
            MurderExploits = new QMNestedButton(ExploitsMenu, 1f, 0f, "Murder Exploits", "Sorry Jar", "CreClient", true);          
            GhostExploits = new QMNestedButton(ExploitsMenu, 2f, 0f, "Ghost Exploits", "Sorry NoLife", "CreClient", true);
            PrisonBreakExploits = new QMNestedButton(ExploitsMenu, 3f, 0f, "Prison Escape Exploits", "Sorry Ostinyo", "CreClient", true);
            AmongUsExploits = new QMNestedButton(ExploitsMenu, 4f, 0f, "Among Us Exploits", "Sorry Jar", "CreClient", true);


            PickupUtils = new QMNestedButton(MainMenu, 1f, 1f, "Pickup Utils", "GameObject Utilities", "CreClient");
            DropAll = new QMSingleButton(PickupUtils, 1, 0, "Drop All", delegate
            {
                MethodsTwo.DropPickups();
            }, "Drops Pickups");
            RespawnPicks = new QMSingleButton(PickupUtils, 2, 0, "Respawn All", delegate
            {
                MethodsTwo.RespawnPickups();
            }, "Respawns Pickips");
            BringAll = new QMSingleButton(PickupUtils, 3, 0, "Bring All", delegate
            {
                MethodsTwo.BringPickups();
            }, "Brings Pickups");
          
            annoyanceMenu = new QMNestedButton(ExploitsMenu, 1, 0.5f, "Murder Annoyance", "Float Values", "CreClient", true);
            GeneralUtils = new QMNestedButton(MainMenu, 2, 1, "General Utils", "Utility", "CreClient");

            new QMSingleButton(GeneralUtils, 1, 1, "Join Room ID", delegate
            {
                UtilsUI.InputPopup("Join World", "Input World ID", delegate (string result)
                {

                    if (UtilsUI.IsValidWorldID(result))
                    {
                        Networking.GoToRoom(result);
                        Logs.LogGeneral("Joining world", false);
                        return;
                    }
                    Logs.LogError("NOT VALID", false);
                });
            }, "<color=#FF0000>FORCE JOIN</color>", true);
            new QMSingleButton(GeneralUtils, 1, 1.5f, "Copy Room ID", delegate
            {
                Clipboard.SetText(RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.instanceId);

            }, "For Force Joining", true);
            ForceClose = new QMSingleButton(GeneralUtils, 1, 0, "<color=#FF0000>Force Close</color>", delegate
            {
                /*UtilsUI.AlertV2("Really, Close game?", "<color=#FF0000>Close</color>", delegate
                {
                    MethodsTwo.ForceClose();
                }, "<color=#50C878>No</color>", UtilsUI.HideCurrentPopUp);*/
                MethodsTwo.ForceClose();

            }, "Closes Game");
            Restart = new QMSingleButton(GeneralUtils, 2, 0, "<color=#FFA500>Force Restart</color>", delegate
            {
                /*UtilsUI.AlertV2("Really, Restart game?", "<color=#FF0000>Restart</color>", delegate
                {
                    MethodsTwo.ForceRestart();
                }, "<color=#50C878>No</color>", UtilsUI.HideCurrentPopUp);*/
                MethodsTwo.ForceRestart();

            }, "Restarts Game");
            Hop = new QMSingleButton(GeneralUtils, 3, 0, "Give Hop", delegate
            {
                MethodsTwo.ForceJump();
            }, "Krelena Won't give me hop..");
            DeletePortals = new QMSingleButton(GeneralUtils, 4, 0, "Delete portals", delegate
            {
                MethodsTwo.DeletePortals();
            }, "No Pormals :(");

            Movement = new QMNestedButton(MainMenu, 3, 1, "Movement", "Movement Menu", "CreClient");

            CreInfo = new QMNestedButton(MainMenu, 3.5f, 0, "Info", "CreClientInfo", "CreClient", true);
            CCDisc = new QMSingleButton(CreInfo, 1, 0, "CreClient Discord", delegate
            {
                Process.Start("https://discord.gg/Tk9wJsK3A3");

            }, "Joins the CreClient discord even though you should be in it anyway :(");
            var CCDiscme = new QMSingleButton(CreInfo, 2, 0, "Crecross Discord", delegate
            {
                Process.Start("discord:https://discordapp.com/users/708919057243570186/");
            }, "Add me!");


            
            CCSettings = new QMNestedButton(MainMenu, 4, 1, "Settings", "CreClient Settings", "CreClient");





            BruhTog = new QMSingleButton(PickupUtils, 4, 0, "Bruh", delegate
            {
                var bruh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var bruhRenderer = bruh.GetComponent<Renderer>();
                bruhRenderer.material.SetColor("_Color", UnityEngine.Color.red);
                GameObject.Instantiate(bruh);
                bruh.gameObject.SetActive(true);
                bruh.gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
            }, "Big Red Ball");

            TargetedGeneral = new QMNestedButton(CreClienTarget, 1, 0, "General", "General Target Functions", "CreClient");
            /*TargetPlayer = new QMSingleButton("Menu_SelectedUser_Local", 1.38f, -0.5f, "<color=#FF0000>Target Player</color>", delegate
            {
                //Shared.TargetPlayer = Utils.GetPlayer(QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0.displayName);
                Shared.TargetPlayer = UtilsP.GetCurrentlySelectedPlayer();

            }, "You must target to use targeted functions", true);*/
            TeleportTo = new QMSingleButton(TargetedGeneral, 1, 0, "Teleport", delegate
            {
                var Me = Player.prop_Player_0;
                Player targetPlayer = Shared.TargetPlayer;
                //Me.transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.1f, 0f);
                Me.transform.position = targetPlayer.transform.position + new Vector3(0, 0.3f, 0);



            }, "Teleports to player");


            TargetedMurder = new QMNestedButton(CreClienTarget, 2, 0, "Murder", "Target Murder Menu", "CreClient");

            MenuOn = new QMSingleButton(CCSettings, 1, 0, "Custom Menu 1", delegate
            {
                MelonCoroutines.Start(BehindScenes.TexturesQm());
                //MelonCoroutines.Start(BehindScenes.CreMenu());
            }, "Toggles Custom Menu");
            MenuOn1 = new QMSingleButton(CCSettings, 2, 0, "Custom Menu 2", delegate
            {
                MelonCoroutines.Start(BehindScenes.TexturesQm1());
                //MelonCoroutines.Start(BehindScenes.CreMenu());
            }, "Toggles Custom Menu");
            var MenuOn2 = new QMSingleButton(CCSettings, 3, 0, "Custom Menu 3", delegate
            {
                MelonCoroutines.Start(BehindScenes.TexturesQmHaunted());
                //MelonCoroutines.Start(BehindScenes.CreMenu());
            }, "Toggles Custom Menu, thanks AkumaChan!");


        }
        
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKey(KeyCode.LeftAlt))
                {
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        Process.Start("VRChat.exe", Environment.CommandLine);
                        OnApplicationQuit();
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    
                }
                if (Input.GetKeyDown(KeyCode.Home))
                {
                    MethodsTwo.ForceClose();
                }
                if (Input.GetKeyDown(KeyCode.End))
                {
                    MethodsTwo.ForceRestart();
                }
            }
        }
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
           
            /*string[] array = new string[]
                {
                    "You are not Crecross",
                    "Don't be Cretarded",
                    "Lost in the CreSauce",
                    "I am not CreCre",
                };
            Logs.LogGeneral(array[UnityEngine.Random.Range(0, array.Length)], false);*/
        }      
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if(sceneName == "Murder Nevermore")
            { 
                Logs.LogGeneral("[UNITY] Loaded Scene [" + sceneName + "]", false);
                Logs.LogGeneral("[IN MURDER]: Activating Murder Utilities!", false);               
            }
            else
            {          
                Logs.LogGeneral("[UNITY] Loaded Scene [" + sceneName + "]", false);
                
            }
            

            
            
        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            //Logs.LogSuccess("[UNITY] UnLoaded Scene [" + sceneName + "]", false);
        }
       

    }
    

}
