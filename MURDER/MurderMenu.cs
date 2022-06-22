using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreClient;
using UnityEngine;
using MelonLoader;
using VRC.Udon;
using System.Collections;
using CreClient.Settings;
using CreClient.MURDER;
using CreClient.Modules;
using VRC;
using VRC.Core;
using WTFBlaze;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC.SDKBase;
using VRC.UI.Elements.Menus;

namespace CreClient.MURDER
{
    public class MurderMenu
    {
        public static QMNestedButton MurderAnim;
        public static QMNestedButton MurderBring;
        public static QMNestedButton MurderRespawn;
        public static QMNestedButton MurderTeleport;
        public static QMNestedButton MurderGrenade;
        public static QMNestedButton MurderRandom;
        public static QMNestedButton RevolverUdon;
        public static QMNestedButton godMurder;



        public static QMToggleButton MurderFixBound;

        public static QMToggleButton GoldenGun;
        public static QMToggleButton Bloat;


        public static QMSingleButton StealthRespawn;
        public static QMSingleButton TptoRev;
        public static QMSingleButton TptoMurder;
        public static QMSingleButton TptoBed;
        public static QMSingleButton CrashPortalDoor;
        public static QMSingleButton CrashPortal;
        public static QMSingleButton TrapScramble;

        //Animation
        public static QMSingleButton LightsOut;
        public static QMSingleButton LightsOn;
        public static QMSingleButton OpenDoors;
        public static QMSingleButton CloseDoors;
        public static QMSingleButton LockDoors;
        public static QMSingleButton UnlockDoors;

        //Bring
        public static QMSingleButton Revolver;
        public static QMSingleButton Luger;
        public static QMSingleButton Shotgun;
        public static QMSingleButton Nade;
        public static QMSingleButton Smoke;
        public static QMSingleButton BT1;
        public static QMSingleButton BT2;
        public static QMSingleButton BT3;
        public static QMSingleButton Knife;
        public static QMSingleButton Camera;

        //Loops 





