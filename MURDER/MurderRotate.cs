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
using WTFBlaze;
using TMPro;
using UnityEngine.UI;

namespace CreClient.MURDER
{
    class MurderRotate
    {
        public bool gunRotate = false;
        public bool kOn = false;
        public static object coroutine;
        public static object TarGun;
        public static object TarCam;
        


        //rotate the luger around the player
        public static float speed = 2f;
        public static float distance = 2f;
        public static IEnumerator RotateGun()
        {
            while (true)
            {
                GameObject gameObject = GameObject.Find("Luger (0)");
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
                    transform.transform.position = targetPlayer.gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * UdonMurder.speed) * UdonMurder.distance, 0, Mathf.Cos(Time.time * UdonMurder.speed) * UdonMurder.distance);
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "Fire");                     
                    yield return new WaitForSeconds(0.1f);
                    if(targetPlayer == null) { yield break; }
                }
            }
        }
        public static IEnumerator RotateCam()
        { 
            while(true)
            {
                GameObject gameObject = GameObject.Find("FlashCamera");
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
                    //transform.transform.LookAt(targetPlayer.transform);
                    transform.transform.position = targetPlayer.gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * UdonMurder.speed) * UdonMurder.distance, 0, Mathf.Cos(Time.time * UdonMurder.speed) * UdonMurder.distance);
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncPhoto");
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(0, "SyncFlashbang");
                    yield return new WaitForSeconds(0.1f);
                    if (targetPlayer == null) { yield break; }
                }
            }
        }
    }
}
