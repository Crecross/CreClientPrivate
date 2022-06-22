using System;

using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using AzuraClient.API.QM;

namespace CreClient.Settings
{
	internal static class Logs
	{
		
		public static void WriteToConsole(ConsoleColor Cre, string value1, ConsoleColor Client, string value2, ConsoleColor TextColor, string Text)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("[");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write(DateTime.Now.ToString("hh:mm:ss.ms"));
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("] [");
			Console.ForegroundColor = Cre;
			Console.Write(value1);
			Console.ForegroundColor = Client;
			Console.Write(value2);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("] ");
			Console.ForegroundColor = TextColor;
			Console.WriteLine(Text);
			Console.ResetColor();
		}

		
		public static void Log(string text, bool ToDebugger)
		{
			if (ToDebugger)
			{
				Logs.LogAPI(text);
			}
			Logs.WriteToConsole(ConsoleColor.Blue, "Cre", ConsoleColor.DarkBlue, "Client", ConsoleColor.Blue, text);
		}

		
		public static void LogError(string text, bool ToDebugger)
		{
			if (ToDebugger)
			{
				Logs.LogAPI(text);
			}
			Logs.WriteToConsole(ConsoleColor.Blue, "Cre", ConsoleColor.DarkBlue, "Client", ConsoleColor.Red, text);
		}

		
		public static void LogGeneral(string text, bool ToDebugger)
		{
			if (ToDebugger)
			{
				Logs.LogAPI(text);
			}
			Logs.WriteToConsole(ConsoleColor.Blue, "Cre", ConsoleColor.DarkBlue, "Client", ConsoleColor.Blue, text);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000BA88 File Offset: 0x00009C88
		public static void LogWarn(string text, bool ToDebugger)
		{
			if (ToDebugger)
			{
				Logs.LogAPI(text);
			}
			Logs.WriteToConsole(ConsoleColor.Blue, "Cre", ConsoleColor.DarkBlue, "Client", ConsoleColor.Blue, text);
		}

		public static void LogJoin(string text)
		{
			Logs.linecheck += 1f;
			bool lineCheck = Logs.linecheck > 40f;
			if (lineCheck)
			{
				Logs.console.InfoText.text = "";
				Logs.linecheck = 0f;
			}
			Text infoText = Logs.console.InfoText;
			infoText.text = string.Concat(new string[]
			{
				infoText.text,
				"[<color=#8A2BE2>",
				DateTime.Now.ToString("[hh:mm:ss.ms]"),
				"</color>] [<color=#0000FF>CreClient</color>] [<color=#0000CC>+</color>]:    ",
				text,
				"\n"
			});
		}

		
		public static void LogLeave(string text)
		{
			Logs.linecheck += 1f;
			bool lineCheck = Logs.linecheck > 40f;
			if (lineCheck)
			{
				Logs.console.InfoText.text = "";
				Logs.linecheck = 0f;
			}
			Text infoText = Logs.console.InfoText;
			infoText.text = string.Concat(new string[]
			{
				infoText.text,
				"[<color=#0000FF>",
				DateTime.Now.ToString("[hh:mm:ss.ms]"),
				"</color>] [<color=#0000FF>CreClient</color>] [<color=#0000CC>+</color>]:    ",
				text,
				"\n"
			});
		}

		
		public static void LogAPI(string text)
		{
			Logs.linecheck += 1f;
			bool lineCheck = Logs.linecheck > 40f;
			if (lineCheck)
			{
				Logs.console.InfoText.text = "";
				Logs.linecheck = 0f;
			}
			Text infoText = Logs.console.InfoText;
			infoText.text = string.Concat(new string[]
			{
				infoText.text,
				"[<color=#0000FF>",
				DateTime.Now.ToString("[hh:mm:ss.ms]"),
				"</color>] [<color=#0000FF>CreClient</color>] [<color=#0000CC>+</color>]:    ",
				text,
				"\n"
			});
		}

		
		public static void LogModeration(string text)
		{
			Logs.linecheck += 1f;
			bool lineCheck = Logs.linecheck > 40f;
			if (lineCheck)
			{
				Logs.console.InfoText.text = "";
				Logs.linecheck = 0f;
			}
			Text infoText = Logs.console.InfoText;
			infoText.text = string.Concat(new string[]
			{
				infoText.text,
				"[<color=#0000FF>",
				DateTime.Now.ToString("[hh:mm:ss.ms]"),
				"</color>] [<color=#FF0500>MODERATION</color>]:    ",
				text,
				"\n"
			});
		}

		
		public static void LogUdon(string text)
		{
			Logs.linecheck += 1f;
			bool lineCheck = Logs.linecheck > 40f;
			if (lineCheck)
			{
				Logs.console.InfoText.text = "";
				Logs.linecheck = 0f;
			}
			Text infoText = Logs.console.InfoText;
			infoText.text = string.Concat(new string[]
			{
				infoText.text,
				"[<color=#0000FF>",
				DateTime.Now.ToString("[hh:mm:ss.ms]"),
				"</color>] [<color=#FF0500>UDON</color>]:    ",
				text,
				"\n"
			});
		}
		
		
		public static float linecheck;
		public static QMInfo console;
	}
}

