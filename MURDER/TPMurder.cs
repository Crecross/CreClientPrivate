using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using CreClient.Settings;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace CreClient.MURDER
{
    public class TPMurder
    {
        
       
        
        public static void StealthTP()
        {
            TP TPRand = new TP();
            System.Random rand = new System.Random();
            int number = rand.Next(3);
            if (number == 0)
                TPRand.Random1();
            if (number == 1)
                TPRand.Random2();
            if (number == 2)
                TPRand.Random3();
            if (number == 3)
                TPRand.Random4();
            if (number == 4)
                TPRand.Random5();
        }
        public static void ScatteredSpawn()
        {
            var me = Player.prop_Player_0;
            GameObject scatteredSpawn = GameObject.Find("Lobby Spawns");
            Transform transform = scatteredSpawn.transform;           
            int children = transform.childCount;
           
            for (int i = 0; i < children; ++i)
            {
                var e = UnityEngine.Random.Range(0, children);
                UnityEngine.Random.RandomRange(children, children);
                //me.transform.position = UnityEngine.Random.RandomRangeInt();
            }
        }
    }
    


    class TP
    {
        public void Random1()
        {
            var Me = Player.prop_Player_0;
            Me.transform.position = new Vector3(-2.9f, -0.1f, 11.9f);
        }
        public void Random2()
        {
            var Me = Player.prop_Player_0;
            Me.transform.position = new Vector3(1.9f, -0.1f, 8.6f);
        }
        public void Random3()
        {
            var Me = Player.prop_Player_0;
            Me.transform.position = new Vector3(3.5f, -0.1f, 12.1f);
        }
        public void Random4()
        {
            var Me = Player.prop_Player_0;
            Me.transform.position = new Vector3(1.9f, -0.1f, 10.3f);
        }
        public void Random5()
        {
            var Me = Player.prop_Player_0;
            Me.transform.position = new Vector3(4.1f, -0.1f, 13.5f);
        }
    }

}
 


