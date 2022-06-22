using System.IO;
using UnityEngine;

namespace CreClient.Settings
{
    public static class Files
    {
        public static string MainDir = Directory.GetParent(Application.dataPath) + "\\CreClient";
        public static string LogsDir = MainDir + "\\Logs";
        public static string PlayerLogsFile = LogsDir + "\\PlayerLogs.txt";
        public static string WorldLogsFile = LogsDir + "\\WorldLogs.txt";
        public static string AvatarLogsFile = LogsDir + "\\AvatarLogs.txt";
        public static void Create()
        {
            Directory.CreateDirectory(MainDir);
        }
    }
    
}
