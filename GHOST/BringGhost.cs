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
    public class BringGhost
    {
		public static IEnumerator LocalGuns()
        {
			yield return new WaitForSeconds(1f);
        }
		public static void BringUzi()
		{
			foreach (VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC_Pickup>())
			{
				Player player = Player.prop_Player_0;
				Transform transform = GameObject.Find("Weapons-InGame/T2-Uzi (6)").transform;
				Networking.LocalPlayer.TakeOwnership(transform.gameObject);
				Transform transform2 = transform.transform;
				//Player targetPlayer = Shared.TargetPlayer;
				//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}

		}
		public static void CollectAllClues()
        {
			foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
			{
				List<GameObject> Clues = new List<GameObject>()
			{
				GameObject.Find("CluePickup"), GameObject.Find("CluePickup (1)"),
				GameObject.Find("CluePickup (2)"), GameObject.Find("CluePickup (3)"),
				GameObject.Find("CluePickup (4)"),GameObject.Find("CluePickup (5)"),
				GameObject.Find("CluePickup (6)"), GameObject.Find("CluePickup (7)"),
				GameObject.Find("CluePickup (8)"),


			};
				{
					
					GameObject gameObject = new GameObject();
					Transform transform = gameObject.transform;
					transform.position = new Vector3(-2.2f, 4f, 495.3f);
					foreach (var Clue in Clues)
					{
						
						
						Networking.LocalPlayer.TakeOwnership(Clue.gameObject);
						Clue.transform.position = new Vector3(-2.2f, 4f, 495.3f);
					}
				}

			}
		}
		public static void BringKeys()
        {
			var me = Player.prop_Player_0;
			var Key = GameObject.Find("Key").transform;
			var Key1 = GameObject.Find("Key (1)").transform;
			var Key2 = GameObject.Find("Key (2)").transform;

			Networking.LocalPlayer.TakeOwnership(Key.gameObject);
			Networking.LocalPlayer.TakeOwnership(Key1.gameObject);
			Networking.LocalPlayer.TakeOwnership(Key2.gameObject);

			Key.transform.position = me.transform.position;
			Key1.transform.position = me.transform.position;
			Key2.transform.position = me.transform.position;


		}
		public static void BringMoney()
		{
			var me = Player.prop_Player_0;
			var Money = GameObject.Find("MoneySpawnPoint (10)/Pickup/10000dol").transform;
			

			Networking.LocalPlayer.TakeOwnership(Money.gameObject);
			

			Money.transform.position = me.transform.position;
			


		}
		public static void Clues()
        {
			foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
			{
				List<GameObject> Knifes = new List<GameObject>()
			{
				GameObject.Find("CluePickup"), GameObject.Find("CluePickup (1)"),
				GameObject.Find("CluePickup (2)"), GameObject.Find("CluePickup (3)"),
				GameObject.Find("CluePickup (4)"),GameObject.Find("CluePickup (5)"),
				GameObject.Find("CluePickup (6)"), GameObject.Find("CluePickup (7)"),
				GameObject.Find("CluePickup (8)"),


			};
				{
					var me = Player.prop_Player_0;
					GameObject gameObject = new GameObject();
					Transform transform = gameObject.transform;
					transform.position = me.transform.position + new Vector3(0f, 0.35f, 0f);
					foreach (var Knife in Knifes)
					{
						Networking.LocalPlayer.TakeOwnership(Knife.gameObject);
						Knife.transform.position = gameObject.transform.position + gameObject.transform.forward;
						Knife.transform.LookAt(me.transform);
						gameObject.transform.Rotate(new Vector3(0f, (float)(360 / Knifes.Count), 0f));
					}
				}
			
			}
		}
	}
}
