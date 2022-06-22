using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UnityEngine;
using MelonLoader;
using CreClientTest.MURDER;
using CreClientTest.Modules;
using CreClientTest.GHOST;
using VRC;
using PlagueButtonAPI;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.Core;
using VRC.SDKBase;
using CreClientTest.Settings;
using PlagueButtonAPI.Misc;
using PlagueButtonAPI.Controls;
using PlagueButtonAPI.Controls.Grouping;
using PlagueButtonAPI.Pages;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;
using VRC.DataModel;
using Il2CppSystem.Collections.Generic;
using System.Collections;

[assembly: MelonLoader.MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(CreClientTest.Main_PAPI), "CreClient", "1.0", " Crecross#9901", "")]
[assembly: MelonColor(ConsoleColor.Blue)]

namespace CreClientTest
{
    public class Main_PAPI : MelonMod
    {
        #region Variables
        public static bool FixBounds = false;
        internal static bool On = false;
        internal static Sprite ButtonImage = null;
        internal static Sprite GhostImage = null;
        internal static Sprite MurderImage = null;

        #endregion

        public override void OnApplicationStart()
        {
            if (!Directory.Exists("CreClient"))
            {
                Directory.CreateDirectory("CreClient");
                WebClient img = new WebClient();
                WebClient plg = new WebClient();
                WebClient jar = new WebClient();
                WebClient ghst = new WebClient();
                string JDir = (Environment.CurrentDirectory + "\\CreClient");
                string JFile = $"{JDir}\\JAR.png";
                string GDir = (Environment.CurrentDirectory + "\\CreClient");
                string GFile = $"{GDir}\\GHOST.png";
                string CCDir = (Environment.CurrentDirectory + "\\CreClient");
                string CCFile = $"{CCDir}\\CCButton.png";

                ghst.DownloadFileAsync(new Uri("https://iili.io/Y6xI5J.png"), GFile);
                jar.DownloadFileAsync(new Uri("https://iili.io/Y6xRxp.png"), JFile);
                img.DownloadFileAsync(new Uri("https://user-images.githubusercontent.com/29289083/143790629-efd6075b-29d8-489a-8087-b21400ac9d00.png"), CCFile);
            }
            //if (Directory.Exists("CreClient"))
            else
            {
                ButtonImage = (Environment.CurrentDirectory + "\\CreClient\\CCButton.png").LoadSpriteFromDisk();
                MurderImage = (Environment.CurrentDirectory + "\\CreClient\\JAR.png").LoadSpriteFromDisk();
                GhostImage = (Environment.CurrentDirectory + "\\CreClient\\GHOST.png").LoadSpriteFromDisk();               
            }
        }

        private System.Collections.Generic.Dictionary<string, Sprite> UserImages = new System.Collections.Generic.Dictionary<string, Sprite>();

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

