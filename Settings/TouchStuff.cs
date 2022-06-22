using System;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC.SDKBase;

namespace CreClient.Settings
{
	
	internal class TouchStuff : MonoBehaviour
	{

		private void OnCollisionEnter(Collision collision)
		{
			bool flag = collision.gameObject.name.Contains("VRCPlayer[Remote]");
			if (flag)
			{
				try
				{
					Logs.Log(collision.gameObject.GetComponent<Player>().prop_VRCPlayerApi_0.displayName + " - " + actionforontap, false);
					Logs.Log(collision.gameObject.GetComponent<Player>().prop_VRCPlayerApi_0.displayName + " - " + actionforontap, false);
					VRCPlayer component = collision.gameObject.GetComponent<VRCPlayer>();
					Player player = component.GetComponent<VRCPlayer>()._player;
					GameObject gameObject = GameObject.Find("Player Nodes");
					foreach (UdonBehaviour udonBehaviour in gameObject.GetComponentsInChildren<UdonBehaviour>())
					{
						Networking.SetOwner(player.prop_VRCPlayerApi_0, udonBehaviour.gameObject);
						udonBehaviour.SendCustomNetworkEvent(NetworkEventTarget.Owner, actionforontap);
					}
				}
				catch
				{
				}
			}
		}
		private void OnTriggerEnter(Collider col)
		{
			bool flag = col.gameObject.name.Contains("VRCPlayer[Remote]");
			if (flag)
			{
				try
				{
					Logs.Log(col.gameObject.GetComponent<Player>().prop_VRCPlayerApi_0.displayName + " - " + actionforontap,false);
					Logs.Log(col.gameObject.GetComponent<Player>().prop_VRCPlayerApi_0.displayName + " - " + actionforontap, false);
					VRCPlayer component = col.gameObject.GetComponent<VRCPlayer>();
					Player player = component.GetComponent<VRCPlayer>()._player;
					GameObject gameObject = GameObject.Find("Player Nodes");
					foreach (UdonBehaviour udonBehaviour in gameObject.GetComponentsInChildren<UdonBehaviour>())
					{
						Networking.SetOwner(player.field_Private_VRCPlayerApi_0, udonBehaviour.gameObject);
						udonBehaviour.SendCustomNetworkEvent(NetworkEventTarget.Owner, actionforontap);
					}
				}
				catch
				{
				}
			}
		}
		public static bool cooldown;
		public static string actionforontap;
		internal static TouchStuff wkjRdurQus78AaxVrx9;
	}
}

