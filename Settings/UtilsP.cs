using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.UI.Elements.Menus;
using UnityEngine.SceneManagement;
using VRC;
using VRC.Core;
using VRC.Management;
using VRC.SDKBase;
using CreClient.Modules;
using System.IO;
using System.Net;
using VRC;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRCSDK2;
using UnhollowerBaseLib;
using System.Windows.Forms;

namespace CreClient.Settings
{
    internal class UtilsP
    {
        public static Player istargeted;

        internal static Player GetCurrentlySelectedPlayer()
        {
            if (GameObject.Find("UserInterface").GetComponentInChildren<SelectedUserMenuQM>() == null)
            {
                return null;
            }

            return GetPlayerFromIDInLobby(GameObject.Find("UserInterface").gameObject.GetComponentInChildren<SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0);
        }

        internal static Player GetPlayerFromIDInLobby(string id)
        {
            List<Player> all_player = GetAllPlayers();

            foreach (var player in all_player)
            {
                if (player != null && player.prop_APIUser_0 != null)
                {
                    if (player.prop_APIUser_0.id == id)
                    {
                        UtilsP.istargeted = player;
                        return player;
                    }
                }
            }

            return null;

        }
        public static VRCPlayer GetSelectedUser()
        {
            var a = Object.FindObjectOfType<SelectedUserMenuQM>().field_Private_IUser_0;
            return GetPlayerByUserID(a.prop_String_0)._vrcplayer;
        }
        public static Player GetPlayerByUserID(string userID)
        {
            return GetPlayers().FirstOrDefault(p => p.prop_APIUser_0.id == userID);
        }
        public static IEnumerable<Player> GetPlayers()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        }       
        internal static Player TargetCre(string id = "usr_05c3e951-47d2-4528-a3be-65a389428bcf")
        {
            
            List<Player> all_player = GetAllPlayers();

            foreach (var player in all_player)
            {
                if (player != null && player.prop_APIUser_0 != null)
                {
                    if (player.prop_APIUser_0.id == id)
                    {
                        return player;
                    }
                }
            }

            return null;
        }
        public static ApiWorldInstance CurrentInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }
        
       
        public static void ClipBoardWorld()
        {
            var room = CurrentInstance();           
            Clipboard.SetText(room.ToString());
            
            
        }

        internal static List<Player> GetAllPlayers()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0 == null ? null : PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray().ToList();
        }
        internal static Sprite CreateSpriteFromTex(Texture2D tex)
        {
            Sprite sprite = Sprite.CreateSprite(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f, 0, 0, new Vector4(), false);

            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            return sprite;
        }
    }
}
