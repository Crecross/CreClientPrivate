using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using MelonLoader;
using System.Security.Cryptography;
using System.Diagnostics;

namespace CreClient.Settings
{
    public class SettingsP
    {
		internal static void UpdateCheck()
		{		
			try
			{
                using SHA256 sha = SHA256.Create();
                byte[] array = File.ReadAllBytes(MelonUtils.GameDirectory + "\\Mods\\CreClientTest.dll");
                WebClient webClient = new WebClient();
                using WebClient webClient2 = webClient;
                byte[] array2 = webClient2.DownloadData("https://github.com/Crecross/CreClient/releases/download/Mods/CreClientTest.dll");
                if (array == null)
                {
                    if (array2 == null)
                    {
                        MelonLogger.Error("Can't update CreClient");
                        return;
                    }
                    array = array2;
                    File.WriteAllBytes(MelonUtils.GameDirectory + "\\Mods\\CreClientTest.dll", array);
                }
                string a = ComputeHash(sha, array2);
                string b = ComputeHash(sha, array);
                if (a != b)
                {
                    array = array2;
                    File.WriteAllBytes(MelonUtils.GameDirectory + "\\Mods\\CreClientTest.dll", array);
                    Logs.Log("Updated CreClient", false);
                    Process.Start("VRChat.exe", Environment.CommandLine.ToString() ?? "");
                    Process.GetCurrentProcess().Kill();
                }
            }
			catch (FileNotFoundException)
			{
				Console.Beep(800, 1500);				
			}
		}
        private static string ComputeHash(HashAlgorithm sha256, byte[] data)
		{
			byte[] array = sha256.ComputeHash(data);
			StringBuilder stringBuilder = new();
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

}