        public static void MurderMenuInitialized()
        {
            new QMSlider(Main_BlazeAPI.annoyanceMenu, -750, -740, "Annoyance Distance", 0.1f, 55, UdonMurder.distance, delegate (float f)
            {
                UdonMurder.distance = f;
                
            });
            new QMSlider(Main_BlazeAPI.annoyanceMenu, -750, -840, "Annoyance Speed", 0.1f, 55, UdonMurder.speed, delegate (float f)
            {
                UdonMurder.speed = f;

            });
            /*new QMSlider(Main_BlazeAPI.annoyanceMenu, -750, -340, "Stroheim X", 0.1f, 55, UdonMurder.rotateX, delegate (float f)
            {
                UdonMurder.rotateX = f;

            });
            new QMSlider(Main_BlazeAPI.annoyanceMenu, -750, -440, "Stroheim Y", 0.1f, 55, UdonMurder.rotateY, delegate (float f)
            {
                UdonMurder.rotateY = f;

            });
            new QMSlider(Main_BlazeAPI.annoyanceMenu, -750, -540, "Stroheim Z", 0.1f, 55, UdonMurder.rotateZ, delegate (float f)
            {
                UdonMurder.rotateZ = f;

            });*/
            var StroX = new QMSingleButton(Main_BlazeAPI.annoyanceMenu, 1, 0, "StroX", delegate
            {
                UdonMurder.StroRotate();
            }, "+90 X", true);
            var StroY = new QMSingleButton(Main_BlazeAPI.annoyanceMenu, 2, 0, "StroY+", delegate
            {
                //UdonMurder.pitchUp = true;
            }, "+90 Y", true);
            var StroZ = new QMSingleButton(Main_BlazeAPI.annoyanceMenu, 3, 0, "StroY-", delegate
            {
                //UdonMurder.pitchDown = true;
            }, "-90 Y", true);

            //Bring
            MurderBring = new QMNestedButton(Main_BlazeAPI.MurderExploits, 4, 0, "Bring", "Bring Menu", "CreClient", true);
            MurderRespawn = new QMNestedButton(Main_BlazeAPI.MurderExploits, 4, 0.5f, "Respawn", "Respwan Menu", "CreClient", true);
            MurderGrenade = new QMNestedButton(Main_BlazeAPI.MurderExploits, 2, 0.5f, "Grenade", "Grenade Menu", "CreClient", true);
            MurderRandom = new QMNestedButton(Main_BlazeAPI.MurderExploits, 3, 0, "Random", "Teleport Menu", "CreClient", true);
            RevolverUdon = new QMNestedButton(Main_BlazeAPI.MurderExploits, 1f, 3.5f, "RevolverU", "Revolver Events", "CreClient", true);
            MurderAnim = new QMNestedButton(Main_BlazeAPI.MurderExploits, 3, 0.5f, "Animation", "Animations Menu", "CreClient", true);
            MurderTeleport = new QMNestedButton(Main_BlazeAPI.MurderExploits, 2, 0, "Teleport", "Teleport Menu", "CreClient", true); 
            godMurder = new QMNestedButton(Main_BlazeAPI.MurderExploits, 3, -0.5f, "<color=#FF0000>GOD</color>", "<color=#FF0000>GOD MENU</color>", "CreClient", true);
            var GameLogicUdon = new QMNestedButton(Main_BlazeAPI.MurderExploits, 2, 3.5f, "GameLogicU", "GameLogic Events", "CreClient", true);
            #region Bring
            Revolver = new QMSingleButton(MurderBring, 1, 0, "Revolver", delegate
            {
                BringMurder.Revolver();
            }, "Brings Revolver");
            Luger = new QMSingleButton(MurderBring, 2, 0, "Luger", delegate
            {
                BringMurder.Luger();
            }, "Brings Luger");
            Shotgun = new QMSingleButton(MurderBring, 3, 0, "Shotgun", delegate
            {
                BringMurder.Shotty();
            }, "Brings Shotgun");
            Nade = new QMSingleButton(MurderBring, 4, 0, "Nade", delegate
            {
                BringMurder.Grenade();
            }, "Brings Nade");
            Smoke = new QMSingleButton(MurderBring, 1, 1, "Smoke", delegate
            {
                BringMurder.Smoke();
            }, "Brings Smoke");
            BT1 = new QMSingleButton(MurderBring, 2, 1, "BearTrap 1", delegate
            {
                BringMurder.BT1();
            }, "Brings BearTrap");
            BT2 = new QMSingleButton(MurderBring, 3, 1, "BearTrap 2", delegate
            {
                BringMurder.BT2();
            }, "Brings BearTrap");
            BT3 = new QMSingleButton(MurderBring, 4, 1, "BearTrap 3", delegate
            {
                BringMurder.BT3();
            }, "Brings BearTrap");
            Knife = new QMSingleButton(MurderBring, 1, 2, "Knife", delegate
            {
                BringMurder.Knife();
            }, "Brings BearTrap");
            Camera = new QMSingleButton(MurderBring, 4, 2, "Camera", delegate
            {
                BringMurder.Cam();
            }, "Brings Camera");
            #endregion

            #region Respawn
            var respRevolver = new QMSingleButton(MurderRespawn, 1, 0, "Revolver", delegate
            {
                RespawnMurder.RespawnRevolver();
            }, "Respawns Revolver");
            var resLuger = new QMSingleButton(MurderRespawn, 2, 0, "Luger", delegate
            {
                RespawnMurder.RespawnLuger();
            }, "Respawns Luger");
            var resShotgun = new QMSingleButton(MurderRespawn, 3, 0, "Shotgun", delegate
            {
                RespawnMurder.RespawnShotgun();
            }, "Respawns Shotgun");
            var resNade = new QMSingleButton(MurderRespawn, 4, 0, "Nade", delegate
            {
                RespawnMurder.RespawnGrenade();
            }, "Respawns Nade");
            var resSmoke = new QMSingleButton(MurderRespawn, 1, 1, "Smoke", delegate
            {
                RespawnMurder.RespawnSmoke();
            }, "Respawns Smoke");
            var resBT1 = new QMSingleButton(MurderRespawn, 2, 1, "BearTrap 1", delegate
            {
                RespawnMurder.RespawnBearTrap1();
            }, "Respawns BearTrap");
            var resBT2 = new QMSingleButton(MurderRespawn, 3, 1, "BearTrap 2", delegate
            {
                RespawnMurder.RespawnBearTrap2();
            }, "Respawns BearTrap");
            var resBT3 = new QMSingleButton(MurderRespawn, 4, 1, "BearTrap 3", delegate
            {
                RespawnMurder.RespawnBearTrap3();
            }, "Respawns BearTrap");
            var resKnife = new QMSingleButton(MurderRespawn, 1, 2, "Knife", delegate
            {
                RespawnMurder.RespawnKnife();
            }, "Respawns BearTrap");
            var resCamera = new QMSingleButton(MurderRespawn, 4, 2, "Camera", delegate
            {
                RespawnMurder.RespawnCamera();
            }, "Respawns Camera");
            #endregion

            var GunEx = new QMSingleButton(MurderGrenade, 1, 0, "Gun Explosion", delegate
            {
                UdonMurder.TargetedGun();
            }, "BOOMY GUN");
            var GunExSmoke = new QMSingleButton(MurderGrenade, 2, 0, "Sun Smoke", delegate
            {
                UdonMurder.TargetedGunSmoke();
            }, "SMOKEY GUN");
            var RoomExplosion = new QMNestedButton(MurderGrenade, 3, 0, "Room Explosion", "Room Explosion", "CreClient", true);
            var tNade = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 1, 0, "Targeted Nade", delegate
            {
                UdonMurder.TargetedNadeNLag();
            }, "Killer Queen");
            var tSNade = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 3, 0, "Targeted Smoke", delegate
            {
                UdonMurder.TargetedSMNadeNLag();
            }, "Fard");

 

