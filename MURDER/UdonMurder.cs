using System;
using System.Collections;
using System.Collections.Generic;
using CreClient.Settings;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC.UI.Elements.Menus;
using MelonLoader;
using VRC.Udon;
using VRCSDK2;
using VRC.SDK3.Components;
using UnhollowerBaseLib;
using Il2CppSystem;
using VRC.Core;
using UnityEngine.UI;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;
using VRC.Udon;

namespace CreClient.MURDER
{
    
    public class UdonMurder
    {
        public static object MurderSnakeLoopCor;
        public static object StartLoopCor;
        public static object TrapGunCor;
        public static object StroRotCor;
        public static object spamCorL;
        public static object InfAmmoCor;
        public static object esFCor;
        public static object esFTCor;
        public static object bttCor;
        public static object fbombCor;
        public static object roleloopCor;
        public static object StroheimCor;
        public static float speed = 0.8f;
        public static float distance = 5f;
        public static object GoldGunCor;
        public static GameObject BombObj;
        public static GameObject luger = GameObject.Find("Luger (0)");
        public static GameObject nade = GameObject.Find("Frag (0)");
        public static GameObject rev = GameObject.Find("Revolver");
        public static GameObject Shot = GameObject.Find("Shotgun (0)");
        public static GameObject game = GameObject.Find("Game Logic");
        public static GameObject snake = GameObject.Find("Game Logic/Snakes/Snake");
        public static UdonBehaviour selectedScript;

        public static void RunUdonEventTarget(string script)
        {
            VRCPlayer component = Shared.TargetPlayer.gameObject.GetComponent<VRCPlayer>();
            string value = component._player.ToString();
            for (int i = 0; i < 24; i++)
            {
                string name = "Player Node (" + i.ToString() + ")";
                string name2 = "Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + i.ToString() + ")/Player Name Text";
                bool flag = GameObject.Find(name2).GetComponent<Text>().text.Equals(value);
                bool flag2 = flag;
                if (flag2)
                {
                    UdonBehaviour component2 = GameObject.Find(name).GetComponent<UdonBehaviour>();
                    component2.SendCustomNetworkEvent(NetworkEventTarget.All, script);
                }
            }
        }
        //Targeted Gun Explosion
        public static void TargetedGun()
        {
            GameObject gameobjectNade = GameObject.Find("Frag (0)");
            GameObject gameobjectRev = GameObject.Find("Revolver");
            bool flag = gameobjectNade != null;
            if (flag)
            {
                bool flag2 = Networking.GetOwner(gameobjectNade) != Networking.LocalPlayer;
                if (flag2)
                {
                    Networking.SetOwner(Networking.LocalPlayer, gameobjectNade);
                }                
                gameobjectNade.gameObject.transform.position = new Vector3(gameobjectRev.gameObject.transform.position.x, gameobjectRev.gameObject.transform.position.y, gameobjectRev.gameObject.transform.position.z);
                gameobjectNade.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
            }
        }

        public static void TargetedNadeNLag()
        {
            GameObject gameObject = GameObject.Find("Frag (0)");
            bool flag = gameObject != null;
            if (flag)
            {
                bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                if (flag2)
                {
                    Networking.SetOwner(Networking.LocalPlayer, gameObject);
                }
                Player targetPlayer = Shared.TargetPlayer;
                gameObject.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
            }
        }
        public static void TargetedSMNadeNLag()
        {
            GameObject gameObject = GameObject.Find("Smoke (0)");
            bool flag = gameObject != null;
            if (flag)
            {
                bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                if (flag2)
                {
                    Networking.SetOwner(Networking.LocalPlayer, gameObject);
                }
                Player targetPlayer = Shared.TargetPlayer;
                gameObject.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
            }
        }
      
