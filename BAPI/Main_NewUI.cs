using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using MelonLoader;
using CreClientTest.Modules;
using VRC;
using KiraiMod.WingAPI;
using KiraiMod.WingAPI.RawUI;
using CreClientTest.Modules;
using CreClientTest.MURDER;


[assembly: MelonLoader.MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(CreClientTest.Main_NewUI), "CreClient", "1.0", " Crecross#0544")]
[assembly: MelonColor(ConsoleColor.Blue)]

namespace CreClientTest
{
    public class Main_NewUI : MelonMod
    { 
       public override void OnApplicationStart()
        {
            WingAPI.OnWingInit += new System.Action<Wing.BaseWing>(wing =>
            {
                
                
                WingPage page = wing.CreatePage("CreClient");

                
                WingPage PickUpUtils = page.CreateNestedPage("PickUpUtils", 3);
                WingPage Move = page.CreateNestedPage("Movement", 1);
                WingPage Utils = page.CreateNestedPage("Utils", 2);
                WingPage MMenu = page.CreateNestedPage("Murder Menu", 0);


                WingPage MBring = MMenu.CreateNestedPage("Murder Bring", 0);
                WingPage MRespawn = MMenu.CreateNestedPage("Murder Respawn", 1);
                WingPage MUdon = MMenu.CreateNestedPage("Murder Udon", 2);
                WingPage MiscM2 = MMenu.CreateNestedPage("Misc M 2", 3);

                WingPage MBringP = MBring.CreateNestedPage("Primary", 1);
                WingPage MBringS = MBring.CreateNestedPage("Secondary", 2);

                WingPage MRespawnP = MRespawn.CreateNestedPage("Primary", 1);
                WingPage MRespawnS = MRespawn.CreateNestedPage("Secondary", 2);


                WingPage RevolverU = MUdon.CreateNestedPage("RevolverU", 0);
                WingPage GameLogicU = MUdon.CreateNestedPage("GameLogicU", 1);
                WingPage BearTrapsU = MUdon.CreateNestedPage("BearTrapsU", 2);
                WingPage CameraU = MUdon.CreateNestedPage("CameraU", 3);


                MRespawnP.CreateButton("Resawn Rev", 0, delegate
                {
                    RespawnMurder.RespawnRevolver();
                });
                CameraU.CreateButton("Flash", 0, delegate
                {
                    UdonMurder.Flash();
                });
                MRespawnP.CreateButton("Respawn Lug1", 1, delegate
                {
                    RespawnMurder.RespawnLuger();
                });
                
                MRespawnP.CreateButton("Resawn Shotty", 3, delegate
                {
                    RespawnMurder.RespawnShotgun();
                });
                MRespawnP.CreateButton("Resawn Knife", 4, delegate
                {
                    RespawnMurder.RespawnKnife();
                });
                MRespawnS.CreateButton("Resawn Trap 1", 0, delegate
                {
                    RespawnMurder.RespawnBearTrap1();
                });
                MRespawnS.CreateButton("Resawn Trap 1", 0, delegate
                {
                    RespawnMurder.RespawnBearTrap1();
                });
                MRespawnS.CreateButton("Resawn Trap 2", 1, delegate
                {
                    RespawnMurder.RespawnBearTrap2();
                });
                MRespawnS.CreateButton("Resawn Trap 3", 2, delegate
                {
                    RespawnMurder.RespawnBearTrap3();
                });
                MRespawnS.CreateButton("Respawn Camera", 3, delegate
                {
                    RespawnMurder.RespawnCamera();
                });
                GameLogicU.CreateButton("Abort", 0, delegate
                {
                    UdonMurder.Abort();
                });
                BearTrapsU.CreateButton("TrapSpam", 0, delegate
                {
                    UdonMurder.Trigger();
                });
                GameLogicU.CreateButton("StartGame", 1, delegate
                {
                    UdonMurder.Start();
                });
                GameLogicU.CreateButton("MurderWin", 2, delegate
                {
                    UdonMurder.WinMurderer();
                });
                GameLogicU.CreateButton("BystanderWin", 3, delegate
                {
                    UdonMurder.WinBystander();
                });
                GameLogicU.CreateButton("KillAll", 4, delegate
                {
                    UdonMurder.Killall();
                });
                PickUpUtils.CreateButton("RespawnAll", 0, delegate
                {
                    MethodsTwo.RespawnPickups();
                });
                PickUpUtils.CreateButton("ForcePicks", 1, delegate
                {
                    MethodsTwo.RespawnPickups();
                });
                PickUpUtils.CreateButton("DropAll", 2, delegate
                {
                    MethodsTwo.DropPickups();
                });
                MBringP.CreateButton("Revolver", 0, delegate
                {
                    BringMurder.Revolver();
                });
                MBringP.CreateButton("Grenade", 2, delegate
                {
                    BringMurder.Grenade();
                });
                MRespawnP.CreateButton("RespawnGrenade", 2, delegate
                {
                    RespawnMurder.RespawnGrenade();
                });

                MBringP.CreateButton("Luger 1", 1, delegate
                {
                    BringMurder.Luger();
                });

                MBringP.CreateButton("Smoke", 5, delegate
                {
                    BringMurder.Smoke();
                });

                MRespawnP.CreateButton("RespawnSmoke", 5, delegate
                {
                    RespawnMurder.RespawnSmoke();
                });

                MBringP.CreateButton("Shotty", 3, delegate
                {
                    BringMurder.Shotty();
                });
                MBringS.CreateButton("Camera", 3, delegate
                {
                    BringMurder.Cam();
                });
                MBringP.CreateButton("Knife", 4, delegate
                {
                    BringMurder.Knife();
                });
                MBringS.CreateButton("BearTrap 1", 0, delegate
                {
                    BringMurder.BT1();
                });
                MBringS.CreateButton("BearTrap 2", 1, delegate
                {
                    BringMurder.BT2();
                });
                MBringS.CreateButton("BearTrap 3", 2, delegate
                {
                    BringMurder.BT3();
                });
                Utils.CreateButton("Force Restart", 0, delegate
                {
                    MethodsTwo.ForceRestart();
                });
                Utils.CreateButton("Force Close", 1, delegate
                {
                    MethodsTwo.ForceClose();
                });
                Utils.CreateButton("Force Jump", 2, delegate
                {
                    MethodsTwo.ForceJump();
                });
                Utils.CreateButton("Delete Portals", 3, delegate
                {
                    MethodsTwo.DeletePortals();
                });
                RevolverU.CreateButton("Golds Gun", 0, delegate
                {
                    UdonMurder.GoldGun();
                    
                });
                RevolverU.CreateButton("Un-Golds Gun", 1, delegate
                {
                    UdonMurder.UnGoldsYourGun();
                });
                RevolverU.CreateButton("BANG", 2, delegate
                {
                    UdonMurder.Fire();
                });
            
                MMenu.CreateButton("Crash Portal", 5, delegate
                {
                    MethodsTwo.SpawnDetectivePortal();
                    MelonLogger.Msg("Thanks Kirai Chan#8315");
                });
                
                MMenu.CreateButton("TP TO MURDER", 3, delegate
                {

                    Player.prop_Player_0.transform.position = new Vector3(0.5379f, 1.3f, 116.2955f);

                }); MMenu.CreateButton("TP TO REVOLVER", 4, delegate
                {
                    UdonMurder.TPToRev();

                });
                //WingToggle toggle = page.CreateToggle("Flight", 0, UnityEngine.Color.green, UnityEngine.Color.red, false, new System.Action<bool>(state => Modules.Flight.State = state));
            });
       }
        public static int i = 0;
    }
    
           
} 

           
