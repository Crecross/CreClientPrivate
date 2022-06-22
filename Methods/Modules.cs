using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MelonLoader;
using UnityEngine.Playables;
using VRC;
using CreClientTest.Settings;


using UnityEngine;

namespace CreClientTest.Modules
{
    public class Modules
    {
        public List<BaseModule> modules = new List<BaseModule>();
        //public Esp esp;
       // public Flight flight;
       // public Speed speed;
       // public TrustRankNameplate trustRankNameplate;
       // public ItemESP itemEsp;
       // public FPSUnlocker fpsUnlocker;
        //public ItemOrbit itemOrbit;
        //public FreezePickups freezePickups;
        public bool askForPortal;

        //public PlayerList playerList;
        //public HideSelf hideSelf;

        public Modules()
        {//
            //this.modules.Add(this.esp = new Esp());
            //this.modules.Add(this.flight = new Flight());
            //this.modules.Add(this.trustRankNameplate = new TrustRankNameplate());
            //this.modules.Add(this.itemEsp = new ItemESP());
            //this.modules.Add(this.speed = new Speed());
            //this.modules.Add(this.fpsUnlocker = new FPSUnlocker());
            //this.modules.Add(this.itemOrbit = new ItemOrbit());
            //this.modules.Add(this.freezePickups = new FreezePickups());
            //this.modules.Add(this.playerList = new PlayerList());
            //this.modules.Add(this.hideSelf = new HideSelf());
        }

        public void StartCoroutines()
        {
            MelonCoroutines.Start(Initialize());
            //MelonCoroutines.Start(Shared.modules.portal.AutoPortal());
        }

        private IEnumerator Initialize()
        {
            while (true)
            {
                
            }
        }
       
    }
}