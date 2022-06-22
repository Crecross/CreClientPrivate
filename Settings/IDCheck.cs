
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using VRC;
using VRC.Core;
using System.Net;
using System.Collections;
using MelonLoader;
using CreClient.Modules;
using System.Security.Cryptography;
using UnityEngine;
using Newtonsoft.Json;



namespace CreClient.Settings
{
    public class IDCheck
    {      

        public static IEnumerator StartIDCheck()
        {
            WebClient auth = new();
            string authText = auth.DownloadString("https://raw.githubusercontent.com/Crecross/CreClient/main/CreClientAuth");
            string[] DataBase = authText.Split(Array.Empty<char>());
            while (APIUser.CurrentUser == null)
            {
                yield return null;
            }
            int num;
            for (int i = 0; i < DataBase.Length; i = num + 1)
            {
                bool isAuth = DataBase.Contains(APIUser.CurrentUser.id);
                if (isAuth)
                {
                    MelonCoroutines.Start(Main_BlazeAPI.StartUiManagerInitIEnumeratorPrivate());
                    Logs.LogGeneral("You are verified as a CreClient Private User", false);
                    yield break;
                }
                bool isnotAuth = !DataBase.Contains(APIUser.CurrentUser.id);
                if (isnotAuth)
                {
                    MelonCoroutines.Start(Main_BlazeAPI.StartUiManagerInitIEnumerator());
                    Logs.LogGeneral("You are NOT verified as a CreClient Private User", false);
                    auth.Dispose();
                    yield return new WaitForSeconds(3f);
                    yield break;
                                    
                }                    
                num = i;
            }
            yield break;
        }
        public static IEnumerator BlackListCheck()
        {
            WebClient blackList = new();
            string authBlack = blackList.DownloadString("https://raw.githubusercontent.com/Crecross/CreClient/main/CreClientBlackList");
            string[] blacklistdataBase = authBlack.Split(Array.Empty<char>());
            while (APIUser.CurrentUser == null)
            {
                yield return null;
            }
            int num;
            for (int i = 0; i < blacklistdataBase.Length; i = num + 1)
            {
                bool isBlacklisted = blacklistdataBase.Contains(APIUser.CurrentUser.id);
                if (isBlacklisted)
                {
                    Logs.LogGeneral("You are banned from CreClient", false);
                    blackList.Dispose();
                    var cc = MelonUtils.GameDirectory + "\\Mods\\CreClientTest.dll";
                    File.Delete(cc);
                    yield return new WaitForSeconds(3f);
                    MethodsTwo.ForceClose();
                    yield break;
                }
                bool isnotblackListed = !blacklistdataBase.Contains(APIUser.CurrentUser.id);
                if (isnotblackListed)
                {
                    Logs.LogGeneral("You are not Blacklisted!", false);
                    yield return new WaitForSeconds(3f);
                    yield break;

                }
                num = i;
            }

        }

    }
}
