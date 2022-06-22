using Blaze.Core;
using Blaze.Utils;
using Blaze.Utils.Managers;
using Blaze.Utils.VRChat;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.Core;

namespace CreClientTest
{
	public class CrePlates : CreModule
	{
		public override void OnPlayerJoined(Player player)
		{
			Enable(player);
		}

		public static void Enable(Player player)
		{
			if (player?.field_Private_APIUser_0 is null) return;
			Transform contents = player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
			Transform stats = contents.Find("Quick Stats");

			try
			{
				if (Config.Main.NameplateColors && !CompatibilityHandler.VRToolFound)
				{
					stats.GetComponent<ImageThreeSlice>().color = player.field_Private_APIUser_0.GetRankUnityColor();
				}
			}
			catch (Exception ex) { Logs.Error("Error updating nameplate colors", ex); }

			try
			{
				if (Config.Main.NameplateDesigns)
				{
					stats.GetComponent<ImageThreeSlice>().prop_Sprite_0 = AssetBundleManager.MainNameplate;
				}
			}
			catch (Exception ex) { Logs.Error("Error updating nameplate designs", ex); }

			try
			{
				int i = 0;
				for (; ; )
				{
					Transform tag = contents.Find($"BlazeTag{i}");
					if (tag is null) break;
					tag.gameObject.active = false;
					i++;
				}
			}
			catch (Exception ex) { Logs.Error("Error checking existing tags", ex); }

			int stack = 0;
			try
			{
				if (Main.Tags.Exists(x => x.UserID == player.field_Private_APIUser_0.id))
				{
					var tagInfo = Main.Tags.Find(x => x.UserID == player.field_Private_APIUser_0.id);
					foreach (var tag in tagInfo.tags)
					{
						SetTag(ref stack, stats, contents, Color.white, tag);
					}
				}
			}
			catch (Exception ex) { Logs.Error("error checking for blaze network tags", ex); }

			try
			{
				if (Main.OtherBCUsers != null)
				{
					if (Main.OtherBCUsers.Exists(x => x.UserID == player.field_Private_APIUser_0.id))
					{
						var tagInfo = Main.OtherBCUsers.Find(x => x.UserID == player.field_Private_APIUser_0.id);
						if (tagInfo != null)
						{
							if (tagInfo.AccessType != null)
							{
								switch (tagInfo.AccessType)
								{
									case "Developer":
										SetTag(ref stack, stats, contents, Color.white, $"<color={Colors.AquaHex}>Blaze's</color> <color={Colors.MagentaHex}>Client</color> <color=red>Developer</color> <color={Colors.PinkHex}><3</color>");
										break;

									case "Staff":
										SetTag(ref stack, stats, contents, Color.white, $"<color={Colors.AquaHex}>Blaze's</color> <color={Colors.MagentaHex}>Client</color> <color=yellow>Staff</color> <color={Colors.PinkHex}><3</color>");
										break;

									default:
										SetTag(ref stack, stats, contents, Color.white, $"<color={Colors.AquaHex}>Blaze's</color> <color={Colors.MagentaHex}>Client</color> User <color={Colors.PinkHex}><3</color>");
										break;
								}
							}
						}
					}
				}
			}
			catch (Exception ex) { Logs.Error("error checking for blaze user tag", ex); }

			try
			{
				stats.localPosition = new Vector3(0, (stack + 1) * 30, 0);
			}
			catch (Exception ex) { Logs.Error("error moving stats tag position", ex); }
		}

		public static void Disable(Player player)
		{
			try
			{
				Transform contents = player.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
				Transform main = contents.Find("Main");
				Transform icon = contents.Find("Icon");
				Transform stats = contents.Find("Quick Stats");

				main.Find("Background").GetComponent<ImageThreeSlice>().color = Color.white;
				main.Find("Pulse").GetComponent<ImageThreeSlice>().color = Color.white;
				main.Find("Glow").GetComponent<ImageThreeSlice>().color = Color.white;

				icon.Find("Background").GetComponent<Image>().color = Color.white;
				icon.Find("Pulse").GetComponent<Image>().color = Color.white;
				icon.Find("Glow").GetComponent<Image>().color = Color.white;

				stats.GetComponent<ImageThreeSlice>().color = Color.white;

				int i = 0;
				for (; ; )
				{
					Transform tag = contents.Find($"BlazeTag{i}");
					if (tag is null) break;

					tag.gameObject.active = false;
					i++;
				}
				stats.localPosition = new Vector3(0, 30, 0);
			}
			catch { }
		}

		private static Transform MakeTag(Transform stats, int index)
		{
			Transform rank = UnityEngine.Object.Instantiate(stats, stats.parent, false);
			rank.name = $"BlazeTag{index}";
			rank.localPosition = new Vector3(0, 30 * (index + 1), 0);
			rank.gameObject.active = true;
			Transform textGO = null;
			for (int i = rank.childCount; i > 0; i--)
			{
				Transform child = rank.GetChild(i - 1);
				if (child.name == "Trust Text")
				{
					textGO = child;
					continue;
				}
				UnityEngine.Object.Destroy(child.gameObject);
			}
			return textGO;
		}

		private static void SetTag(ref int stack, Transform stats, Transform contents, Color color, string content)
		{
			Transform tag = contents.Find($"BlazeTag{stack}");
			Transform label;
			if (tag == null)
				label = MakeTag(stats, stack);
			else
			{
				tag.gameObject.SetActive(true);
				label = tag.Find("Trust Text");
			}
			var text = label.GetComponent<TMPro.TextMeshProUGUI>();
			text.color = color;
			text.text = content;
			stack++;
		}

		public static void UpdateColors(bool colorState)
		{
			foreach (var p in WorldUtils.GetPlayers())
			{
				var transform = p.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
				var num = 0;
				for (; ; )
				{
					var transform2 = transform.Find(string.Format("BlazeTag{0}", num));
					if (transform2 == null) break;
					if (CompatibilityHandler.VRToolFound)
					{
						transform2.GetComponent<ImageThreeSlice>().color = new Color(0.211f, 0.254f, 0.321f, 1);
					}
					else
					{
						transform2.GetComponent<ImageThreeSlice>().color = colorState ? p.GetAPIUser().GetRankUnityColor() : new Color(1, 1, 1, 0.85f);
					}
					num++;
				}
			}
		}

		public static void UpdateTextures(bool newState)
		{
			foreach (var p in WorldUtils.GetPlayers())
			{
				var transform = p.transform.Find("Player Nameplate/Canvas/Nameplate/Contents");
				var num = 0;
				for (; ; )
				{
					var transform2 = transform.Find(string.Format("BlazeTag{0}", num));
					if (transform2 == null)
					{
						break;
					}
					transform2.GetComponent<ImageThreeSlice>().prop_Sprite_0 = newState ? AssetBundleManager.MainNameplate : p.GetComponent<PlayerCoreComp>().cachedPlateSprite;
					num++;
				}
			}
		}

		public static IEnumerator DelayedRefresh()
		{
			yield return new WaitForSeconds(1);
			Refresh();
		}

		public static void Refresh()
		{
			if (PlayerManager.field_Private_Static_PlayerManager_0?.field_Private_List_1_Player_0 == null) return;
			foreach (Player player in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
			{
				if (player?.field_Private_VRCPlayerApi_0 == null || player?.field_Private_APIUser_0 == null) continue;
				Enable(player);

				/*if (state) Enable(player);
				else Disable(player);*/
			}
		}
	}
}