                if (Input.GetKeyDown(KeyCode.Home))
                {
                    MethodsTwo.ForceClose();
                }
                if (Input.GetKeyDown(KeyCode.End))
                {
                    MethodsTwo.ForceRestart();
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    
                }
            }
        }
        private static IEnumerator WaitForVRCUI()
        {
            while (GameObject.Find("UserInterface/MenuContent/Screens") == null)
            {
                yield return null;
            }
            
            while (GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud") == null)
            {
                yield return null;
            }
            
            while (UnityEngine.Object.FindObjectOfType<QuickMenu>() == null)
            {
                yield return null;
            }
            
            yield break;
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {           
            if (sceneName == "ui")
            {
                ButtonAPI.OnInit += () =>
                {

                    Logs.LogSuccess("Thank you for using CreClient ->" + APIUser.CurrentUser.displayName, false);
                    var Page = new MenuPage("CreMenu", "CreClient");

                    new Tab(Page, "CreClient", ButtonImage);
                    var MurderMenu = new MenuPage("Murder Exploits", "Murder Exploits", false);
                    var InfoMenu = new MenuPage("Info Menu", "Information", false);
                    var MurderUtils = new ButtonGroup(MurderMenu, "MurderUtils");
                    var WorldExploitsBG = new ButtonGroup(Page, "World Exploits");

                    var InfoBG = new ButtonGroup(InfoMenu, "Information");
                    var MurderTPMenu = new MenuPage("Murder Teleport", "Murder Teleport", false);
                    var GrenadeMenu = new MenuPage("Grenade Menu", "Boom", false);
                    var GhostMenu = new MenuPage("Ghost Cheats", "Ghost Cheats", false);
                    var GhostUtils = new ButtonGroup(GhostMenu, "GhostUtils");
                    var RoomExplosionMenu = new MenuPage("Room Explosion", "Room Explosion", false);
                    var MurderRandomMenu = new MenuPage("Murder Random", "Misc", false);
                    var MurderAnimationsMenu = new MenuPage("Murder Animations", "Murder Animations", false);
                    var PlayerNodeMenu = new MenuPage("Player Nodes", "Player Node Manipulator", false);

                    var MurderTP = new ButtonGroup(MurderTPMenu, "", true, TextAnchor.UpperLeft);
                    var GrenadeGroup = new ButtonGroup(GrenadeMenu, "", true, TextAnchor.UpperLeft);
                    var MurderRandom = new ButtonGroup(MurderRandomMenu, "", true, TextAnchor.UpperLeft);
                    var MurderAnimations = new ButtonGroup(MurderAnimationsMenu, "", true, TextAnchor.UpperLeft);
                    var PlayerNode = new ButtonGroup(PlayerNodeMenu, "", true, TextAnchor.UpperLeft);

                    var RoomExplosion = new ButtonGroup(RoomExplosionMenu, "", true, TextAnchor.UpperLeft);
                    var MurderBring = new CollapsibleButtonGroup(MurderMenu, "Bring", "MurderBring");
                    var GhostBring = new ButtonGroup(GhostMenu, "", true, TextAnchor.UpperLeft);
                    var MurderRespawn = new CollapsibleButtonGroup(MurderMenu, "Respawn", "Murder Respawn!");
                    var RevolverU = new CollapsibleButtonGroup(MurderMenu, "RevolverUdon", "RevolverUdon");
                    var GameLogicU = new CollapsibleButtonGroup(MurderMenu, "GameLogicUdon", "GameLogicUdon");
                    var BearTrapU = new CollapsibleButtonGroup(MurderMenu, "BearTrapUdon", "BearTrapUdon");
                    var CameraU = new CollapsibleButtonGroup(MurderMenu, "CameraUdon", "CameraUdon");
                    var PickUpUtils = new CollapsibleButtonGroup(Page, "PickupUtils", "Pesky Pickups!");
                    var GeneralUtils = new CollapsibleButtonGroup(Page, "GeneralUtils", "Game Functions");
                    var Movement = new CollapsibleButtonGroup(Page, "Movement", "Weeeeeeeeee");
                    var SettingsG = new CollapsibleButtonGroup(Page, "CreSettings", "CreSettings");
                    var selectedUserGroup = new ButtonGroup(ButtonAPI.menuPageBase.transform.parent.Find("Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup"), "CreClientTarget");
                    var UserPage = new MenuPage("UserTestMenu_1", "User Menu");
                    var OptionsGroup = new ButtonGroup(UserPage, "Options");
                    var MurderAnimGroup = new ButtonGroup(MurderAnimationsMenu, "", true, TextAnchor.UpperLeft);
                    var PlayerNodeMenuGroup = new ButtonGroup(PlayerNodeMenu, "", true, TextAnchor.UpperLeft);
                    var GrenadeMenuGroup = new ButtonGroup(GrenadeMenu, "", true, TextAnchor.UpperLeft);






                    new SingleButton(WorldExploitsBG, "Murder Exploits", "Murder Exploits", () =>
                    {
                        MurderMenu.OpenMenu();
                    }, true, MurderImage);

                    new SingleButton(WorldExploitsBG, "Info Menu", "Information", () =>
                    {
                        InfoMenu.OpenMenu();
                    }, true, ButtonImage);

                    new SingleButton(GrenadeMenuGroup, "Gun Explosion", "Blammer", () =>
                    {
                        UdonMurder.targetedGun();
                    }, true, ButtonImage);

                    new SingleButton(GrenadeMenuGroup, "Gun Explosion Smoke", "Blammer", () =>
                    {
                        UdonMurder.targetedGunSmoke();
                    }, true, ButtonImage);

                    /*new SingleButton(GrenadeGroup, "Explode Random", "self explanatory", () =>
                    {
                        UdonMurderOp.ExplodeRandom();
                    }, true, ButtonImage);*/

                    


                    /*new SingleButton(GrenadeGroup, "Knife Explosion", "Explodes all knives in sequence", () =>
                    /*new SingleButton(GrenadeGroup, "Knife Explosion", "Explodes all knives in sequence", () =>
                    {
                        UdonMurder.BoomKnives();
                    }, true, ButtonImage);*/

                    new SingleButton(MurderUtils, "Teleport", "Murder Teleport", () =>
                    {
                        MurderTPMenu.OpenMenu();
                    }, true, ButtonImage);

                    new SingleButton(GrenadeMenuGroup, "Room Explosion", "Room Explosion", () =>
                    {
                        RoomExplosionMenu.OpenMenu();
                    }, true, ButtonImage);

                    new SingleButton(MurderUtils, "Grenade Menu", "Grenade Menu", () =>
                    {
                        GrenadeMenu.OpenMenu();
                    }, true, ButtonImage);

                    new SingleButton(MurderUtils, "Random", "Murder Random", () =>
                    {
                        MurderRandomMenu.OpenMenu();
                    }, true, ButtonImage);

                    new SingleButton(MurderUtils, "Animation", "Murder Animation", () =>
                    {
                        MurderAnimationsMenu.OpenMenu();
                    }, true, ButtonImage);

                    new SingleButton(SettingsG, "Update CreClient", "Manually Updates CreClient", () =>
                    {
                        MelonCoroutines.Start(Update.UpdateCC());
                    }, true, ButtonImage);

                    new SingleButton(InfoBG, "CreClient Discord", "Joins CreClient discord..Which you're supposed to be in it anyway if you have this mod :(", () =>
                    {
                        var ccDisc = "https://discord.gg/Tk9wJsK3A3";
                        Process.Start(ccDisc);
                    }, true, ButtonImage);

                    

                    /*new SingleButton(MurderUtils, "Player Node", "Player Node", () =>
                    {
                        PlayerNodeMenu.OpenMenu();
                    }, true, ButtonImage);*/

                    /*new SingleButton(SettingsG, "Update CreClientNoto", "Manually Updates CreClient", () =>
                    {
                        MelonCoroutines.Start(Update.UpdateCCNoto());
                    }, true, ButtonImage);

                    new SingleButton(SettingsG, "Update CreClient FreeLoader", "Manually Updates CreClient", () =>
                    {
                        MelonCoroutines.Start(Update.UpdateCCFreeLoader());
                    }, true, ButtonImage);*/

                    //NODES

                    new SingleButton(PlayerNodeMenuGroup, "Set Bystander", "Set Bystander For Yourself", () =>
                    {
                        MURDER.PlayerNode.Node0();
                    }, true, ButtonImage);


                    //Murder Animations

                    new ToggleButton(MurderAnimGroup, "No Blind", "Disables Blind Animation", "Enables Blind Animation", (val) =>
                    {
                        MURDER.MurderAnimations.SetNoBlindOn(val);

                    }).SetToggleState(true, false);

                    new SingleButton(MurderAnimGroup, "Lights Out", "Turns Lights Off", () =>
                    {
                        MURDER.MurderAnimations.LightsOut();
                    }, true, ButtonImage);

                    new SingleButton(MurderAnimGroup, "Lights On", "Turns Lights On", () =>
                    {
                        MURDER.MurderAnimations.LightsOn();
                    }, true, ButtonImage);

                    /*new SingleButton(MurderAnimGroup, "Use All", "Use All Triggers", () =>
                    {
                        MethodsTwo.UseAll();
                    }, true, ButtonImage);*/


                    //Ghost Stuff


                    new SingleButton(GhostUtils, "Give Money", "Im not broke", () =>
                    {
                        UdonGhost.GibMoney();
                    }, true, GhostImage);
                    new SingleButton(GhostUtils, "Give Clues", "Folders", () =>
                    {
                        BringGhost.Clues();
                    }, true, GhostImage);
                    new SingleButton(GhostUtils, "Collect all clues", "Folders", () =>
                    {
                        BringGhost.CollectAllClues();
                    }, true, GhostImage);
                    new SingleButton(GhostUtils, "Bring Keys", "Give Keys", () =>
                    {
                        BringGhost.BringKeys();
                    }, true, GhostImage);

                    new SingleButton(GhostUtils, "Bring Money", "Give Money", () =>
                    {
                        BringGhost.BringMoney();
                    }, true, GhostImage);


                    new SingleButton(WorldExploitsBG, "Ghost Exploits", "Ghost Exploits", () =>
                    {
                        GhostMenu.OpenMenu();
                    }, true, GhostImage);

                    /*new SingleButton(WorldExploitsBG, "Update CreClient", "Forcefully Updates CC", () =>
                    {
                        Update.UpdateCC();
                    }, true, ButtonImage);


                    
                    new SingleButton(GhostBring, "Uzi", "Brings Uzi", () =>
                    {
                        BringGhost.BringUzi();
                    }, true, ButtonImage);
                    //Ghost Stuff


                    /*new SingleButton(selectedUserGroup, "Target", "Targets Player", () =>
                    {
                        Shared.TargetPlayer = Util
                    sP.GetCurrentlySelectedPlayer();
                    }, true, ButtonImage);*/

                    new SingleButton(MurderTP, "STEALTH RESPAWN", "Teleports you to random lobby spot as if you died", () =>
                    {
                        TPMurder.StealthTP();

                    }, true, ButtonImage);


                   
                    
                    /*
                    new SingleButton(WorldExploitsBG, "TP TO CRE", "<3", () =>
                    {
                        var me = Player.prop_Player_0;
                        Player cre = UtilsP.TargetCre();
                        me.transform.position = cre.transform.position;
                    }, true, ButtonImage);*/





                    /*new SingleButton(selectedUserGroup, "Targeted Knife", "Shank!", () =>
                    {
                        UdonMurder.TargetedKnife();
                        
                    }, true, ButtonImage);*/

                    /*new SingleButton(selectedUserGroup, "Set Bystander", "Pull em in", () =>
                    {
                        PlayerNode.Node();
                    }, true, ButtonImage);*/

                    //ROOM EXPLOSION

                    new SingleButton(RoomExplosion, "Grand Hall", "Boom", () =>
                    {
                        RoomNade.GrandHall();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Kitchen", "Boom", () =>
                    {
                        RoomNade.Kitchen();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Cellar", "Randomly blows up two locations..\nSo spam it", () =>
                    {
                        RoomNade.CellarRand();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Top Hall", "Randomly blows up three locations..\nSo spam it", () =>
                    {
                        RoomNade.TopHallRand();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Library", "Randomly blows up two locations..\nSo spam it", () =>
                    {
                        RoomNade.LibraryRand();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Bedroom", "Boom", () =>
                    {
                        RoomNade.Bedroom();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Dining Room", "Boom", () =>
                    {
                        RoomNade.DiningRoom();
                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Bathroom", "Boom", () =>
                    {
                        RoomNade.Bathroom();

                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Lounge", "Boom", () =>
                    {
                        RoomNade.Lounge();

                    }, true, ButtonImage);

                    new SingleButton(RoomExplosion, "Detective", "Boom", () =>
                    {
                        RoomNade.Detective();

                    }, true, ButtonImage);




                    //ROOM EXPLOSION ^^

                    //SELECTED USER GROUP


                    new SingleButton(selectedUserGroup, "Targeted Explosion", "Boom", () =>
                    {
                        UdonMurder.TargetedBoom();
                    }, true, ButtonImage);

                    new SingleButton(selectedUserGroup, "Targeted Smoke", "Boom", () =>
                    {
                        UdonMurder.TargetedBoomSmoke();
                    }, true, ButtonImage);

                    new SingleButton(selectedUserGroup, "Targeted Gun", "Arrivederci", () =>
                    {
                        MurderRotate.TargetedGun();
                    }, true, ButtonImage);

                    new SingleButton(selectedUserGroup, "RespawnGun", "Arrivederci", () =>
                    {
                        RespawnMurder.RespawnLuger();
                    }, true, ButtonImage);

                    new SingleButton(selectedUserGroup, "Targeted Knife", "Arrivederci", () =>
                    {
                        UdonMurder.TargetedKnife();
                    }, true, ButtonImage);



                    new SingleButton(selectedUserGroup, "Teleport To", "Teleport to Player", () =>
                    {
                        var Me = Player.prop_Player_0;
                        Player targetPlayer = UtilsP.GetCurrentlySelectedPlayer();
                        Me.transform.position = targetPlayer.transform.position + new Vector3(0f, 0.1f, 0f);
                    }, true, ButtonImage);

                    new SingleButton(selectedUserGroup, "Bear Trap Roulette", "", () =>
                    {
                        UdonMurder.BearTrapTriforce();
                    }, true, ButtonImage);


                    /*new SingleButton(selectedUserGroup, "Bear Trap Triforce Spam", "Triforce", () =>
                    {
                        UdonMurder.bearTrapTriSpam();
                    }, true, ButtonImage);

                    new ToggleButton(selectedUserGroup, "BearTrapSpam", "Toggle Off", "Toggle On", (val) =>
                    {

                        UdonMurder.TrapSpamToggle(val);


                    }).SetToggleState(false, true);*/



                    //SELECTED USER GROUP ^^

                    /*new SingleButton(selectedUserGroup, "Knife Shield", "Virgil", () =>
                    {
                        UdonMurder.KnifeShield();
                    }, true, ButtonImage);*/

                    /*new ToggleButton(MurderUtils, "Knife Shield", "Toggle Off", "Toggle On", (val) =>
                    {

                        UdonMurder.KSON(val);


                    }).SetToggleState(false, true);*/





                    new SingleButton(MurderBring, "Revolver", "Brings Revolver", () =>
                    {
                        BringMurder.Revolver();
                    }, true, ButtonImage);


                    new SingleButton(MurderBring, "Luger", "Brings Luger", () =>
                    {
                        BringMurder.Luger();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "Shotty", "Brings Shotty", () =>
                    {
                        BringMurder.Shotty();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "Grenade", "Brings Grenade", () =>
                    {
                        BringMurder.Grenade();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "Smoke", "Brings Smoke", () =>
                    {
                        BringMurder.Smoke();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "Knife", "Brings Knife", () =>
                    {
                        BringMurder.Knife();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "BearTrap 1", "Brings BearTrap", () =>
                    {
                        BringMurder.BT1();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "BearTrap 2", "Brings BearTrap", () =>
                    {
                        BringMurder.BT2();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "BearTrap 3", "Brings BearTrap", () =>
                    {
                        BringMurder.BT3();
                    }, true, ButtonImage);

                    new SingleButton(MurderBring, "Camera", "Brings Camera", () =>
                    {
                        BringMurder.Cam();
                    }, true, ButtonImage);


                    new SingleButton(MurderRespawn, "Revolver", "Respawns Revolver", () =>
                    {
                        RespawnMurder.RespawnRevolver();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "Luger", "Respawns Luger", () =>
                    {
                        RespawnMurder.RespawnLuger();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "Shotty", "Respawns Shotty", () =>
                    {
                        RespawnMurder.RespawnShotgun();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "Grenade", "Respawns Grenade", () =>
                    {
                        RespawnMurder.RespawnGrenade();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "Smoke", "Respawns Smoke", () =>
                    {
                        RespawnMurder.RespawnSmoke();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "Knife", "Respawns Knife", () =>
                    {
                        RespawnMurder.RespawnKnife();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "BearTrap 1", "Respawns BearTrap", () =>
                    {
                        RespawnMurder.RespawnBearTrap1();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "BearTrap 2", "Respawns BearTrap", () =>
                    {
                        RespawnMurder.RespawnBearTrap2();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "BearTrap 3", "Respawns BearTrap", () =>
                    {
                        RespawnMurder.RespawnBearTrap3();
                    }, true, ButtonImage);

                    new SingleButton(MurderRespawn, "Camera", "Respawns Camera", () =>
                    {
                        RespawnMurder.RespawnBearTrap3();
                    }, true, ButtonImage);


                    //MURDER TP

                    new SingleButton(MurderTP, "TP TO MURDER", "TP to startroom", () =>
                    {
                        Player.prop_Player_0.transform.position = new Vector3(0.5379f, 1.3f, 116.2955f);
                    }, true, ButtonImage);


                    new SingleButton(MurderTP, "TP TO REVOLVER", "Lmao, Muda Muda", () =>
                    {
                        UdonMurder.TPToRev();
                    }, true, ButtonImage);

                    new SingleButton(MurderTP, "TP TO BED", "Shleep", () =>
                    {
                        Player.prop_Player_0.transform.position = new Vector3(-10.1f, 3.5f, 129.2f);
                    }, true, ButtonImage);

                    //MURDER TP

                    new ToggleButton(MurderUtils, "Fix Bounds", "Do you hear that..?", "Listen Close", (val) =>
                    {
                        FixBoundsM.SetFixBoundsActive(val);

                    }).SetToggleState(false, true);
                   

                    /*new ToggleButton(MurderUtils, "Knife Shield", "SHING?", "SHIIING", (val) =>
                    {
                        MelonCoroutines.Start(MurderRotate.KnifeShield());



                    }).SetToggleState(false, true);*/

                    new SingleButton(GeneralUtils, "TP TO INF", "For ppl who sit on head", () =>
                    {
                        var me = Player.prop_Player_0;
                        me.transform.position = new Vector3(0f, 99980000f, 0f);

                    }, true, ButtonImage);


                    new ToggleButton(Movement, "Fly", "Toggle Off", "Toggle On", (val) =>
                    {


                        SettingsP.Fly = true;

                        
                        

                    }).SetToggleState(false, true);

                    new ToggleButton(Movement, "NoClip", "Toggle Off", "Toggle On", (val) =>
                    {

                        //Flight.NC(val);
                        //Flight.GoStart();


                    }).SetToggleState(false, true);

                    new SingleButton(Movement, "Fly Speed +", "Fly Speed +", () =>
                    {
                        //Flight.FlyPlus();
                        
                    }, true, ButtonImage);

                    new SingleButton(Movement, "Fly Speed -", "Fly Speed -", () =>
                    {
                        //Flight.FlyMinus();

                    }, true, ButtonImage);

                    new SingleButton(MurderRandom, "Crash Portal Door", "Check the detective door lmao", () =>
                    {
                        MethodsTwo.SpawnDetectivePortal();
                        MelonLogger.Msg("Thanks Kirai Chan#8315");
                    }, true, ButtonImage);

                    new SingleButton(MurderRandom, "Trap Scramble", "Tp's a trap to a random doorway", () =>
                    {
                        TPMurder.BT1S();
                        MelonLogger.Msg("Traps Scrambled!");
                    }, true, ButtonImage);

                    new SingleButton(MurderRandom, "Murder Crash Portal", "Murder 4 Crash Portal lmao", () =>
                    {
                        MethodsTwo.SpawnDetectivePortalInF();
                        MelonLogger.Msg("Thanks Kirai Chan#8315");
                    }, true, ButtonImage);

                    new SingleButton(GeneralUtils, "Restart Game", "This game BUGGIN", () =>
                    {
                        MethodsTwo.ForceRestart();

                    }, true, ButtonImage);

                    new SingleButton(GeneralUtils, "Close Game", "VRC sucks at closing", () =>
                    {
                        MethodsTwo.ForceClose();

                    }, true, ButtonImage);

                    new SingleButton(GeneralUtils, "Give Hop", "Krelena wont give me hop :(", () =>
                    {
                        MethodsTwo.ForceJump();

                    }, true, ButtonImage);

                    new SingleButton(GeneralUtils, "Delete Portals", "No portals :(", () =>
                    {
                        MethodsTwo.DeletePortals();

                    }, true, ButtonImage);


                    new SingleButton(PickUpUtils, "Drop All", "Put it down now :(", () =>
                    {
                        MethodsTwo.DropPickups();
                    }, true, ButtonImage);

                    new SingleButton(PickUpUtils, "Respawn Pickups", "For the retards who bring all", () =>
                    {
                        MethodsTwo.RespawnPickups();
                    }, true, ButtonImage);

                    new SingleButton(PickUpUtils, "Bring All", "If you're a retard", () =>
                    {
                        MethodsTwo.BringPickups();
                    }, true, ButtonImage);
                                       

                    new SingleButton(RevolverU, "Bang", "It's Highnoon", () =>
                    {
                        UdonMurder.Fire();
                    }, true, ButtonImage);

                    new ToggleButton(RevolverU, "Gold Gun", "Me when patron :)", "Me no patron :(", (val) =>
                    {
                        UdonMurder.IsGoldGunLoop(val);
                    }).SetToggleState(false, true);

                    new SingleButton(GameLogicU, "Abort", "Aborts Game", () =>
                    {
                        UdonMurder.Abort();
                    }, true, ButtonImage);

                    new SingleButton(GameLogicU, "Start", "Starts Game", () =>
                    {
                        UdonMurder.Start();
                    }, true, ButtonImage);

                    new SingleButton(GameLogicU, "MurderWin", "Force Murderer Win", () =>
                    {
                        UdonMurder.WinMurderer();
                    }, true, ButtonImage);

                    new SingleButton(GameLogicU, "BystanderWin", "Force Bystander Win", () =>
                    {
                        UdonMurder.WinBystander();
                    }, true, ButtonImage);

                    new SingleButton(GameLogicU, "KillAll", "KILL KILLLLL", () =>
                    {
                        UdonMurder.Killall();
                    }, true, ButtonImage);

                    new SingleButton(BearTrapU, "TrapSpam", "SQUEAK", () =>
                    {
                        UdonMurder.Trigger();
                    }, true, ButtonImage);

                    new SingleButton(CameraU, "Flash", "FLASH, LIGHT, LIGHT", () =>
                    {
                        UdonMurder.Flash();
                    }, true, ButtonImage);

                };


            }

        }
    }

}
