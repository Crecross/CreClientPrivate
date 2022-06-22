using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using CreClient.Settings;
using WTFBlaze;

namespace CreClient.MURDER
{
	public class GodMurderMono
	{
		private static IEnumerator TouchOfLife()
		{
			VRCHandGrasper[] hand = UnityEngine.Object.FindObjectsOfType<VRCHandGrasper>();
			bool stopperRight = false;
			for (; ; )
			{
				bool flag = hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperRight && hand[0].field_Internal_VRCInput_2.field_Public_Single_0 == 1f;
				if (flag)
				{
					float playerDistance = 999f;
					Player playerToKill = null;
					Player[] players = PlayerManager.prop_PlayerManager_0.gameObject.GetComponentsInChildren<Player>();
					int num;
					for (int i = 0; i < players.Length; i = num)
					{
						bool flag2 = Vector3.Distance(players[i].gameObject.transform.position, hand[0].gameObject.transform.position) < playerDistance && !players[i].gameObject.name.Contains("Local");
						if (flag2)
						{
							playerDistance = Vector3.Distance(players[i].gameObject.transform.position, hand[0].gameObject.transform.position);
							playerToKill = players[i];
						}
						num = i + 1;
					}
					int j = 0;
					while (j < 31)
					{
						string playerNode = "Player Node (" + j.ToString() + ")";
						string playerEntry = "Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + j.ToString() + ")/Player Name Text";
						bool flag3 = GameObject.Find(playerEntry).GetComponent<Text>().text.Equals(playerToKill.prop_APIUser_0.displayName);
						if (flag3)
						{
							Logs.Log("[" + j.ToString() + "]", false);
							UdonBehaviour playerKiller = GameObject.Find(playerNode).GetComponent<UdonBehaviour>();
							playerKiller.SendCustomNetworkEvent(NetworkEventTarget.All, "SyncAssignB");
							playerKiller = null;
						}
						int num2 = j + 1;
						j = num2;
						playerNode = null;
						playerEntry = null;
					}
					stopperRight = true;
					playerToKill = null;
					players = null;
				}
				else
				{
					bool flag4 = hand[0].field_Internal_VRCInput_1.field_Public_Single_0 == 0f;
					if (flag4)
					{
						stopperRight = false;
					}
				}
				yield return null;
			}
			yield break;
		}
		private static IEnumerator TouchOfDeath()
		{
			VRCHandGrasper[] hand = UnityEngine.Object.FindObjectsOfType<VRCHandGrasper>();
			bool stopperLeft = false;
			for (; ; )
			{
				bool flag = hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 1f && !stopperLeft && hand[1].field_Internal_VRCInput_2.field_Public_Single_0 == 1f;
				if (flag)
				{
					float playerDistance = 999f;
					Player playerToKill = null;
					Player[] players = PlayerManager.prop_PlayerManager_0.gameObject.GetComponentsInChildren<Player>();
					int num;
					for (int i = 0; i < players.Length; i = num)
					{
						bool flag2 = Vector3.Distance(players[i].gameObject.transform.position, hand[1].gameObject.transform.position) < playerDistance && !players[i].gameObject.name.Contains("Local");
						if (flag2)
						{
							playerDistance = Vector3.Distance(players[i].gameObject.transform.position, hand[1].gameObject.transform.position);
							playerToKill = players[i];
						}
						num = i + 1;
					}
					int j = 0;
					while (j < 31)
					{
						string playerNode = "Player Node (" + j.ToString() + ")";
						string playerEntry = "Game Logic/Game Canvas/Game In Progress/Player List/Player List Group/Player Entry (" + j.ToString() + ")/Player Name Text";
						bool flag3 = GameObject.Find(playerEntry).GetComponent<Text>().text.Equals(playerToKill.prop_APIUser_0.displayName);
						if (flag3)
						{
							UdonBehaviour playerKiller = GameObject.Find(playerNode).GetComponent<UdonBehaviour>();
							playerKiller.SendCustomNetworkEvent(NetworkEventTarget.All, "SyncKill");
							playerKiller = null;
						}
						int num2 = j + 1;
						j = num2;
						playerNode = null;
						playerEntry = null;
					}
					stopperLeft = true;
					playerToKill = null;
					players = null;
				}
				else
				{
					bool flag4 = hand[1].field_Internal_VRCInput_1.field_Public_Single_0 == 0f;
					if (flag4)
					{
						stopperLeft = false;
					}
				}
				yield return null;
			}
			yield break;
		}
		public static void StartUniversal()
		{

			new QMToggleButton(MurderMenu.godMurder, 1f, 0f, "Hands\nOf\nDeath", delegate ()
			{
				try
				{
					TouchStuff.actionforontap = "SyncKill";
					GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
					gameObject.name = "CreClient";
					gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
					gameObject.transform.parent = VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.RightHand).gameObject.transform;
					gameObject.transform.localPosition = new Vector3(0f, 0.005f, 0f);
					gameObject.AddComponent<TouchStuff>();
					gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
					gameObject.AddComponent<Rigidbody>().isKinematic = true;
					gameObject.layer = 2;
				}
				catch
				{
				}
			}, delegate ()
			{
				try
				{
					TouchStuff.actionforontap = "SyncKill";
					GameObject gameObject = VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.RightHand).gameObject;
					UnityEngine.Object.Destroy(gameObject.transform.Find("CreClient").gameObject);
				}
				catch
				{
				}
			}, "", false);
			new QMToggleButton(MurderMenu.godMurder, 2f, 0f, "Hands\nOf\nLife\n(Bystand)", delegate ()
			{
				try
				{
					TouchStuff.actionforontap = "SyncAssignB";
					GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
					gameObject.name = "CreClient";
					gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
					gameObject.transform.parent = VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.RightHand).gameObject.transform;
					gameObject.transform.localPosition = new Vector3(0f, 0.005f, 0f);
					gameObject.AddComponent<TouchStuff>();
					gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
					gameObject.AddComponent<Rigidbody>().isKinematic = true;
					gameObject.layer = 2;
				}
				catch
				{
				}
			}, delegate ()
			{
				try
				{
					TouchStuff.actionforontap = "SyncKill";
					GameObject gameObject = VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.RightHand).gameObject;
					UnityEngine.Object.Destroy(gameObject.transform.Find("CreClient").gameObject);
				}
				catch
				{
				}
			}, "", false);
			new QMToggleButton(MurderMenu.godMurder, 3f, 0f, "Hands\nOf\nLife\n(Murder)", delegate ()
			{
				try
				{
					TouchStuff.actionforontap = "SyncAssignM";
					GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
					gameObject.name = "CreClient";
					gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
					gameObject.transform.parent = VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.RightHand).gameObject.transform;
					gameObject.transform.localPosition = new Vector3(0f, 0.005f, 0f);
					gameObject.AddComponent<TouchStuff>();
					gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
					gameObject.AddComponent<Rigidbody>().isKinematic = true;
					gameObject.layer = 2;
				}
				catch
				{
				}
			}, delegate ()
			{
				try
				{
					TouchStuff.actionforontap = "SyncKill";
					GameObject gameObject = VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.RightHand).gameObject;
					UnityEngine.Object.Destroy(gameObject.transform.Find("CreClient").gameObject);
				}
				catch
				{
				}
			}, "", false);
		}
		private static object touchOfDeathCor;
		private static object touchOfLifeCor;
		private static object touchOfDeathCor1;
		private static object touchOfLifeCor1;
	}
}