            //Animation
            
            LightsOn = new QMSingleButton(MurderAnim, 1, 0, "Lights On", delegate
            {
                MurderAnimations.LightsOn();
            }, "Cuz the lights is off");
            LightsOut = new QMSingleButton(MurderAnim, 2, 0, "Lights Off", delegate
            {
                MurderAnimations.LightsOn();
            }, "Cuz the lights is on");

            var noBlind = new QMToggleButton(MurderAnim, 1, 1, "No Blind", delegate
            {
                GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = false;
                GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = false;
                Logs.LogGeneral("I can see! I can FIGHT", false);
            }, delegate
            {
                GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = true;
                GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = true;
                Logs.LogGeneral("Blinded by your light!", false);
            }, "No Blind");
            
            
            var Bloat = new QMSingleButton(MurderAnim, 2, 1, "No Bloat", delegate
            {
                GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = false;
                GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = false;
                GameObject.Find("Patreon Credits").active = false;
                GameObject.Find("Patreon Canvas").active = false;
                GameObject.Find("Game Logic/Signs/Credits Canvas").active = false;
                GameObject.Find("Game Logic/Signs/Credits Canvas (1)").active = false;        
            }, "Disables Useless GameObjects");

            var noDoors = new QMToggleButton(MurderAnim, 1, 2, "No Doors", delegate
            {
                MurderAnimations.NoDoors();
            }, delegate
            {
                MurderAnimations.YesDoors();
            }, "Disables Doors");



            //Revolver