        public static IEnumerator EverythingShallFreeze()
        {
            while (true)
            {             
                GameObject gameObject = GameObject.Find("Frag (0)");
                Transform transform = gameObject.transform;
                bool flag = gameObject != null;
                if (flag)
                {
                    bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                    if (flag2)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject);
                    }
                    Player me = Player.prop_Player_0;
                    transform.transform.LookAt(me.field_Private_VRCPlayerApi_0.GetBonePosition((HumanBodyBones)10));
                    transform.transform.position = me.gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * speed) * distance, 0, Mathf.Cos(Time.time * speed) * distance);
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                    yield return new WaitForSeconds(0.1f);
                    if (me == null) { yield break; }
                }
            }
        }
        public static int rotateX = 0;
        public static int rotateY = 0;
        public static int rotateZ = 0;
        public static bool StoheimOn = false;
        
        public static IEnumerator StroheimMode()
        {      
            while(true)
            {
                GameObject gameObject = GameObject.Find("Luger (0)");
                GameObject sphere = new();
                Transform transform = gameObject.transform;
                bool exsists = gameObject != null;
                if (exsists)
                {
                    bool noOwnership = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                    if (noOwnership)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject);
                    }
                    gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
                    gameObject.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
                    //sphere.transform.parent = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.Head).transform;
                    sphere.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.Chest).position; //+ new Vector3(0,0,1);                   
                    sphere.name = "StroheimSphere";
                    //sphere.transform.localPosition = new Vector3(0,0,1);
                    sphere.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    transform.transform.parent = sphere.transform;
                    transform.transform.localPosition = new Vector3(0f, 0.005f, 0f);
                    //transform.transform.Rotate(rotateX, -90, rotateZ, Space.Self);
                    StroRotate();
                    yield return new WaitForSeconds(0.5f);
                }              
            }
        }
        public static IEnumerator MurderSnake()
        {
            while (true)
            {              
                GameObject sphere = new();
                Transform transform = luger.transform;
                bool exsists = luger != null;
                if (exsists)
                {
                    bool noOwnership = Networking.GetOwner(luger) != Networking.LocalPlayer;
                    if (noOwnership)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, luger);
                    }
                    luger.GetComponent<Collider>().attachedRigidbody.useGravity = false;
                    luger.GetComponent<Collider>().attachedRigidbody.isKinematic = false;
                    //sphere.transform.parent = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.Head).transform;
                    sphere.transform.position = snake.transform.position; //+ new Vector3(0,0,1);                   
                    sphere.name = "SnekSphere";
                    //sphere.transform.localPosition = new Vector3(0,0,1);
                    sphere.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    transform.transform.parent = sphere.transform;
                    transform.transform.localPosition = new Vector3(0f, 1f, 0f);                   
                    StroRotate();
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        public static IEnumerator TrapGun()
        {
            while (true)
            {
                Networking.SetOwner(Networking.LocalPlayer, rev);
                bool noOwnership = Networking.GetOwner(rev) != Networking.LocalPlayer;
                if (noOwnership)
                {
                    nade.transform.position = rev.transform.position;
                    nade.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                }
                yield return new WaitForSeconds(0.1f);
            }  
        }
        
        public static void StroRotate()
        {            
            {
                GameObject gameObject = GameObject.Find("Luger (0)");
                Transform transform = gameObject.transform;
                transform.transform.Rotate(90, 0, 0, Space.Self);
   
            }
            
        }
        public static IEnumerator SpamShoot()
        {
            while (true)
            {
                GameObject gameObject = GameObject.Find("Luger (0)");
                {
                    bool noOwnership = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                    if (noOwnership)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject);
                    }
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Fire");
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        public static IEnumerator EverythingShallFreezeT()
        {
            while (true)
            {
                GameObject gameObject = GameObject.Find("Frag (0)");
                Transform transform = gameObject.transform;
                bool flag = gameObject != null;
                if (flag)
                {
                    bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                    if (flag2)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject);
                    }
                    Player targetPlayer = Shared.TargetPlayer;
                    transform.transform.LookAt(targetPlayer.field_Private_VRCPlayerApi_0.GetBonePosition((HumanBodyBones)10));
                    transform.transform.position = targetPlayer.gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * speed) * distance, 0, Mathf.Cos(Time.time * speed) * distance);
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                    yield return new WaitForSeconds(0.1f);
                    if (targetPlayer == null) { yield break; }
                }
            }
        }
        public static IEnumerator EverythingShallFreezeTRoleLoop()
        {
            while (true)
            {
                GameObject gameObject = GameObject.Find("Frag (0)");
                Transform transform = gameObject.transform;
                bool flag = gameObject != null;
                if (flag)
                {
                    bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                    if (flag2)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject);
                    }
                    Player targetPlayer = Shared.TargetPlayer;
                    transform.transform.LookAt(targetPlayer.field_Private_VRCPlayerApi_0.GetBonePosition((HumanBodyBones)10));
                    transform.transform.position = targetPlayer.gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * speed) * distance, 0, Mathf.Cos(Time.time * speed) * distance);
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                    yield return new WaitForSeconds(5f);
                    if (targetPlayer == null) { yield break; }
                }
            }
        }

        public static IEnumerator FingerBomb()
        {
            while (true)
            {
                GameObject.Instantiate(BombObj);
                BombObj.SetActive(true);
                GameObject gameObject = GameObject.Find("Frag (0)");
                Transform transform = gameObject.transform;
                bool flag = gameObject != null;
                if (flag)
                {
                    bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                    if (flag2)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject);
                    }
                    Player me = Player.prop_Player_0;                  
                    BombObj.transform.position = me.transform.position + new Vector3(0, 0, 3);
                    BombObj.transform.parent = me.transform.parent;
                    transform.transform.parent = BombObj.transform;
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                    yield return new WaitForSeconds(0.1f);
                    if (me == null) { yield break; }
                }
            }
        }

        #region Infammo
        public static IEnumerator InfiniteAmmo()
        {
            GameObject revolver = GameObject.Find("Revolver");
            VRCHandGrasper[] hand = UnityEngine.Object.FindObjectsOfType<VRCHandGrasper>();
            UdonBehaviour revolverUdon = revolver.GetComponent<UdonBehaviour>();
            GameObject luger0 = GameObject.Find("Luger (0)");
            UdonBehaviour luger0Udon = luger0.GetComponent<UdonBehaviour>();
            GameObject shotgun = GameObject.Find("Shotgun (0)");
            UdonBehaviour shotgunUdon = shotgun.GetComponent<UdonBehaviour>();
            GameObject camera = GameObject.Find("FlashCamera");
            UdonBehaviour cameraUdon = camera.GetComponent<UdonBehaviour>();
            bool stopperRight = false;
            bool stopperLeft = false;
            for (; ; )
            {
                bool flag = hand[0].field_Internal_VRC_Pickup_0 != null;
                if (flag)
                {
                    bool flag2 = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Revolver") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                    if (flag2)
                    {
                        revolverUdon.SendCustomEvent("Fire");
                        stopperRight = true;
                    }
                    else
                    {
                        bool flag3 = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Luger (0)") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                        if (flag3)
                        {
                            luger0Udon.SendCustomEvent("Fire");
                            stopperRight = true;
                        }
                        else
                        {
                            bool flag4 = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Shotgun (0)") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                            if (flag4)
                            {
                                shotgunUdon.SendCustomEvent("Fire");
                                stopperRight = true;
                            }
                            else
                            {
                                bool flag5 = hand[0].field_Internal_VRC_Pickup_0.gameObject.name.Equals("FlashCamera") && hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight;
                                if (flag5)
                                {
                                    cameraUdon.SendCustomNetworkEvent(0, "SyncPhoto");
                                    stopperRight = true;
                                }
                                else
                                {
                                    bool flag6 = hand[0].field_Internal_VRCInput_1.field_Public_Single_0 != 1f;
                                    if (flag6)
                                    {
                                        stopperRight = false;
                                    }
                                }
                            }
                        }
                    }
                }
                bool flag7 = hand[1].field_Internal_VRC_Pickup_0 != null;
                if (flag7)
                {
                    bool flag8 = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Revolver") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                    if (flag8)
                    {
                        revolverUdon.SendCustomEvent("Fire");
                        stopperLeft = true;
                    }
                    else
                    {
                        bool flag9 = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Luger (0)") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                        if (flag9)
                        {
                            luger0Udon.SendCustomEvent("Fire");
                            stopperLeft = true;
                        }
                        else
                        {
                            bool flag10 = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("Shotgun (0)") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                            if (flag10)
                            {
                                shotgunUdon.SendCustomEvent("Fire");
                                stopperLeft = true;
                            }
                            else
                            {
                                bool flag11 = hand[1].field_Internal_VRC_Pickup_0.gameObject.name.Equals("FlashCamera") && hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft;
                                if (flag11)
                                {
                                    cameraUdon.SendCustomNetworkEvent(0, "SyncPhoto");
                                    stopperLeft = true;
                                }
                                else
                                {
                                    bool flag12 = hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 0f;
                                    if (flag12)
                                    {
                                        stopperLeft = false;
                                    }
                                }
                            }
                        }
                    }
                }
                yield return null;
            }
        }
        #endregion

        public static void TargetedGunSmoke()
        {
            GameObject gameObject = GameObject.Find("Smoke (0)");
            GameObject gameobjectRev = GameObject.Find("Revolver");
            bool flag = gameObject != null;
            if (flag)
            {
                bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
                if (flag2)
                {
                    Networking.SetOwner(Networking.LocalPlayer, gameObject);
                }
                gameObject.gameObject.transform.position = new Vector3(gameobjectRev.gameObject.transform.position.x, gameobjectRev.gameObject.transform.position.y, gameobjectRev.gameObject.transform.position.z);
                gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
            }
        }
        public static object shootCor;
        public static IEnumerator GunShoot()
        {
            while (true)
            {
                GameObject rev = GameObject.Find("Revolver");
                Networking.LocalPlayer.TakeOwnership(rev.gameObject);
                rev.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Fire");
                yield return new WaitForSeconds(0.1f);
            }          
        }
      

      
        public static void TargetedKnife()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Knife = GameObject.Find("Knife (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Knife.gameObject);
                Transform transform = Knife.transform;
                Player targetPlayer = UtilsP.GetCurrentlySelectedPlayer();
                //transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Knife.transform.position = targetPlayer.transform.position + new Vector3(0f, 0.5f, 0f);

            }
        }
        public static void TargetedBoom()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                Transform transform = GameObject.Find("Game Logic/Weapons/Unlockables/Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(transform.gameObject);
                Transform transform2 = transform.transform;
                Player currentlySelectedPlayer = UtilsP.GetCurrentlySelectedPlayer();
                transform.transform.position = currentlySelectedPlayer.transform.position;
            }
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool flag = gameObject.name.Contains("Frag (0)");
                bool flag2 = flag;
                if (flag2)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Explode");
                }
            }
        }      
        public static IEnumerator GoldenGunLoop()
        {
            while (true)
            {
                VRCPickup revolver = GameObject.Find("Revolver").GetComponent<VRCPickup>();
                for (; ; )
                {
                    bool flag = revolver.currentPlayer != null;
                    if (flag)
                    {
                        VRCPlayerApi playerVrcPlayerApi = revolver.currentPlayer;
                        bool flag2 = playerVrcPlayerApi.displayName.Equals(APIUser.CurrentUser.displayName) && GameObject.Find("geo (patron)") == null;
                        if (flag2)
                        {
                            UdonBehaviour[] revolverEvent = GameObject.Find("Revolver").GetComponents<UdonBehaviour>();
                            revolverEvent[0].SendCustomNetworkEvent(0, "PatronSkin");
                            revolverEvent = null;
                        }
                        yield return null;
                        playerVrcPlayerApi = null;
                    }
                    yield return null;
                }
            }
        }
        public static void TargetedBoomSmoke()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Frag = GameObject.Find("Smoke (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Frag.gameObject);
                Transform transform = Frag.transform;
                Player targetPlayer = UtilsP.GetCurrentlySelectedPlayer();
                Frag.transform.position = targetPlayer.transform.position;
            }
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Smoke (0)");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Explode");
                }
            }
        }
        
        public static void Flash()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool flag = gameObject.name.Contains("FlashCamera");
                bool flag2 = flag;
                if (flag2)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncPhoto");
                }
            }
        }
        public static void Killall()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool flag = gameObject.name.Contains("Game Logic");
                bool flag2 = flag;
                if (flag2)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "KillLocalPlayer");
                }
            }
        }
        public static void TPToRev()
        {
            Player player = Player.prop_Player_0;
            Transform transform = GameObject.Find("Revolver").transform;
            Transform transform2 = transform.transform;
            //Player targetPlayer = Shared.TargetPlayer;
            //transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
            player.transform.position = transform.transform.position + new Vector3(0f, 0.5f, 0f);
            //GameObject.Find("Game Logic/Game Area Bounds").transform.localScale = new Vector3(50f, 50f, 50f);
        }



        public static void UnGoldsYourGun()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool flag = gameObject.name.Contains("Revolver");
                bool flag2 = flag;
                if (flag2)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "NonPatronSkin");
                }
            }
        }
        public static void BystanderSet()
        {
            UdonMurder.RunUdonEventTarget("SyncAssignB");
        }
        public static void MurdererSet()
        {
            UdonMurder.RunUdonEventTarget("SyncAssignM");
        }
        public static void DetectiveSet()
        {
            UdonMurder.RunUdonEventTarget("SyncAssignD");
        }
        public static void KillSet()
        {
            UdonMurder.RunUdonEventTarget("SyncKill");
        }
        public static IEnumerator RoleLoop()
        {
            while (Shared.TargetPlayer != null)
            {
                yield return new WaitForSeconds(1.5f);
                UdonMurder.RunUdonEventTarget("SyncAssignB");
                yield return new WaitForSeconds(1.5f);
                UdonMurder.RunUdonEventTarget("SyncKill");
            }           
        }
        

        /*public static void MurdererSet()
        {
            VRCPlayer component = Shared.TargetPlayer.gameObject.GetComponent<VRCPlayer>();
            string value = component._player.ToString();
            for (int i = 0; i < 24; i++)
            {
                string text = "Player Node (" + i.ToString() + ")";
                string text2 = "Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + i.ToString() + ")/Player Name Text";
                bool flag = GameObject.Find(text2).GetComponent<Text>().text.Equals(value);
                if (flag)
                {
                    UdonBehaviour component2 = GameObject.Find(text).GetComponent<UdonBehaviour>();
                    component2.SendCustomNetworkEvent(0, "SyncAssignM");
                }
            }
        }*/
        

        public static void WinMurderer()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Game Logic");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncVictoryM");
                }

            }

        }
        public static void Fire()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Revolver");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Fire");
                }

            }

        }
        public static void WinBystander()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Game Logic");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncVictoryB");
                }

            }

        }
        public static void Abort()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Game Logic");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Btn_Abort");
                }

            }

        }
        public static void Start()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Game Logic");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncStart");
                }

            }

        }
        public static IEnumerator StartLoop()
        {
            while (true)
            {
                game.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncStart");
                yield return new WaitForSeconds(5);
            }
            

        }
        public static void Kill()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Game Logic");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "KillLocalPlayer");
                }

            }

        }
        public static void Blind()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Game Logic");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "OnLocalPlayerBlinded");
                }

            }

        }
        
        public static void Trigger()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {

                {
                    bool T1 = gameObject.name.Contains("Bear Trap (0)");
                    if (T1)
                    {
                        gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncTrigger");
                    }
                    bool T2 = gameObject.name.Contains("Bear Trap (1)");
                    if (T2)
                    {
                        gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncTrigger");
                    }
                    bool T3 = gameObject.name.Contains("Bear Trap (2)");
                    if (T3)
                    {
                        gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncTrigger");
                    }
                }
            }
        }

        public static IEnumerator BearTrapTriforceS()
        {
            while (true)
            {
                GameObject gameObject1 = GameObject.Find("Bear Trap (0)");
                GameObject gameObject2 = GameObject.Find("Bear Trap (1)");
                GameObject gameObject3 = GameObject.Find("Bear Trap (2)");
                bool flag = gameObject1 != null;
                bool flagg = gameObject1 != null;
                bool flaggg = gameObject1 != null;
                if (flag || flagg || flaggg)
                {
                    bool flag2 = Networking.GetOwner(gameObject1) != Networking.LocalPlayer;
                    bool flagg2 = Networking.GetOwner(gameObject1) != Networking.LocalPlayer;
                    bool flaggg2 = Networking.GetOwner(gameObject1) != Networking.LocalPlayer;
                    if (flag2 || flagg2 || flaggg2)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject1);
                        Networking.SetOwner(Networking.LocalPlayer, gameObject2);
                        Networking.SetOwner(Networking.LocalPlayer, gameObject3);
                    }
                    Player targetPlayer = Shared.TargetPlayer;
                    gameObject1.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                    gameObject2.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                    gameObject3.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                    gameObject1.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncTrigger");
                    gameObject2.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncTrigger");
                    gameObject3.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncTrigger");
                    yield return new WaitForSeconds(0.3f);
                }              
            }           
        }
        public static void BearTrapTriforce()
        {
            {
                GameObject gameObject1 = GameObject.Find("Bear Trap (0)");
                GameObject gameObject2 = GameObject.Find("Bear Trap (1)");
                GameObject gameObject3 = GameObject.Find("Bear Trap (2)");
                bool flag = gameObject1 != null;
                bool flagg = gameObject1 != null;
                bool flaggg = gameObject1 != null;
                if (flag || flagg || flaggg)
                {
                    bool flag2 = Networking.GetOwner(gameObject1) != Networking.LocalPlayer;
                    bool flagg2 = Networking.GetOwner(gameObject1) != Networking.LocalPlayer;
                    bool flaggg2 = Networking.GetOwner(gameObject1) != Networking.LocalPlayer;
                    if (flag2 || flagg2 || flaggg2)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, gameObject1);
                        Networking.SetOwner(Networking.LocalPlayer, gameObject2);
                        Networking.SetOwner(Networking.LocalPlayer, gameObject3);
                    }
                    Player targetPlayer = Shared.TargetPlayer;
                    gameObject1.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                    gameObject2.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                    gameObject3.gameObject.transform.position = new Vector3(targetPlayer.gameObject.transform.position.x, targetPlayer.gameObject.transform.position.y + 1f, targetPlayer.gameObject.transform.position.z);
                    gameObject1.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncTrigger");
                    gameObject2.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncTrigger");
                    gameObject3.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncTrigger");                  
                }
            }
        }
        public UdonMurder()
        {
            GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = false;
			GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = false;
        }
        public static bool FlashAnnoy;

    }
}
