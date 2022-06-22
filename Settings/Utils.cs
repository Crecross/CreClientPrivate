using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using Action = System.Action;
using Exception = System.Exception;
using HashAlgorithm = System.Security.Cryptography.HashAlgorithm;
using SHA256Managed = System.Security.Cryptography.SHA256Managed;

namespace CreClient.Settings
{
    public class Utils
    {
        private static System.Action<Player> requestedAction;
        private static VRC_SceneDescriptor descriptor;
        public static string[] cachedPrefabs;

        public static System.Drawing.Image GetImageFromResources(string imageName)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
            string[] array = manifestResourceNames;
            foreach (string text in array)
            {
                bool flag = text.EndsWith(".png") && text.Contains(imageName);
                if (flag)
                {
                    Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text);
                    MemoryStream memoryStream = new MemoryStream();
                    manifestResourceStream.CopyTo(memoryStream);
                    return System.Drawing.Image.FromStream(memoryStream);
                }
            }
            return null;
        }
        public partial class ModTag
        {
            public string UserID { get; set; }
            public List<string> tags { get; set; }
            public string AccessType { get; set; }
        }
        public static Sprite MakeSpriteFromImage(System.Drawing.Image image)
        {
            bool flag = image == null;
            Sprite result;
            if (flag)
            {
                result = null;
            }
            else
            {
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Png);
                Texture2D texture2D = new Texture2D(1024, 1024);
                bool flag2 = !Il2CppImageConversionManager.LoadImage(texture2D, memoryStream.ToArray());
                Sprite sprite;
                if (flag2)
                {
                    sprite = null;
                }
                else
                {
                    Sprite sprite2 = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2((float)(texture2D.width / 2), (float)(texture2D.height / 2)), 100000f, 1000U, 0, default(Vector4), false);
                    sprite = sprite2;
                }
                result = sprite;
            }
            return result;
        }

        public static void SelectPlayer(Player user)
        {
            QuickMenu.prop_QuickMenu_0.Method_Public_Void_Player_0(user);
        }

        public static void GetEachPlayer(System.Action<Player> act)
        {
            Utils.requestedAction = act;
            foreach (Player obj in PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0)
            {
                Utils.requestedAction(obj);
            }
        }


        public void SaveImage(string fileName, string webLocation)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                System.Uri uri = new System.Uri(webLocation);
                try
                {
                    webClient.DownloadFileAsync(uri, fileName);
                }
                catch (Exception e)
                {
                    MelonLogger.Error(e.StackTrace);
                }
            }
        }
          

        public static Player GetPlayer(string name)
        {
            Il2CppSystem.Collections.Generic.List<Player> players = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].prop_APIUser_0.displayName == name)
                {
                    return players[i];
                }
            }

            return null;
        }
    }
}