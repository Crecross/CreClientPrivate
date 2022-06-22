/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using MelonLoader;
using UnhollowerBaseLib;
using CreClientTest.Modules;
using CreClientTest.Settings;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;
using CreClientTest.Manager;



namespace CreClientTest
{
    /*public class Main : MelonMod
    {
        public static QMNestedButton CreMenu;
        public static QMNestedButton UdonMenu;
        public static QMToggleButton ItemOrbit;
        public static QMNestedButton MurderMenu;
        public static QMNestedButton _PickupMenu;
        public static QMNestedButton MBringMenu;
        public static QMNestedButton MiscMurder;
        public static QMNestedButton UtilsMenu;
        public static QMSingleButton TargetButton;
        public static QMNestedButton respawnMenu;
        public static QMNestedButton MRespawnMenu;
        public static QMSingleButton Target;
        public static QMToggleButton _espButton;
        public static QMNestedButton ESPMenu;

        public static QMNestedButton MRevolverMenu;
        public static QMNestedButton MLuger1Menu;
        public static QMNestedButton MLuger2Menu;
        public static QMNestedButton MBearTrapsMenu;
        public static QMNestedButton MGrenadeMenu;
        public static QMNestedButton MGameLogicMenu;
        public static QMNestedButton MKnifeAnnoyanceMenu;
        public static QMNestedButton MSnakeBoxMenu;
        public static QMNestedButton MCameraMenu;
        public static QMNestedButton UserSpecificsMenu;

        public QMToggleButton _freezePickups;


        


        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(StartUiManagerInitIEnumerator());
            
           

        }
        private IEnumerator StartUiManagerInitIEnumerator()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return null;

            
            VRChat_OnUiManagerInit();

        }
       

        public static void VRChat_OnUiManagerInit()
        {
            
            CreMenu = new QMNestedButton("ShortcutMenu", 5, 1, "CreClient", "Creclient by Crecross#0544", Color.cyan, Color.white, Color.cyan, Color.yellow);
            


            MurderMenu = new QMNestedButton(CreMenu, 1, 0, "Murder\nShit", "Cre make Murder 4\ngo brrrrr", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MBringMenu = new QMNestedButton(MurderMenu, 1, 0, "Bring\nItems", "Cre make Murder 4\ngo brrrrr", Color.cyan, Color.white, Color.cyan, Color.yellow);
            UdonMenu = new QMNestedButton(CreMenu, 4, 0, "Udon Shit", "eeeee", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MiscMurder = new QMNestedButton(MurderMenu, 3, 0, "Misc\nMurder", "Random Murder Garbage", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MRespawnMenu = new QMNestedButton(MurderMenu, 2, 0, "Respawn\nItems", "Cre make Murder 4\ngo brrrrr", Color.cyan, Color.white, Color.cyan, Color.yellow);
            _PickupMenu = new QMNestedButton(CreMenu, 2, 0, "Pickup\nUtils", "Objects go brrr", Color.cyan, Color.white, Color.cyan, Color.yellow);
            UtilsMenu = new QMNestedButton(CreMenu, 3, 0, "Utility", "Functions", Color.cyan, Color.white, Color.cyan, Color.yellow);
            ESPMenu = new QMNestedButton(UtilsMenu, 4, 1, "ESP MENU", "SEE ALL", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MRevolverMenu = new QMNestedButton(MiscMurder, 1, 0, "Revolver", "Revolver Udon", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MLuger1Menu = new QMNestedButton(MiscMurder, 2, 0, "Luger", "Luger Udon", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MLuger2Menu = new QMNestedButton(MiscMurder, 3, 0, "Luger", "Luger Udon", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MBearTrapsMenu = new QMNestedButton(MiscMurder, 4, 0, "Bear Traps", "Bear Traps Udon", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MGameLogicMenu = new QMNestedButton(MiscMurder, 1, 1, "GameLogic", "GameLogic Udon", Color.cyan, Color.white, Color.cyan, Color.yellow);
            MSnakeBoxMenu = new QMNestedButton(MiscMurder, 4, 1, "SnakeBox", "SnakeBox Udon", Color.cyan, Color.white, Color.cyan, Color.yellow);
            UserSpecificsMenu = new QMNestedButton("UserInteractMenu", 3, 3, "Targeted\nFunctions", "Obvious", Color.cyan, Color.white, Color.cyan, Color.yellow);

            _espButton = new QMToggleButton(ESPMenu, 1, 0, "ESP\nOn",
               delegate () { Shared.modules.esp.SetState(true); },
               "ESP\nOff", delegate () { Shared.modules.esp.SetState(false); }, "ESP");

            

            new QMSingleButton(MRevolverMenu, 1, 0, "Golds Gun", delegate ()
            {
                MurderUdon.GoldGun();
            }, "When patreon");

            new QMSingleButton(MGameLogicMenu, 4, 2, "Bystander", delegate ()
            {
                PlayerNode.Node();
            }, "When patreon");

            new QMSingleButton(MRevolverMenu, 2, 0, "Un-Golds Gun", delegate ()
            {
                MurderUdon.UnGoldsYourGun();
            }, "When Non-patreon");

            new QMSingleButton(MRevolverMenu, 3, 0, "Shoot", delegate ()
            {
                MurderUdon.Fire();
            }, "Friendly Fire!");
            
            new QMSingleButton(MRevolverMenu, 1, 1, "QuickFire", delegate ()
            {
                MurderUdon.TargetedFire();
            }, "Fastest Hands in VRC");

            new QMToggleButton(MRevolverMenu, 4, 0, "Gold Gun\nLoop", delegate ()
            {
                //MurderUdon.goldGunLoop = true;
                MelonCoroutines.Start(MurderUdon.GoldGunLoopp());
                
            }, "OFF", delegate ()
            {
                MelonCoroutines.Stop(MurderUdon.GoldGunLoopp());
                //MurderUdon.goldGunLoop = false;
                
            }, "Gold Gun\nLoop", null, null);

            new QMToggleButton(CreMenu, 0, 1, "NoClip", delegate ()
            {
                //MurderUdon.goldGunLoop = true;
                Flight.Enable();

            }, "OFF", delegate ()
            {
                Flight.Disable();
                //MurderUdon.goldGunLoop = false;

            }, "Gold Gun\nLoop", null, null);

            new QMToggleButton(MiscMurder, 3, 2, "Knife\nShield", delegate ()
            {
                //MurderUdon.goldGunLoop = true;
                Exploits.KShield = true;

            }, "OFF", delegate ()
            {
                Exploits.KShield = false;
                //MurderUdon.goldGunLoop = false;

            }, "Gold Gun\nLoop", null, null);

            new QMSingleButton(MBearTrapsMenu, 1, 0, "Bear Trap\nTriforce!", delegate ()
            {
                MurderUdon.BearTrapTriforce();
            }, "Target someone First");


            new QMSingleButton(UserSpecificsMenu, 2, 0, "Bear Trap\nTriforce!", delegate ()
            {
                MurderUdon.BearTrapTriforce();
            }, "Target someone First");

            new QMSingleButton(MSnakeBoxMenu, 1, 0, "ReleaseSnake!", delegate ()
            {
                MurderUdon.Snake();
            }, "SSSSSSS");

            new QMSingleButton(MSnakeBoxMenu, 2, 0, "RespawnSnake!", delegate ()
            {
                MurderUdon.SnakeRespawn();
            }, "SSSSSSS");

            new QMSingleButton(UserSpecificsMenu, 1, 0, "Targeted\nExplosion", delegate ()
            {
                Specifics.TargetedBoom();
            }, "Blows up targeted user");

            new QMSingleButton(MiscMurder, 2, 2, "No\nBlind", delegate ()
            {
                MurderUdon.NoBlind();
            }, "Cannot Be Blinded");

            new QMSingleButton(MGameLogicMenu, 2, 0, "Bystander\nWin", delegate ()
            {
                MurderUdon.WinBystander();
            }, "Force Bystander Victory");

            new QMSingleButton(MGameLogicMenu, 1, 0, "Murderer\nWin", delegate ()
            {
                MurderUdon.WinMurderer();
            }, "Force Murder Victory");

            new QMSingleButton(MGameLogicMenu, 3, 0, "AbortGame", delegate ()
            {
                MurderUdon.Abort();
            }, "Force Murder Victory");

            new QMSingleButton(MGameLogicMenu, 4, 0, "Start", delegate ()
            {
                MurderUdon.Start();
            }, "Start Game");

            new QMSingleButton(MGameLogicMenu, 1, 1, "Kill", delegate ()
            {
                MurderUdon.Kill();
            }, "Kills");

            new QMSingleButton(MGameLogicMenu, 2, 1, "Blind", delegate ()
            {
                MurderUdon.Blind();
            }, "Blinds");

            /*new QMSingleButton(CreMenu, 5, 1, "GetPos", delegate ()
            {
                MethodsTwo.GetPosition();
            }, "For Debugging");*/










/*new QMSingleButton(MurderMenu, 0, 0, "Teleport to murder game", delegate ()
{
    VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = new Vector3(0.5379f, 1.3f, 116.2955f);
    MelonLogger.Msg("Thank you W4rdus#5682");
}, "Tp to game", null, null);






new QMSingleButton(UdonMenu, 0, -1, "Udon\nNuke", delegate ()
{
    MethodsTwo.UdonNuke();
}, "Haha funny notorious");

new QMSingleButton(UtilsMenu, 4, 0, "Fox With\nVox", delegate ()
{
    MethodsTwo.ChangeAvatar("avtr_fd142aad-0cc1-4169-ae7e-d09c0944fd93");
}, "I'm a Fox with the fox and I got the game boxed");

new QMSingleButton(UdonMenu, 1, 0, "Boom", delegate ()
{
    Specifics.BoomBoom();
}, "Haha funny Event");

new QMSingleButton(_PickupMenu, 3, 1, "Bring\nPickups", delegate ()
{
    MethodsTwo.BringPickups();
}, "bring Pickups");

new QMToggleButton(_PickupMenu, 2, 0, "Item Orbit\nOn",
    delegate { Shared.modules.itemOrbit.SetState(true); }, "Item Orbit\nOff",
    delegate { Shared.modules.itemOrbit.SetState(false); },
    "Items rotate around your feet");

new QMSingleButton(_PickupMenu, 2, 1, "Drop\nPickups", delegate ()
{
    MethodsTwo.DropPickups();
}, "Drop Pickups");

new QMSingleButton(_PickupMenu, 4, 0, "Force\nPickups", delegate ()
{
    MethodsTwo.ForcePickups();
}, "Yoink Pickups");

new QMSingleButton(MBringMenu, 1, 0, "Revolver", delegate ()
{
    Specifics.Revolver();
}, "Gib revolver");

new QMSingleButton(MRespawnMenu, 1, 0, "Respawn\nRevolver", delegate ()
{
    Specifics.RespawnRevolver();
}, "Gib revolver");

new QMSingleButton(MBringMenu, 2, 0, "Luger", delegate ()
{
    Specifics.Luger();
}, "Gib Luger");

new QMSingleButton(MBringMenu, 1, 2, "BearTrap 1", delegate ()
{
    Specifics.BearTrap1();
}, "Gib Trap");

new QMSingleButton(MBringMenu, 2, 2, "BearTrap 2", delegate ()
{
    Specifics.BearTrap2();
}, "Gib Trap");

new QMSingleButton(MBringMenu, 3, 2, "BearTrap 3", delegate ()
{
    Specifics.BearTrap3();
}, "Gib Trap");

new QMSingleButton(MRespawnMenu, 1, 2, "Respawn\nBearTrap 1", delegate ()
{
    Specifics.RespawnBearTrap1();
}, "Gib Trap");

new QMSingleButton(MRespawnMenu, 2, 2, "Respawn\nBearTrap 2", delegate ()
{
    Specifics.RespawnBearTrap2();
}, "Gib Trap");

new QMSingleButton(MRespawnMenu, 3, 2, "Respawn\nBearTrap 3", delegate ()
{
    Specifics.RespawnBearTrap3();
}, "Gib Trap");

new QMSingleButton(MRespawnMenu, 2, 0, "Respawn\nLuger", delegate ()
{
    Specifics.RespawnLuger();
}, "Respawn Luger");

new QMSingleButton(MBringMenu, 3, 0, "Luger 2", delegate ()
{
    Specifics.Luger2();
}, "Gib Luger");

new QMSingleButton(MRespawnMenu, 3, 0, "Respawn\nLuger 2", delegate ()
{
    Specifics.RespawnLuger2();
}, "Respawn Luger 2");

new QMSingleButton(MBringMenu, 4, 0, "Grenade", delegate ()
{
    Specifics.Grenade();
}, "Gib Frag");

new QMSingleButton(MBringMenu, 4, 1, "CursedBomb", delegate ()
{
    Specifics.CBomb();
}, "Gib Cursed Bomb");

new QMSingleButton(MRespawnMenu, 4, 1, "Respawn\nCursed Bomb", delegate ()
{
    Specifics.RespawnCBomb();
}, "Respawn Cursed Bomb");

new QMSingleButton(MRespawnMenu, 4, 0, "Respawn\nGrenade", delegate ()
{
    Specifics.RespawnGrenade();
}, "Respawn Grenade");


new QMSingleButton(MBringMenu, 1, 1, "Knife", delegate ()
{
    Specifics.knife();
}, "Gib Luger");

new QMSingleButton(MRespawnMenu, 1, 1, "Respawn\nknife", delegate ()
{
    Specifics.RespawnKnife();
}, "Respawn Knife");

new QMSingleButton(MBringMenu, 2, 1, "Shotty", delegate ()
{
    Specifics.ShotGun();
}, "Gib Shotty");

new QMSingleButton(MRespawnMenu, 2, 1, "Respawn\nShotty", delegate ()
{
    Specifics.RespawnShotgun();
}, "Respawn Shotgun");

new QMSingleButton(MBringMenu, 3, 1, "Camera", delegate ()
{
    Specifics.Camera();
}, "Gib Camera");

new QMSingleButton(MRespawnMenu, 3, 1, "Respawn\nCamera", delegate ()
{
    Specifics.RespawnCamera();
}, "Respawn Camera");

new QMSingleButton(_PickupMenu, 4, 1, "Respawn\nPickups", delegate ()
{
    MethodsTwo.RespawnPickups();
}, "Respawn Pickups");

new QMSingleButton(UtilsMenu, 4, 2, "Delete\nPortals", delegate ()
{
    MethodsTwo.DeletePortals();
}, "Delete Portals");

new QMSingleButton(UtilsMenu, 1, 1, "Use\nAll", delegate ()
{
    MethodsTwo.UseAll();
}, "Use All");

new QMSingleButton(UtilsMenu, 1, 2, "Give\nHop", delegate ()
{
    MethodsTwo.ForceJump();
}, "Use All");

new QMSingleButton(UtilsMenu, 0, -1, "Force\nClose", delegate ()
{
    MethodsTwo.ForceClose();
}, "Force Close");

new QMSingleButton(UtilsMenu, 0, 0, "Force\nRestart", delegate ()
{
    MethodsTwo.ForceRestart();
}, "Force Restart");


new QMSingleButton("UserInteractMenu", 1, 3, "Target\nPlayer", delegate ()
{

    Shared.TargetPlayer = Utils.GetPlayer(QuickMenu.prop_QuickMenu_0.field_Private_APIUser_0.displayName);

    MelonLogger.Msg("Player Targeted!");
}, "Targets the player");

new QMSingleButton(CreMenu, 0, 0, "Untarget", delegate ()
{
    Shared.TargetPlayer = null;
    MelonLogger.Msg("Dropped Target!");
}, "Untarget");

new QMSingleButton("UserInteractMenu", 5, 3, "Teleport", delegate ()
{
    var Me = Player.prop_Player_0;
    Player targetPlayer = Shared.TargetPlayer;
    Me.transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.1f, 0f);
}, "TP to Player");

new QMSingleButton(UtilsMenu, 2, 1, "Launch\nDesktop Instance", delegate ()
{
    Process.Start(Environment.CurrentDirectory + "\\VRChat.exe");
    MelonLogger.Msg("Thank you W4rdus#5682");
}, "Opens another Desktop VRC Instance.\nWithout closing the current ", null, null);



}
}
}
*/