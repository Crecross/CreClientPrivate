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
    public class PlayerNode
    {
        public static void Node()
        {
            {
                foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
                {

                    //var node = new string[24] { "Player Node (0)", "Player Node (1)", "Player Node (2)", "Player Node (3)", "Player Node (4)", "Player Node (5)", "Player Node (6)", "Player Node (7)", "Player Node (8)", "Player Node (9)", "Player Node (10)", "Player Node (11)", "Player Node (12)", "Player Node (13)", "Player Node (14)", "Player Node (15)", "Player Node (16)", "Player Node (17)", "Player Node (18)", "Player Node (19)", "Player Node (20)", "Player Node (21)", "Player Node (22)", "Player Node (23)" };
                    bool nodeall = gameObject.name.Contains("Player Node (0)" + "Player Node (1)" + "Player Node (3)" + "Player Node (4)" + "Player Node (5)" + "Player Node (6)" + "Player Node (7)" + "Player Node (8)" + "Player Node (9)" + "Player Node (10)" + "Player Node (11)" + "Player Node (12)" + "Player Node (13)" + "Player Node (14)" + "Player Node (15)" + "Player Node (16)" + "Player Node (17)" + "Player Node (18)" + "Player Node (19)" + "Player Node (20)" + "Player Node (21)" + "Player Node (22)" + "Player Node (23)" + "Player Node (24)");
                    if (nodeall)
                    {
                        
                        gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "SyncAssignB");
                    }

                }
                

            }
        }
    }
}
