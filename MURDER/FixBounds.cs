using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using VRC.Udon;
using System.Collections;
using CreClient.Settings;

namespace CreClient.MURDER
{
    class FixBoundsM

    {     
        public static IEnumerator FixBoundsOn()
        {
            for (;;)
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().enabled = false;
                GameObject.Find("Game Logic/Game Area Bounds").transform.localScale = new Vector3(1000f, 1000f, 1000f);
                Logs.LogGeneral("Bounds Fixed! Do you hear that?", false);                
                yield break;
            }              
           
        }
        public static IEnumerator FixBoundsOff()
        {
            for (;;)
            {
                GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().enabled = true;
                GameObject.Find("Game Logic/Game Area Bounds").transform.localScale = new Vector3(77.2646f, 7.938f, 43.289f);
                Logs.LogGeneral("Bounds returned to normal!", false);
                yield break;
            }

        }      
        
    }    
    
}
