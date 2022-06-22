using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Photon.Pun;
using Photon.Realtime;
using RealisticEyeMovements;
using TMPro;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI.Elements;
using Button = UnityEngine.UI.Button;

namespace CreClient.Settings
{
    public class BehindScenes
    {
		public static object tex1Cor;
		public static object tex2Cor;

		public static IEnumerator CreMenu()
        {
			{

				foreach (Button button in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponentsInChildren<Button>(true))
				{
					try
					{
						button.transform.Find("Background").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					}
					catch
					{
					}
					try
					{
						button.transform.Find("Container/Background").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					}
					catch
					{
					}
				}				
					foreach (Toggle toggle in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponentsInChildren<Toggle>(true))
				{
					try
					{
						toggle.transform.Find("Background").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					}
					catch
					{
					}
				}
				foreach (Text text in GameObject.Find("/UserInterface").GetComponentsInChildren<Text>(true))
				{
					text.color = new Color(255, 255, 255, 0.95f);
				}
				foreach (Image image in GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup").GetComponentsInChildren<Image>(true))
                {
					image.color = new Color(255, 255, 255, 0.75f);
				}
				foreach (Image image in GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks").GetComponentsInChildren<Image>(true))
				{
					image.color = new Color(0, 0, 0, 0.75f);
				}
				foreach (Image image in GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions").GetComponentsInChildren<Image>(true))
				{
					image.color = new Color(0, 0, 0, 0.75f);
				}
				foreach (TextMeshProUGUI textMeshProUGUI in GameObject.Find("/UserInterface/Canvas_QuickMenu(Clone)").GetComponentsInChildren<TextMeshProUGUI>(true))
				{
					textMeshProUGUI.color = new Color(255, 255, 255, 0.95f);
				}
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Background_QM_PagePanel").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
				yield return new WaitForSeconds(0.1f);
			}		
        }
		public static void ChangeUIColors2()
        {
			
		}
        
		public static void ChangeUIColors()
		{

			GameObject.Find("UserInterface/MenuContent/Backdrop/Backdrop/Background").GetComponent<Image>().color = new Color(0, 0, 0, 1);
			GameObject gameObject = GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject;		
			foreach (Button button in gameObject.GetComponentsInChildren<Button>(true))
			{
				ColorBlock colors = button.colors;
				colors.normalColor = new Color(0, 0, 0, 1);
				colors.highlightedColor = new Color(0, 0, 0, 1);
				colors.pressedColor = Color.gray;
				colors.disabledColor = Color.gray;
				colors.selectedColor = new Color(0, 0, 0, 1);
				button.colors = colors;
			}
			foreach (Slider slider in GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens").GetComponentsInChildren<Slider>(true))
			{
				try
				{
					slider.transform.Find("Fill Area/Fill").gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
					slider.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
				}
				catch
				{
				}
			}
			foreach (Button button2 in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponentsInChildren<Button>(true))
			{
				try
				{
					string text = button2.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>().text;
					TextMeshProUGUI component = button2.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
					component.text = "<color=#FFFFFF>" + text;
				}
				catch
				{
				}
				try
				{
					Image component2 = button2.transform.Find("Background").GetComponent<Image>();
					component2.color = new Color(0, 0, 0, 1);
				}
				catch
				{
				}
				try
				{
					Image component3 = button2.transform.Find("Container/Background").GetComponent<Image>();
					component3.color = new Color(0, 0, 0, 1);
				}
				catch
				{
				}
			}
			foreach (Toggle toggle in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponentsInChildren<Toggle>(true))
			{
				try
				{
					Image component4 = toggle.transform.Find("Background").GetComponent<Image>();
					component4.color = new Color(0, 0, 0, 1);
				}
				catch
				{
				}
			}
		}
		public static IEnumerator TexturesQm()
        {
            {
				new Sprite();
				UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://i.imgur.com/7MpvsgF.png");
				yield return request.SendWebRequest();
				bool flag = request.isNetworkError || request.isHttpError;
				if (flag)
				{
					Logs.LogGeneral("Failed to get background images from WebRequest", false);
				}
				else
				{
					Texture2D text = DownloadHandlerTexture.GetContent(request);
					Sprite mfsprite = Sprite.CreateSprite(text, new Rect(0f, 0f, (float)text.width, (float)text.height), new Vector2((float)(text.width / 2), (float)(text.height / 2)), 100000f, 1000U, 0, Vector4.zero, false);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().sprite = mfsprite;
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().color = new Color(255, 255, 255, 0.95f);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").transform.localScale = new Vector3(1, 1, 1);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().sprite = mfsprite;
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().color = new Color(255, 255, 255, 0.95f);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01");
					text = null;
					mfsprite = null;
					yield break;
				}
			}
		}
		public static IEnumerator TexturesQm1()
		{

				new Sprite();
				UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://i.imgur.com/FMzDd3Z.png");
				yield return request.SendWebRequest();
				bool flag = request.isNetworkError || request.isHttpError;
				if (flag)
				{
					Logs.LogGeneral("Failed to get background images from WebRequest", false);
				}
				else
				{
					Texture2D text = DownloadHandlerTexture.GetContent(request);
					Sprite mfsprite = Sprite.CreateSprite(text, new Rect(0f, 0f, (float)text.width, (float)text.height), new Vector2((float)(text.width / 2), (float)(text.height / 2)), 100000f, 1000U, 0, Vector4.zero, false);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().sprite = mfsprite;
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").transform.localScale = new Vector3(1, 1, 1);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().sprite = mfsprite;
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01");
					text = null;
					mfsprite = null;
					yield break;	
			    }	
		}
		public static IEnumerator TexturesQmHaunted()
		{

			new Sprite();
			UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://i.imgur.com/gds9hHr.png");
			yield return request.SendWebRequest();
			bool flag = request.isNetworkError || request.isHttpError;
			if (flag)
			{
				Logs.LogGeneral("Failed to get background images from WebRequest", false);
			}
			else
			{
				Texture2D text = DownloadHandlerTexture.GetContent(request);
				Sprite mfsprite = Sprite.CreateSprite(text, new Rect(0f, 0f, (float)text.width, (float)text.height), new Vector2((float)(text.width / 2), (float)(text.height / 2)), 100000f, 1000U, 0, Vector4.zero, false);
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().sprite = mfsprite;
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().color = new Color(255, 255, 255, 0.95f);
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").transform.localScale = new Vector3(1, 1, 1);
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().sprite = mfsprite;
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().color = new Color(255, 255, 255, 0.95f);
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01");
				text = null;
				mfsprite = null;
				yield break;
			}
		}
		public static IEnumerator TabButton()
		{
			new Sprite();
			UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://cdn.discordapp.com/attachments/926762055174856714/974566443083530270/CCButton.png?size=4096");
			yield return request.SendWebRequest();
				Texture2D text = DownloadHandlerTexture.GetContent(request);
				Sprite mfsprite = Sprite.CreateSprite(text, new Rect(0f, 0f, (float)text.width, (float)text.height), new Vector2((float)(text.width / 2), (float)(text.height / 2)), 100000f, 1000U, 0, Vector4.zero, false);		
				text = null;
				mfsprite = null;               
                yield break;
			
		}
		public static IEnumerator Mic()
		{
            while (true)
            {
				new Sprite();
				UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://i.imgur.com/FMzDd3Z.png");
				yield return request.SendWebRequest();
				bool flag = request.isNetworkError || request.isHttpError;
				if (flag)
				{
					Logs.LogGeneral("Failed to get background images from WebRequest", false);
				}
				else
				{
					Texture2D text = DownloadHandlerTexture.GetContent(request);
					Sprite mfsprite = Sprite.CreateSprite(text, new Rect(0f, 0f, (float)text.width, (float)text.height), new Vector2((float)(text.width / 2), (float)(text.height / 2)), 100000f, 1000U, 0, Vector4.zero, false);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().sprite = mfsprite;
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").transform.localScale = new Vector3(1, 1, 1);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().sprite = mfsprite;
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01");
					text = null;
					mfsprite = null;
					yield break;
				}
			}
			
		}
		internal static GameObject uia;
		
		public static IEnumerator Icon()
        {
			new Sprite();
			UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://i.imgur.com/dpZAY3b.png");
			yield return request.SendWebRequest();
			Texture2D text = DownloadHandlerTexture.GetContent(request);
			Sprite mfsprite = Sprite.CreateSprite(text, new Rect(0f, 0f, (float)text.width, (float)text.height), new Vector2((float)(text.width / 2), (float)(text.height / 2)), 100000f, 1000U, 0, Vector4.zero, false);
            //GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").GetComponent<Image>().sprite = mfsprite;
            Main_BlazeAPI.ButtonImage = mfsprite;
			text = null;
			mfsprite = null;
			yield break;
		}
	}
}
