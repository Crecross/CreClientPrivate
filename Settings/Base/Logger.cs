using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CreClientTest.Settings
{
    class LoggerUtill
    {
        private static List<string> DebugLogs = new List<string>();
        private static int duplicateCount = 1;
        private static string lastMsg = "";

        public static void DisplayLogo()
        {
            Console.Title = "CreClient";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============================================================================================================");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                 Beta Release By Four_DJ, Literal, and Fish.                                 ");
            Console.WriteLine("=============================================================================================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void LogDebug(string message)
        {
            if (message == lastMsg)
            {
                DebugLogs.RemoveAt(DebugLogs.Count - 1);
                duplicateCount++;
                DebugLogs.Add($"<color=white><b>[<color=blue>CreClient</color>] [<color=#0000FF>{DateTime.Now.ToString("hh:mm tt")}</color>] {message} <color=red><i>x{duplicateCount}</i></color></b></color>");
            }
            else
            {
                lastMsg = message;
                duplicateCount = 1;
                DebugLogs.Add($"<color=white><b>[<color=red>CreClient</color>] [<color=#0000FF>{DateTime.Now.ToString("hh:mm tt")}</color>] {message}</b></color>");
                if (DebugLogs.Count == 25)
                {
                    DebugLogs.RemoveAt(0);
                }
            }
            
        }

        public static void Log(string msg, ConsoleColor color = ConsoleColor.White, bool debug = false)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("CreClient");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(DateTime.Now.ToString("hh:mm"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            if (debug)
                LogDebug(msg);
        }
    }
}
