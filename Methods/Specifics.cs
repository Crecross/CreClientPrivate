using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using VRC.SDKBase;
using UnityEngine;
using VRC;
using CreClientTest.Settings;
using VRC.Udon;
using VRCSDK2;
using MelonLoader;
using VRC.Core;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRCSDK2;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using VRC.Udon.Common.Interfaces;
using System.Collections;

namespace CreClientTest.Modules
{

    public class Specifics
    {
        
        public static void Revolver()

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
        public static void RespawnRevolver()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Gun1 = GameObject.Find("Revolver").transform;
                Networking.LocalPlayer.TakeOwnership(Gun1.gameObject);
                Gun1.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void Grenade()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {


                var Frag = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Frag.gameObject);
                Transform transform = Frag.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Frag.transform.position = targetPlayer.transform.position;
            
            }



        }
       
        public static void CBomb()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var CB = GameObject.Find("CursedBomb").transform;


                Networking.LocalPlayer.TakeOwnership(CB.gameObject);
                Transform transform = CB.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                CB.transform.position = targetPlayer.transform.position;
            }

        }
        public static void RespawnCBomb()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var CB = GameObject.Find("CursedBomb").transform;
                Networking.LocalPlayer.TakeOwnership(CB.gameObject);
                CB.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void RespawnGrenade()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Frag = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Frag.gameObject);
                Frag.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void Luger()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Mauser = GameObject.Find("Luger (0)").transform;


                Networking.LocalPlayer.TakeOwnership(Mauser.gameObject);
                Transform transform = Mauser.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Mauser.transform.position = targetPlayer.transform.position;
            }

        }
        public static void LugertoUser()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Mauser = GameObject.Find("Luger (0)").transform;
                

                Networking.LocalPlayer.TakeOwnership(Mauser.gameObject);
                Transform transform = Mauser.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Mauser.transform.position = targetPlayer.transform.position;
            }

        }

        public static void RespawnLuger()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Mauser = GameObject.Find("Luger (0)").transform; ;
                Networking.LocalPlayer.TakeOwnership(Mauser.gameObject);
                Mauser.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }

        public static Il2CppSystem.Collections.IEnumerator FreezeLoop()
        {
            while (true)
            {
                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    if (Networking.GetOwner(vrc_Pickup.gameObject) != Networking.LocalPlayer)
                    {
                        Networking.SetOwner(Networking.LocalPlayer, vrc_Pickup.gameObject);
                    }
                }
            }
        }
        public static void Luger2()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Mauser1 = GameObject.Find("Luger (1)").transform;


                Networking.LocalPlayer.TakeOwnership(Mauser1.gameObject);
                Transform transform = Mauser1.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Mauser1.transform.position = targetPlayer.transform.position;
            }

        }


        public static void RespawnLuger2()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Mauser1 = GameObject.Find("Luger (1)").transform; ;
                Networking.LocalPlayer.TakeOwnership(Mauser1.gameObject);
                Mauser1.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void BearTrap1()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var trap1 = GameObject.Find("Bear Trap (0)").transform;


                Networking.LocalPlayer.TakeOwnership(trap1.gameObject);
                Transform transform = trap1.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.8f, 0f);
                trap1.transform.position = targetPlayer.transform.position;
            }

        }
        public static void RespawnBearTrap1()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var trap1 = GameObject.Find("Bear Trap (0)").transform;
                Networking.LocalPlayer.TakeOwnership(trap1.gameObject);
                trap1.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void BearTrap2()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var trap2 = GameObject.Find("Bear Trap (1)").transform;


                Networking.LocalPlayer.TakeOwnership(trap2.gameObject);
                Transform transform = trap2.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.8f, 0f);
                trap2.transform.position = targetPlayer.transform.position;
            }

        }
        public static void RespawnBearTrap2()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var trap2 = GameObject.Find("Bear Trap (1)").transform;
                Networking.LocalPlayer.TakeOwnership(trap2.gameObject);
                trap2.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void BearTrap3()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var trap3 = GameObject.Find("Bear Trap (2)").transform;


                Networking.LocalPlayer.TakeOwnership(trap3.gameObject);
                Transform transform = trap3.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.8f, 0f);
                trap3.transform.position = targetPlayer.transform.position;
            }

        }
        public static void RespawnBearTrap3()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var trap3 = GameObject.Find("Bear Trap (2)").transform;
                Networking.LocalPlayer.TakeOwnership(trap3.gameObject);
                trap3.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }



        public static void knife()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Stabby = GameObject.Find("Knife (0)").transform;


                Networking.LocalPlayer.TakeOwnership(Stabby.gameObject);
                Transform transform = Stabby.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Stabby.transform.position = targetPlayer.transform.position;
            }

        }
        public static void RespawnKnife()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Stabby = GameObject.Find("Knife (0)").transform; ;
                Networking.LocalPlayer.TakeOwnership(Stabby.gameObject);
                Stabby.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void ShotGun()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Shotty = GameObject.Find("Shotgun (0)").transform;


                Networking.LocalPlayer.TakeOwnership(Shotty.gameObject);
                Transform transform = Shotty.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Shotty.transform.position = targetPlayer.transform.position;
            }
        }
        public static void RespawnShotgun()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Shotty = GameObject.Find("Shotgun (0)").transform; ; ;
                Networking.LocalPlayer.TakeOwnership(Shotty.gameObject);
                Shotty.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }
        public static void Camera()

        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Cam = GameObject.Find("FlashCamera").transform;


                Networking.LocalPlayer.TakeOwnership(Cam.gameObject);
                Transform transform = Cam.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Cam.transform.position = targetPlayer.transform.position;
            }
        }
        public static void BoomBoom()
        {

            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool flag = gameObject.name.Contains("Frag (0)");
                if (flag)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Explode");
                }
                
            }
            
        }

        public static void TargetedBoom()
        {
            
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {


                var Frag = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Frag.gameObject);
                Transform transform = Frag.transform;
                Player targetPlayer = Shared.TargetPlayer;
                transform.position = ((targetPlayer != null) ? targetPlayer.transform.position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position) + new Vector3(0f, 0.5f, 0f);
                Frag.transform.position = targetPlayer.transform.position;

            }
            

            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Boom = gameObject.name.Contains("Frag (0)");
                if (Boom)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "Explode");
                }

            }

        }       

        public static void RespawnCamera()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Cam = GameObject.Find("FlashCamera").transform;
                Networking.LocalPlayer.TakeOwnership(Cam.gameObject);
                Cam.transform.position = new Vector3(0f, -10000000f, 0f);
            }
        }

    }
}
