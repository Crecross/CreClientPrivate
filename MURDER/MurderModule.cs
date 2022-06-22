using System;
using System.Collections.Generic;
using Il2CppSystem;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using VRC.Udon;
using MelonLoader;
using Astrum.AstralCore;
using VRC.DataModel;

namespace CreClientTest.BAPI
{
	public class MurderModule
    {
		public MurderModule()
		{
			GameObject.Find("Game Logic/Player HUD/Blind HUD Anim").active = false;
			GameObject.Find("Game Logic/Player HUD/Flashbang HUD Anim").active = false;
			GameObject gameObject = GameObject.Find("Game Logic/Weapons/Revolver");
			MurderModule.revolver = ((gameObject != null) ? gameObject.GetComponent<UdonBehaviour>() : null);
			GameObject gameObject2 = GameObject.Find("Game Logic/Weapons/Unlockables/Frag (0)");
			MurderModule.frag = ((gameObject2 != null) ? gameObject2.GetComponent<UdonBehaviour>() : null);
			MurderModule.i = 0;
			Transform transform = GameObject.Find("Game Logic/Switch Boxes").transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				MurderModule.lights.Add(transform.GetChild(i).GetComponent<UdonBehaviour>());
			}
			Events.OnUpdate = (System.Action)System.Delegate.Combine(Events.OnUpdate, new System.Action(MurderModule.OnUpdate));
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002120 File Offset: 0x00000320
		~MurderModule()
		{
			Events.OnUpdate = (System.Action)System.Delegate.Remove(Events.OnUpdate, new System.Action(MurderModule.OnUpdate));
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002168 File Offset: 0x00000368
		private static void OnUpdate()
		{
			
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021F4 File Offset: 0x000003F4
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

		// Token: 0x06000005 RID: 5 RVA: 0x00002280 File Offset: 0x00000480
		public static void SpamDetectiveRevolver()
		{
			UdonBehaviour udonBehaviour = MurderModule.revolver;
			if (udonBehaviour != null)
			{
				udonBehaviour.SendCustomNetworkEvent(0, "SyncFire");
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000229C File Offset: 0x0000049C
		public static void ExplodeRandom()
		{
			MurderModule.i++;
			bool flag = MurderModule.i >= PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.Count;
			if (flag)
			{
				MurderModule.i = 0;
			}
			Player player = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0[MurderModule.i];
			bool isLocal = player.field_Private_VRCPlayerApi_0.isLocal;
			if (isLocal)
			{
				MurderModule.ExplodeRandom();
			}
			else
			{
				bool flag2 = Networking.GetOwner(MurderModule.frag.gameObject) != Networking.LocalPlayer;
				if (flag2)
				{
					Networking.SetOwner(Networking.LocalPlayer, MurderModule.frag.gameObject);
				}
				MurderModule.frag.transform.position = player.transform.position;
				MurderModule.frag.SendCustomNetworkEvent(0, "Explode");
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002364 File Offset: 0x00000564
		public static void LightsOut()
		{
			for (int i = 0; i < MurderModule.lights.Count; i++)
			{
				MurderModule.lights[i].SendCustomNetworkEvent(0, "SwitchDown");
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023A4 File Offset: 0x000005A4
		public static void FixBounds()
		{
			GameObject.Find("Game Logic").GetComponent<UdonBehaviour>().enabled = false;
			GameObject.Find("Game Logic/Game Area Bounds").transform.localScale = new Vector3(1000f, 1000f, 1000f);
		}
		public static void TPToRev()
		{
			Player player = Player.prop_Player_0;
			Transform transform = GameObject.Find("Revolver").transform;			
			Transform transform2 = transform.transform;
			//Player targetPlayer = Shared.TargetPlayer;
			//transform2.position = ((targetPlayer != null) ? targetPlayer.transform.position : player + new Vector3(0f, 0.5f, 0f);
			player.transform.position = transform.transform.position + new Vector3(0f, 0.5f, 0f);
			//GameObject.Find("Game Logic/Game Area Bounds").transform.localScale = new Vector3(50f, 50f, 50f);
		}

		// Token: 0x04000001 RID: 1
		private static UdonBehaviour revolver;

		// Token: 0x04000002 RID: 2
		private static UdonBehaviour frag;

		// Token: 0x04000003 RID: 3
		private static List<UdonBehaviour> lights = new List<UdonBehaviour>();

		// Token: 0x04000004 RID: 4
		private static int i = 0;
	}
}