            GoldenGun = new QMToggleButton(RevolverUdon, 1f, 0f, "Gold Gun", delegate
            {
                UdonMurder.GoldGunCor = MelonCoroutines.Start(UdonMurder.GoldenGunLoop());
                Logs.LogGeneral("Gun Golded", false);
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.GoldGunCor);
                Logs.LogGeneral("Gun UnGolded", false);
            }, "Golds Gun For You");
            MurderFixBound = new QMToggleButton(Main_BlazeAPI.MurderExploits, 1f, 0f, "Fix Bounds", delegate
            {
                MelonCoroutines.Start(FixBoundsM.FixBoundsOn());

            }, delegate
            {
                MelonCoroutines.Start(FixBoundsM.FixBoundsOff());
            }, "Fix Bounds");


            //GameLogic
            
            //Snake



            var abort = new QMSingleButton(GameLogicUdon, 1, 0, "Abort", delegate
            {
                UdonMurder.Abort();
            }, "Aborts the game");
            var start = new QMSingleButton(GameLogicUdon, 2, 0, "Start", delegate
            {
                UdonMurder.Start();
            }, "Starts the game");
            var mWin = new QMSingleButton(GameLogicUdon, 3, 0, "MurderWin", delegate
            {
                UdonMurder.WinMurderer();
            }, "Force Murder Win");
            var bWin = new QMSingleButton(GameLogicUdon, 4, 0, "BystanderWin", delegate
            {
                UdonMurder.WinBystander();
            }, "Force Bystander Win");
            var kAll = new QMSingleButton(GameLogicUdon, 1, 1, "KillAll", delegate
            {
                UdonMurder.Killall();
            }, "Kills All");
            var startLoop = new QMToggleButton(GameLogicUdon, 2, 1, "Auto Start", delegate
            {
                UdonMurder.StartLoopCor = MelonCoroutines.Start(UdonMurder.StartLoop());

            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.StartLoopCor);
            }, "Fix Bounds");



            //Teleport

            StealthRespawn = new QMSingleButton(MurderTeleport, 1, 0, "STEALTH RESPAWN", delegate
            {
                TPMurder.StealthTP();
                Logs.LogGeneral("Very Sneaky" + APIUser.CurrentUser.displayName, false);
            }, "Teleports you back to a random death spot as if you died!");
            TptoRev = new QMSingleButton(MurderTeleport, 2, 0, "TP to Revolver", delegate
            {
                UdonMurder.TPToRev();
            }, "Teleport to revolver");
            TptoMurder = new QMSingleButton(MurderTeleport, 3, 0, "TP to Murder", delegate
            {
                //TPMurder.ScatteredSpawn();
                Player.prop_Player_0.transform.position = new Vector3(0.5379f, 1.3f, 116.2955f);
            }, "Teleport to main room");
            TptoBed = new QMSingleButton(MurderTeleport, 4, 0, "TP to Bed", delegate
            {
                Player.prop_Player_0.transform.position = new Vector3(-10.1f, 3.5f, 129.2f);
            }, "Teleport to Bed");


            //Random
            CrashPortal = new QMSingleButton(MurderRandom, 1, 0, "Murder Crash Portal", delegate
            {
                MethodsTwo.SpawnDetectivePortalInF();
                Logs.LogGeneral("Thanks Kirai Chan#8315", false);
            }, "Murder Crash Portal lmao");
            CrashPortalDoor = new QMSingleButton(MurderRandom, 2, 0, "M-Crash Portal Door", delegate
            {
                MethodsTwo.SpawnDetectivePortal();
                Logs.LogGeneral("Thanks Kirai Chan#8315", false);
            }, "Murder Crash Portal lmao");
            TrapScramble = new QMSingleButton(MurderRandom, 3, 0, "Trap Scramble", delegate
            {

                Logs.LogGeneral("Let the games begin", false);
            }, "Spawns Bear Traps in Random Doorways");
       
        }
       
        public static void SecretInitM()
        {
            var shoot = new QMToggleButton(MurderRandom, 1, 1, "SHOOT", delegate
            {
                UdonMurder.shootCor = MelonCoroutines.Start(UdonMurder.GunShoot());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.shootCor);
            }, "NO SHOOT");
            var SnakeUdon = new QMNestedButton(Main_BlazeAPI.MurderExploits, 3, 3.5f, "SnakeBoxU", "SnakeBox Events", "CreClient", true);
            var releaseS = new QMSingleButton(SnakeUdon, 1, 0, "Release Snake", delegate
            {
                UdonBehaviour[] array = GameObject.Find("SnakeDispenser").GetComponents<UdonBehaviour>();
                array[0].SendCustomNetworkEvent(0, "DispenseSnake");
            }, "Release Snake");
            
            var resetS = new QMSingleButton(SnakeUdon, 2, 0, "Reset Snake", delegate
            {
                UdonBehaviour[] array = GameObject.Find("SnakeDispenser").GetComponents<UdonBehaviour>();
                array[1].SendCustomNetworkEvent(0, "Respawn");
            }, "Release Snake");
            var murderSnake = new QMToggleButton(SnakeUdon, 3, 0, "Solid Snake", delegate
            {
                UdonMurder.MurderSnakeLoopCor = MelonCoroutines.Start(UdonMurder.MurderSnake());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.MurderSnakeLoopCor);
                RespawnMurder.RespawnLuger();
            }, "Snake (NOW WITH A LUGER!)");

            var infAmmo = new QMToggleButton(Main_BlazeAPI.MurderExploits, 2, 1, "Infinite Ammo", delegate
            {
                UdonMurder.InfAmmoCor = MelonCoroutines.Start(UdonMurder.InfiniteAmmo());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.InfAmmoCor);
            }, "Infinite Ammo");
            var laserRev = new QMToggleButton(Main_BlazeAPI.MurderExploits, 1, 1, "Laser Revolver", delegate
            {
                GameObject.Find("Game Logic/Weapons/Revolver/Recoil Anim/Recoil/Laser Sight").active = true;
            }, delegate
            {
                GameObject.Find("Game Logic/Weapons/Revolver/Recoil Anim/Recoil/Laser Sight").active = false;
            }, "Laser Revolver");
            OpenDoors = new QMSingleButton(MurderAnim, 3, 0, "Open Doors", delegate
            {
                MurderAnimations.OpenDoors();
            }, "Opens Doors");
            CloseDoors = new QMSingleButton(MurderAnim, 4, 0, "Close Doors", delegate
            {
                MurderAnimations.CloseDoors();
            }, "Close Doors");
            LockDoors = new QMSingleButton(MurderAnim, 4, 1, "Lock Doors", delegate
            {
                MurderAnimations.LockDoors();
            }, "Locks Doors");
            UnlockDoors = new QMSingleButton(MurderAnim, 3, 1, "Unlock Doors", delegate
            {
                MurderAnimations.UnlockDoors();
            }, "Unlocks Doors");
            var tarGun = new QMToggleButton(Main_BlazeAPI.TargetedMurder, 2, 0, "Targeted Gun", delegate
            {
                MurderRotate.TarGun = MelonCoroutines.Start(MurderRotate.RotateGun());
            }, delegate
            {
                MelonCoroutines.Stop(MurderRotate.TarGun);
                RespawnMurder.RespawnLuger();
            }, "Why you got the gun pointing at me Ugleahh");
            var tarCam = new QMToggleButton(Main_BlazeAPI.TargetedMurder, 4, 0, "Targeted Cam", delegate
            {
                MurderRotate.TarCam = MelonCoroutines.Start(MurderRotate.RotateCam());
            }, delegate
            {
                MelonCoroutines.Stop(MurderRotate.TarCam);
            }, "Why you pointing the cam at me Ugleahh");
            var fingerBomb = new QMToggleButton(Main_BlazeAPI.MurderExploits, 4, 1, "Finger Bomb", delegate
            {
                UdonMurder.fbombCor = MelonCoroutines.Start(UdonMurder.FingerBomb());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.fbombCor);
            }, "Point of death");

            var bystanderSet = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 4, 1f, "Set Bystander", delegate
            {
                UdonMurder.BystanderSet();
            }, "Sets Bystander", true);

            var murdererSet = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 4, 1.5f, "Set Murderer", delegate
            {
                UdonMurder.MurdererSet();
            }, "Sets Murderer", true);
            var detectiveSet = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 4, 2, "Set Detective", delegate
            {
                UdonMurder.DetectiveSet();
            }, "Kills Player", true);
            var KillSet = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 4, 2.5f, "Kill", delegate
            {
                UdonMurder.KillSet();
            }, "Kills Player", true);
            
            var esF = new QMToggleButton(Main_BlazeAPI.MurderExploits, 3, 1, "Everything Shall Freeze", delegate
            {
                UdonMurder.esFCor = MelonCoroutines.Start(UdonMurder.EverythingShallFreeze());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.esFCor);
            }, "Everything shall freeze");
            var trapGun = new QMToggleButton(Main_BlazeAPI.MurderExploits, 1, 2, "Trap Gun", delegate
            {
                UdonMurder.TrapGunCor = MelonCoroutines.Start(UdonMurder.TrapGun());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.TrapGunCor);
            }, "Anyone but you will trigger an explosion on the gun");

            var esFT = new QMToggleButton(Main_BlazeAPI.TargetedMurder, 1, 1, "Everything Shall Freeze Targeted", delegate
            {
                UdonMurder.esFTCor = MelonCoroutines.Start(UdonMurder.EverythingShallFreezeT());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.esFTCor);
            }, "Everything shall freeze Targeted");

            var bbT = new QMToggleButton(Main_BlazeAPI.TargetedMurder, 3, 1, "Bear Trap Triforce Spam", delegate
            {
                UdonMurder.bttCor = MelonCoroutines.Start(UdonMurder.BearTrapTriforceS());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.bttCor);
            }, "Bear Trap Triforce Spam");

            var beartrapTriforce = new QMSingleButton(Main_BlazeAPI.TargetedMurder, 2, 1, "Bear Trap Triforce", delegate
            {
                UdonMurder.BearTrapTriforce();
            }, "Spawn Beartraps on target");

            var roleLoop = new QMToggleButton(Main_BlazeAPI.TargetedMurder, 1, 2, "Role Death Loop", delegate
            {
                UdonMurder.roleloopCor = MelonCoroutines.Start(UdonMurder.RoleLoop());
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.roleloopCor);
            }, "Resurrection, then death..The never ending cycle");

            var stroHeim = new QMToggleButton(Main_BlazeAPI.MurderExploits, 4, 2, "Stroheim Mode", delegate
            {               
                UdonMurder.StroheimCor = MelonCoroutines.Start(UdonMurder.StroheimMode());
                UdonMurder.spamCorL = MelonCoroutines.Start(UdonMurder.SpamShoot());               
            }, delegate
            {
                MelonCoroutines.Stop(UdonMurder.StroheimCor);
                MelonCoroutines.Stop(UdonMurder.spamCorL);
                RespawnMurder.RespawnLuger();
                
            }, "If you've watched Jojo, you know");
        }
    }
}
