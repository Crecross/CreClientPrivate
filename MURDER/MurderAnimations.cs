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

namespace CreClient.MURDER
{
    internal class MurderAnimations

    {
        public static object coroutine;
        public static void SetNoBlindOn(bool active)
        {
            if (!active)
            {
                MelonLogger.Msg("No Blind Off");
                MurderAnimations.coroutine = MelonCoroutines.Start(MurderAnimations.NoBlindOff());
            }
            else
            {
                MelonLogger.Msg("No Blind On");
                MurderAnimations.coroutine = MelonCoroutines.Start(MurderAnimations.NoBlindOn());
            }
        }
        public static IEnumerator NoBlindOn()
        {
            for (; ; )
            {
                GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = false;
                GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = false;
                yield break;
                
            }               
        }
        public static IEnumerator NoBlindOff()
        {
            for (; ; )
            {
                GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = true;
                GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = true;
                yield break;
            }           
        }
        private static List<UdonBehaviour> lights = new List<UdonBehaviour>();
        public static void LightsOut()
        {

            Transform transform = GameObject.Find("Game Logic/Switch Boxes").transform;
            for (int i = 0; i < transform.childCount; i++)
            {
                MurderAnimations.lights.Add(transform.GetChild(i).GetComponent<UdonBehaviour>());
            }

            for (int i = 0; i < MurderAnimations.lights.Count; i++)
            {
                MurderAnimations.lights[i].SendCustomNetworkEvent(0, "SwitchDown");
            }
        }
        public static void LightsOn()
        {

            Transform transform = GameObject.Find("Game Logic/Switch Boxes").transform;
            for (int i = 0; i < transform.childCount; i++)
            {
                lights.Add(transform.GetChild(i).GetComponent<UdonBehaviour>());
            }

            for (int i = 0; i < MurderAnimations.lights.Count; i++)
            {
                lights[i].SendCustomNetworkEvent(0, "SwitchUp");
            }
        }
        public static void LockDoors()
        {
            List<Transform> lD = new List<Transform>
            {
                GameObject.Find("Door").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (3)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (4)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (5)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (6)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (7)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (15)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (16)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (8)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (13)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (17)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (18)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (19)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (20)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (21)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (22)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (23)").transform.Find("Door Anim/Hinge/Interact lock"),
                GameObject.Find("Door (14)").transform.Find("Door Anim/Hinge/Interact lock")
            };
            foreach (Transform transform in lD)
            {
                transform.GetComponent<UdonBehaviour>().Interact();
            }
        }
        public static void OpenDoors()
        {
            List<Transform> oD = new List<Transform>
            {
                GameObject.Find("Door").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (3)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (4)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (5)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (6)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (7)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (15)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (16)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (8)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (13)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (17)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (18)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (19)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (20)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (21)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (22)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (23)").transform.Find("Door Anim/Hinge/Interact open"),
                GameObject.Find("Door (14)").transform.Find("Door Anim/Hinge/Interact open")
            };
            foreach (Transform transform in oD)
            {
                transform.GetComponent<UdonBehaviour>().Interact();
            }
        }
        public static void CloseDoors()
        {
            List<Transform> cD = new List<Transform>
            {
                GameObject.Find("Door").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (3)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (4)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (5)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (6)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (7)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (15)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (16)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (8)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (13)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (17)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (18)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (19)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (20)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (21)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (22)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (23)").transform.Find("Door Anim/Hinge/Interact close"),
                GameObject.Find("Door (14)").transform.Find("Door Anim/Hinge/Interact close")
            };
            foreach (Transform transform in cD)
            {
                transform.GetComponent<UdonBehaviour>().Interact();
            }
        }
        public static void UnlockDoors()
        {
            List<Transform> list = new List<Transform>
            {
                GameObject.Find("Door").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (3)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (4)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (5)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (6)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (7)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (15)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (16)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (8)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (13)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (17)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (18)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (19)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (20)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (21)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (22)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (23)").transform.Find("Door Anim/Hinge/Interact shove"),
                GameObject.Find("Door (14)").transform.Find("Door Anim/Hinge/Interact shove")
            };
            foreach (Transform transform in list)
            {
                transform.GetComponent<UdonBehaviour>().Interact();
                transform.GetComponent<UdonBehaviour>().Interact();
                transform.GetComponent<UdonBehaviour>().Interact();
                transform.GetComponent<UdonBehaviour>().Interact();
            }
        }
        public static void NoDoors()
        {
            GameObject doors = GameObject.Find("Environment/Doors");
            doors.transform.position = new Vector3(0, 100, 0);
        }
        public static void YesDoors()
        {
            GameObject doors = GameObject.Find("Environment/Doors");
            doors.transform.position = new Vector3(0, 0, 0);
        }
    }
}
