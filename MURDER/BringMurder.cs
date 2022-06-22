using System;
using CreClient.Settings;
using Il2CppSystem.Collections;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using VRC.Udon;

namespace CreClient.MURDER
{
	class BringMurder
	{
		public static Player targetplayer = Shared.TargetPlayer;
		public static void Revolver()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Revolver").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void Luger()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Unlockables/Luger (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}		
		public static void Shotty()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Unlockables/Shotgun (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		
		public static void Cam()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Polaroids Unlock Camera/FlashCamera").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void Smoke()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Unlockables/Smoke (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void Grenade()
		{
			{
				GameObject gameObject = GameObject.Find("Frag (0)");
				Transform fragTrans = gameObject.transform;
				bool flag = gameObject != null;
				if (flag)
				{
					bool flag2 = Networking.GetOwner(gameObject) != Networking.LocalPlayer;
					if (flag2)
					{
						Networking.SetOwner(Networking.LocalPlayer, gameObject);
					}
					Player me = Player.prop_Player_0;
					fragTrans.transform.position = me.transform.position + new Vector3(0, 1, 0);

				}
			}
		}
		public static void BT1()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Bear Trap (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void BT2()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Bear Trap (1)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void BT3()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Bear Trap (2)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void Knife()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Game Logic/Weapons/Knife (0)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
	}
}
