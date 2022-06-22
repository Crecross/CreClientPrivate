using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class RoomNade
    {

        public static void CellarRand()
        {
            Cellar Cellar = new Cellar();
            System.Random rand = new System.Random();
            int number = rand.Next(3);
            if (number == 0)
                Cellar.Cellar1();
            if (number == 1)
                Cellar.Cellar2();
        }
        public static void TopHallRand()
        {
            TopHall topHall = new TopHall();
            System.Random rand = new System.Random();
            int number = rand.Next(3);
            if (number == 0)
                topHall.TopHall1();
            if (number == 1)
                topHall.TopHall2();
            if (number == 2)
                topHall.TopHall3();
        }
        public static void LibraryRand()
        {
            Library library = new Library();
            System.Random rand = new System.Random();
            int number = rand.Next(3);
            if (number == 0)
                library.Lib1();
            if (number == 1)
                library.Lib2();         
        }
        public class TopHall
        {
            public void TopHall1()
            {

                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    var Grenade = GameObject.Find("Frag (0)").transform;
                    Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                    Grenade.transform.position = new Vector3(2.9f, 2.9f, 128.8f);
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
            public void TopHall3()
            {

                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    var Grenade = GameObject.Find("Frag (0)").transform;
                    Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                    Grenade.transform.position = new Vector3(-3.1f, 2.9f, 124.4f);
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
            public void TopHall2()
            {
                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    var Grenade = GameObject.Find("Frag (0)").transform;
                    Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                    Grenade.transform.position = new Vector3(-2.9f, 2.9f, 129.6f);
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
        }
        public class Library
        {
            public void Lib1()
            {

                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    var Grenade = GameObject.Find("Frag (0)").transform;
                    Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                    Grenade.transform.position = new Vector3(13.9f, -0.1f, 114f);
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
            public void Lib2()
            {

                foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
                {
                    var Grenade = GameObject.Find("Frag (0)").transform;
                    Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                    Grenade.transform.position = new Vector3(13.6f, -0.1f, 120f);
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
        }
            
        public static void Lounge()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(-17.3f, -0.1f, 129f);
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
        public static void Bedroom()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(-8.5f, 3.7f, 129.3f);
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
        public static void Bathroom()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(0.1f, 2.9f, 133f);
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
        public static void Kitchen()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(-20.6f, -0.1f, 121.4f);
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
        public static void Detective()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(5f, 3.7f, 124f);
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

        public static void DiningRoom()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);               
                Grenade.transform.position = new Vector3(-13f, 0.7f, 117.4f);
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
        public static void GrandHall()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())

            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(0.4f, -0.1f, 115.9f);
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
    }
    class Cellar
    {
         public void Cellar1()
        {

            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(-5.8f, -3.1f, 130.2f);
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
        public void Cellar2()
        {
            foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
            {
                var Grenade = GameObject.Find("Frag (0)").transform;
                Networking.LocalPlayer.TakeOwnership(Grenade.gameObject);
                Grenade.transform.position = new Vector3(1.1f, -3.1f, 130.2f);
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
        
    }   
}
