using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using VRC.SDKBase;
using UnityEngine;
using CreClient.Settings;
using VRC.Udon;
using VRCSDK2;
using VRC;
using MelonLoader;
using VRC.Core;
using VRC.SDK3.Components;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using System.Collections;
using VRC.UI;
using Object = UnityEngine.Object;
using VRC_Pickup = VRC.SDKBase.VRC_Pickup;
using Harmony;

namespace CreClient.Modules
{
	class MethodsTwo
	{

		public static object AntiTheftcor;
		public static void BringPickups()
		{
			foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
			{
				Networking.LocalPlayer.TakeOwnership(vrc_Pickup.gameObject);
				vrc_Pickup.transform.localPosition = new Vector3(0f, 0f, 0f);
				Transform transform = vrc_Pickup.transform;
				Player player = Player.prop_Player_0;
				Player targetPlayer = Shared.TargetPlayer;				
				transform.transform.position = player.transform.position + new Vector3(0f, 0.5f, 0f);
			}
		}
		public static void DeletePortals()
		{
			PortalTrigger[] array = Resources.FindObjectsOfTypeAll<PortalTrigger>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.activeInHierarchy && !(array[i].gameObject.GetComponentInParent<VRC.SDKBase.VRC_PortalMarker>() != null))
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
		}
		public static void RespawnPickups()
		{
			foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
			{
				Networking.LocalPlayer.TakeOwnership(vrc_Pickup.gameObject);
				vrc_Pickup.transform.position = new Vector3(0f, -10000000f, 0f);
			}
		}
		public static void ForcePickups()
		{
			VRC.SDKBase.VRC_Pickup[] array = UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DisallowTheft = false;
			}
		}
		public static void ForceClose()
		{
			{
				#region
				
				//MelonLogger.Msg("Playing Banger!");
				//var video = "https://youtu.be/svsG-zP6INk?t=52";

				//Process.Start(video);
				Process.GetCurrentProcess().Kill();
				#endregion
			}
		}
        public static IEnumerator BetterAntiTheft()
		{
			while(true)
			{ 
			VRCHandGrasper[] hand = Object.FindObjectsOfType<VRCHandGrasper>();
			Object.FindObjectsOfType<Player>();
			VRCInput inputForVRC = hand[0].field_Internal_VRCInput_2;
			VRCInput inputForVRC2 = hand[1].field_Internal_VRCInput_2;
			GameObject objectToStick = null;
			VRC_Pickup objectPickup = null;
			GameObject objectToStick2 = null;
			VRC_Pickup objectPickup2 = null;
			VRCPlayerApi currentPlayer = Networking.LocalPlayer;
			for (;;)
			{
				bool flag = inputForVRC.field_Public_Single_0 == 0f && objectToStick != null;
				if (flag)
				{
					objectPickup.Drop();
                    Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable> interactions4 = new Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable>();
					hand[0].field_Private_Boolean_2 = false;
					hand[0].field_Private_List_1_VRC_Interactable_0 = interactions4;
					objectPickup.currentLocalPlayer = null;
					objectPickup.currentlyHeldBy = null;
					hand[0].field_Internal_VRC_Pickup_0 = null;
					hand[0].field_Private_Rigidbody_0 = null;
					hand[0].field_Private_VRC_Pickup_0 = null;
					objectToStick = null;
					objectPickup = null;
					interactions4 = null;
				}
				bool flag2 = hand[0].field_Internal_VRC_Pickup_0 != null && objectToStick == null;
				if (flag2)
				{
					objectToStick = hand[0].field_Internal_VRC_Pickup_0.gameObject;
					objectPickup = hand[0].field_Internal_VRC_Pickup_0;
				}
				bool flag3 = objectToStick != null && inputForVRC.field_Public_Single_0 != 0f;
				if (flag3)
				{
					bool flag4 = Networking.GetOwner(objectToStick) != Networking.LocalPlayer;
					if (flag4)
					{
						Networking.LocalPlayer.TakeOwnership(objectToStick);
					}
					hand[0].field_Internal_VRC_Pickup_0 = objectToStick.GetComponent<VRC_Pickup>();
					hand[0].field_Private_Rigidbody_0 = objectToStick.GetComponent<Rigidbody>();
					hand[0].field_Private_VRC_Pickup_0 = objectToStick.GetComponent<VRC_Pickup>();
                    Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable> interactions5 = new Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable>();
					UdonBehaviour[] udonBehaviours2 = objectToStick.GetComponents<UdonBehaviour>();
					int num;
					for (int i = 0; i < udonBehaviours2.Length; i = num)
					{
						interactions5.Add(udonBehaviours2[i]);
						num = i + 1;
					}
					hand[0].field_Private_Boolean_2 = true;
					hand[0].field_Private_List_1_VRC_Interactable_0 = interactions5;
					objectPickup.currentLocalPlayer = currentPlayer;
					objectPickup.currentlyHeldBy = hand[0];
					bool flag5 = Networking.GetOwner(objectToStick) != Networking.LocalPlayer;
					if (flag5)
					{
						Networking.LocalPlayer.TakeOwnership(objectToStick);
					}
					interactions5 = null;
					udonBehaviours2 = null;
				}
				bool flag6 = inputForVRC2.field_Public_Single_0 == 0f && objectToStick2 != null;
				if (flag6)
				{
					objectPickup2.Drop();
                    Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable> interactions6 = new Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable>();
					hand[1].field_Private_Boolean_2 = false;
					hand[1].field_Private_List_1_VRC_Interactable_0 = interactions6;
					objectPickup2.currentLocalPlayer = null;
					objectPickup2.currentlyHeldBy = null;
					hand[1].field_Internal_VRC_Pickup_0 = null;
					hand[1].field_Private_Rigidbody_0 = null;
					hand[1].field_Private_VRC_Pickup_0 = null;
					objectToStick2 = null;
					objectPickup2 = null;
					interactions6 = null;
				}
				bool flag7 = hand[1].field_Internal_VRC_Pickup_0 != null && objectToStick2 == null;
				if (flag7)
				{
					objectToStick2 = hand[1].field_Internal_VRC_Pickup_0.gameObject;
					objectPickup2 = hand[1].field_Internal_VRC_Pickup_0;
				}
				bool flag8 = objectToStick2 != null && inputForVRC2.field_Public_Single_0 != 0f;
					if (flag8)
					{
						bool flag9 = Networking.GetOwner(objectToStick2) != Networking.LocalPlayer;
						if (flag9)
						{
							Networking.LocalPlayer.TakeOwnership(objectToStick2);
						}
						hand[1].field_Internal_VRC_Pickup_0 = objectToStick2.GetComponent<VRC_Pickup>();
						hand[1].field_Private_Rigidbody_0 = objectToStick2.GetComponent<Rigidbody>();
						hand[1].field_Private_VRC_Pickup_0 = objectToStick2.GetComponent<VRC_Pickup>();
						Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable> interactions7 = new Il2CppSystem.Collections.Generic.List<VRC.SDKBase.VRC_Interactable>();
						UdonBehaviour[] udonBehaviours3 = objectToStick2.GetComponents<UdonBehaviour>();
						int num2;
						for (int j = 0; j < udonBehaviours3.Length; j = num2)
						{
							interactions7.Add(udonBehaviours3[j]);
							num2 = j + 1;
						}
						hand[1].field_Private_Boolean_2 = true;
						hand[1].field_Private_List_1_VRC_Interactable_0 = interactions7;
						objectPickup2.currentLocalPlayer = currentPlayer;
						objectPickup2.currentlyHeldBy = hand[1];
						objectPickup2.AutoHold = (VRC_Pickup.AutoHoldMode)1;
						bool flag10 = Networking.GetOwner(objectToStick2) != Networking.LocalPlayer;
						if (flag10)
						{
							Networking.LocalPlayer.TakeOwnership(objectToStick2);
						}
						interactions7 = null;
						udonBehaviours3 = null;
					}
					yield return null;
				}				
			}
		}
		


		public static void ChangeAvatar(string AvatarID)
		{
			PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
			component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
			{
				id = AvatarID
			};
			component.ChangeToSelectedAvatar();
		}
		public static void DropPickups()
		{
			foreach (VRC.SDKBase.VRC_Pickup vrc_Pickup in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Pickup>())
			{
				if (Networking.GetOwner(vrc_Pickup.gameObject) != Networking.LocalPlayer)
				{
					Networking.SetOwner(Networking.LocalPlayer, vrc_Pickup.gameObject);
				}
				vrc_Pickup.Drop();
			}
		}
		public static void UseAll()
		{
			Vector3 position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position;
			Quaternion rotation = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.rotation;
			foreach (VRC.SDKBase.VRC_Trigger vrc_Trigger in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_Trigger>())
			{
				if (Networking.GetOwner(vrc_Trigger.gameObject) != Networking.LocalPlayer)
				{
					Networking.SetOwner(Networking.LocalPlayer, vrc_Trigger.gameObject);
				}
				vrc_Trigger.Interact();
			}
			VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = position;
			VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.rotation = rotation;
		}
		public static bool closeGame = false;
		public static void ForceRestart()
		{
			{
				MelonLogger.Msg("Restarting.");
				try { Process.Start(System.Environment.CurrentDirectory + "\\VRChat.exe", System.Environment.CommandLine.ToString()); }
				catch (System.Exception) { new System.Exception(); }

				Process.GetCurrentProcess().Kill();
			}
		}

		public static void ForceJump()
		{
			Networking.LocalPlayer.SetJumpImpulse(3f);
		}
		

		public static void Teleport(Vector3 pos)
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = pos;
		}
		public static Player GetPlayerByID(string id)
		{
            Il2CppSystem.Collections.Generic.List<Player> field_Private_List_1_Player_ = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
			for (int i = 0; i < field_Private_List_1_Player_.Count; i++)
			{
				if (field_Private_List_1_Player_[i].field_Private_APIUser_0.id == id)
				{
					return field_Private_List_1_Player_[i];
				}
			}
			return null;
		}
		
		public static  Player GetPlayer(string name)
		{
			Il2CppSystem.Collections.Generic.List<Player> field_Private_List_1_Player_ = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
			for (int i = 0; i < field_Private_List_1_Player_.Count; i++)
			{
				if (field_Private_List_1_Player_[i].field_Private_APIUser_0.displayName == name)
				{
					return field_Private_List_1_Player_[i];
				}
			}
			return null;
		}	
		public static void ForceClone()
        {
			
			
		}
		public static void ForceAdd()
		{
			string id = "usr_d1db6b4d-ee0a-46f9-bd5e-82875fd5f661";
			bool v = APIUser.Exists((APIUser)id);
			if (v)
			{
				APIUser.LocalAddFriend((APIUser)id);
			}
		}
		public static void UdonNuke()
        {
			foreach (var Udon in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())

            {
                foreach (var UdonEvent in Udon._eventTable)
                {
                    Udon.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, UdonEvent.Key);
                }
            }
        }
		public static void SpawnDetectivePortal()
		{
			GameObject gameObject = Networking.Instantiate(0, "Portals/PortalInternalDynamic", new Vector3(4.9533f, 2.995f, 126.9965f), Quaternion.identity);
			bool flag = gameObject == null;
			if (!flag)
			{
				
				RPC.Destination destination = (RPC.Destination)7;
				GameObject gameObject2 = gameObject;
				string text = "ConfigurePortal";
				Il2CppSystem.Object[] array = new Il2CppSystem.Object[3];
				array[0] = "wrld_9cebd25e-2f85-4808-9ff2-c0aedf60c207";
				array[1] = "54327";
				int num = 2;
				Il2CppSystem.Int32 @int = default(Il2CppSystem.Int32);
				@int.m_value = 1;
				array[num] = @int.BoxIl2CppObject();
				Networking.RPC(destination, gameObject2, text, array);
			}
		}
		public static void SpawnDetectivePortalInF()
		{
			var Me = Player.prop_Player_0;
			GameObject gameObject = Networking.Instantiate(0, "Portals/PortalInternalDynamic", Me.transform.position + new Vector3(0f, 0.2f, 1.5f), Quaternion.identity);
			bool flag = gameObject == null;
			if (!flag)
			{
				
				
				RPC.Destination destination = (RPC.Destination)7;
				GameObject gameObject2 = gameObject;
				string text = "ConfigurePortal";
				Il2CppSystem.Object[] array = new Il2CppSystem.Object[3];
				array[0] = "wrld_9cebd25e-2f85-4808-9ff2-c0aedf60c207";
				array[1] = "54327";
				int num = 2;
				Il2CppSystem.Int32 @int = default(Il2CppSystem.Int32);
				@int.m_value = 1;
				array[num] = @int.BoxIl2CppObject();
				Networking.RPC(destination, gameObject2, text, array);
			}
		}
	}
}	

