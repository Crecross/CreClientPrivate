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

namespace CreClient.GHOST
{
    public class UdonGhost
    {
        public static void GibMoney()
        {
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                bool Gm = gameObject.name.Contains("GameManager");
                if (Gm)
                {
                    gameObject.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, "ForceAltCurrency");
                }

            }
        }
    }
}
