using System;
using CreClient.Settings;
using Il2CppSystem.Collections;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using VRC.Udon;

namespace CreClient.MURDER
{
    class RespawnMurder
    {
		public static void RespawnLuger()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Luger (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnShotgun()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Shotgun (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnBearTrap3()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Bear Trap (2)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnCamera()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("FlashCamera").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnBearTrap2()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Bear Trap (1)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnGrenade()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Frag (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnSmoke()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Smoke (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnBearTrap1()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Bear Trap (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnKnife()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Knife (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnLuger2()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Luger (1)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void RespawnRevolver()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Transform transform = GameObject.Find("Revolver").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				transform.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
	}	
}
