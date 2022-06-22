using System;
using System.Collections;
using UnityEngine;
using VRC.SDKBase;
using WTFBlaze;
using MelonLoader;
using VRC;
using CreClient.Settings;

namespace CreClient.Modules
{
	public class Movement 
	{
		public static object speedCor;
		public static object speedcorDef;
		public static object jumpCor;
		public static object flyCor;
		public static bool Fly = false;
		public static bool NoClip = false;
		public static bool Speed = false;
		public static bool Jump = false;
		public static float RunSpeed = 4f;
		public static float WalkSpeed = 3f;
		public static float WalkSpeedDefault = 3f;
		public static float RunSpeedDefault = 4f;
		public static float JumpPower = 3f;
		public static float DeskFlySpeed = 6f;
		public static float FlySpeed = 6f;
		public static bool infinitejump = false;
		private static Transform CameraTransform;
		private static VRCVrIkController ikController;
		private static Transform head;
		private static VRC_AnimationController animController;
		public static bool noHead;
		public static object noHeadCor;

		public static void QuickMenuInitializedMovement()
		{		
			var fly = new QMToggleButton(Main_BlazeAPI.Movement, 1, 0, "Fly", delegate
			{
				flyCor = MelonCoroutines.Start(FlyNow());
				Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = false;
			}, delegate
			{
				MelonCoroutines.Stop(flyCor);
				Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = true;
			}, "Finally Crecross, you add fly");
			var hop = new QMToggleButton(Main_BlazeAPI.Movement, 2, 0, "Hop", delegate
			{
				jumpCor = MelonCoroutines.Start(JumpLoop());				
			}, delegate
			{
				MelonCoroutines.Stop(jumpCor);
			}, "Because Krelena wont give me hop :(");
			var speed = new QMToggleButton(Main_BlazeAPI.Movement, 3, 0, "Speed", delegate
			{
				speedCor = MelonCoroutines.Start(SpeedLoop());
				MelonCoroutines.Stop(speedcorDef);
			}, delegate
			{
				speedcorDef = MelonCoroutines.Start(SpeedLoopNo());
				MelonCoroutines.Stop(speedCor);	


			}, "Speed Hacks!");
			

			new QMSlider(Main_BlazeAPI.Movement, -750, -740, "Flight Speed", 0.1f, 55, FlySpeed, delegate (float f)
			{
				FlySpeed = f;
				//Logs.Log(FlySpeed.ToString(), false);
			});
			new QMSlider(Main_BlazeAPI.Movement, -750, -840, "Jump Power", 0.1f, 55, JumpPower, delegate (float f)
			{
				JumpPower = f;
				//Logs.Log(JumpPower.ToString(), false);
			});
			new QMSlider(Main_BlazeAPI.Movement, -750, -940, "Walk Speed", 0.1f, 55, WalkSpeed, delegate (float f)
			{
				WalkSpeed = f;
				//Logs.Log(WalkSpeed.ToString(), false);
			});
			
		}
		
	

		public static IEnumerator JumpLoop()
		{
			while (true)
			{
				Networking.LocalPlayer.SetJumpImpulse(JumpPower);
				yield break;
			}
		}
		public static void Walkspeeddef()
        {
			Networking.LocalPlayer.SetWalkSpeed(WalkSpeedDefault);
			Networking.LocalPlayer.SetStrafeSpeed(WalkSpeedDefault);
			Networking.LocalPlayer.SetRunSpeed(WalkSpeedDefault);

		}
		public static IEnumerator SpeedLoop()
        {
            while (true)
            {
				Networking.LocalPlayer.SetWalkSpeed(WalkSpeed);
				Networking.LocalPlayer.SetStrafeSpeed(WalkSpeed);
				Networking.LocalPlayer.SetRunSpeed(WalkSpeed);
				yield return new WaitForSeconds(0.5f);
			}
		}
		public static IEnumerator SpeedLoopNo()
		{
			while (true)
			{
				Networking.LocalPlayer.SetWalkSpeed(WalkSpeedDefault);
				Networking.LocalPlayer.SetStrafeSpeed(WalkSpeedDefault);
				Networking.LocalPlayer.SetRunSpeed(RunSpeedDefault);
				yield return new WaitForSeconds(0.5f);
			}
		}

		public static IEnumerator FlyNow()
		{
            while (true)
            {
				for (; ; )
				{
					CameraTransform = Camera.main.transform;
					bool keyDown = Input.GetKeyDown((KeyCode)304);
					if (keyDown)
					{
						Movement.FlySpeed *= 2f;
					}
					bool keyUp = Input.GetKeyUp((KeyCode)304);
					if (keyUp)
					{
						Movement.FlySpeed /= 2f;
					}
					bool key = Input.GetKey((KeyCode)101);
					if (key)
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.up * Movement.FlySpeed * Time.deltaTime;
					}
					bool key2 = Input.GetKey((KeyCode)113);
					if (key2)
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position -= CameraTransform.up * Movement.FlySpeed * Time.deltaTime;
					}
					bool key3 = Input.GetKey((KeyCode)119);
					if (key3)
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.forward * Movement.FlySpeed * Time.deltaTime;
					}
					bool key4 = Input.GetKey((KeyCode)97);
					if (key4)
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position -= CameraTransform.right * Movement.FlySpeed * Time.deltaTime;
					}
					bool key5 = Input.GetKey((KeyCode)100);
					if (key5)
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.right * Movement.FlySpeed * Time.deltaTime;
					}
					bool key6 = Input.GetKey((KeyCode)115);
					if (key6)
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position -= CameraTransform.forward * Movement.FlySpeed * Time.deltaTime;
					}
					bool flag = Networking.LocalPlayer.IsUserInVR();
					if (flag)
					{
						bool flag2 = Math.Abs(Input.GetAxis("Vertical")) != 0f;
						if (flag2)
						{
							VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.forward * Movement.FlySpeed * Time.deltaTime * Input.GetAxis("Vertical");
						}
						bool flag3 = Math.Abs(Input.GetAxis("Horizontal")) != 0f;
						if (flag3)
						{
							VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.right * Movement.FlySpeed * Time.deltaTime * Input.GetAxis("Horizontal");
						}
						bool flag4 = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f;
						if (flag4)
						{
							VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.up * Movement.FlySpeed * Time.deltaTime * Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical");
						}
						bool flag5 = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f;
						if (flag5)
						{
							VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position += CameraTransform.up * Movement.FlySpeed * Time.deltaTime * Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickVertical");
						}
					}
					Networking.LocalPlayer.SetVelocity(Vector3.zero);
					yield return null;
				}
			
			}
			
		}
	}
}
