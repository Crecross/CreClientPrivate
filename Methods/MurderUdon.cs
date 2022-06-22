using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.UI;
using VRCSDK2;
using VRC.Udon.Common.Interfaces;
using CreClientTest.Settings;

namespace CreClientTest.Modules
{
    public class MurderUdon
    {
        public static void GoldGun()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Revolver");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "PatronSkin");
                }

            }

        }
        public static void UnGoldsYourGun()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Revolver");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "NonPatronSkin");
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
        
    public static void Trig()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool T1 = gameObject.name.Contains("BearTrap (0)");
                if (T1)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncTrigger");
                }
                bool T2 = gameObject.name.Contains("BearTrap (1)");
                if (T2)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncTrigger");
                }
                bool T3 = gameObject.name.Contains("BearTrap (2)");
                if (T3)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncTrigger");
                }

            }


        }
        /*public static void Snake()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("SnakeDispenser");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "DispenseSnake");
                }

            }

        }
        public static void SnakeRespawn()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("SnakeDispenser");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Respawn");
                }

            }

        }*/
        /*public static void TargetedFire()
        {
            {
                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

                {
                    var Gun1 = GameObject.Find("Revolver").transform;
                    Networking.LocalPlayer.TakeOwnership(Gun1.gameObject);
                    Transform transform = Gun1.transform;
                    Player targetPlayer = Shared.TargetPlayer;
                    transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                    Gun1.transform.position = targetPlayer.transform.position;
                }
            }
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Revolver");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Fire");
                }

            }
            {
                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    var Gun1 = GameObject.Find("Revolver").transform;
                    Networking.LocalPlayer.TakeOwnership(Gun1.gameObject);
                    Gun1.transform.position = new Vector3(0f, -10000000f, 0f);
                }
            }*/


    }
    /*public static void GoldGunLoop()
        {
            MurderUdon.goldGunLoop = !MurderUdon.goldGunLoop;
            {
                var gunon = MurderUdon.goldGunLoop;
                if (!MurderUdon.goldGunLoop)
                {
                    foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                    {
                        var flag = gameObject.name.Contains("Revolver");
                        if (flag)
                        {
                            gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "PatronSkin");
                        }
                        //gameObject = null;
                    }

                }

            }

        }
    public static void BearTrapTriforce()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var trap1 = GameObject.Find("Bear Trap (0)").transform;
                Networking.LocalPlayer.TakeOwnership(trap1.gameObject);
                Transform transform = trap1.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(5f, 0.3f, 0f);
                trap1.transform.position = targetPlayer.transform.position;
            }
            {
                var trap2 = GameObject.Find("Bear Trap (1)").transform;
                Networking.LocalPlayer.TakeOwnership(trap2.gameObject);
                Transform transform = trap2.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.3f, 5f);
                trap2.transform.position = targetPlayer.transform.position;
            }
            {
                var trap3 = GameObject.Find("Bear Trap (2)").transform;
                Networking.LocalPlayer.TakeOwnership(trap3.gameObject);
                Transform transform = trap3.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(-5f, 0.3f, 0f);
                trap3.transform.position = targetPlayer.transform.position;
            }
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool T1 = gameObject.name.Contains("Bear Trap (0)");
                if (T1)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncDeploy");
                }
                bool T2 = gameObject.name.Contains("Bear Trap (1)");
                if (T2)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncDeploy");
                }
                bool T3 = gameObject.name.Contains("Bear Trap (2)");
                if (T3)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncDeploy");
                }

            }


        }*/
    public static IEnumerator GoldGunLoopp()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Revolver");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "PatronSkin");
                }
                yield return new WaitForSeconds(1f);

            }
        }
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
        
        public static void NoBlind()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                var blind = GameObject.Find("Blind HUD Anim");
                blind.SetActive(false);
            }

        }

        public static bool goldGunLoop = false;
    }
}
