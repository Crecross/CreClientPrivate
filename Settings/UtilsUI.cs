using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using VRC;
using System.Text.RegularExpressions;
using CreClient.Settings;

namespace CreClient
{
    public static class UtilsUI
    {
       


        public static void InputPopup(string AcceptButtonTXT, string DefaultInputBoxTXT, Action<string> AcceptButtonAction, Action CancelButtonAction = null)
        {
            PopupCall(AcceptButtonTXT, DefaultInputBoxTXT, false, AcceptButtonAction, CancelButtonAction);
        }
        public static void AlertV2(string Message, string LeftButtonTXT, Action LeftButtonAction, string RightButtonTXT, Action RightButtonAction, Il2CppSystem.Action<VRCUiPopup> OnPopupShown = null)
        {
            VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_1("CreClient", Message, LeftButtonTXT, LeftButtonAction, RightButtonTXT, RightButtonAction, OnPopupShown);
        }

        private static void PopupCall(string confirm, string placeholder, bool IsNumpad, Action<string> OnAccept, Action OnCancel = null)
        {
            VRCUiPopupManager
                .prop_VRCUiPopupManager_0
                .Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(
                    "CreClient",
                    "",
                    InputField.InputType.Standard,
                    IsNumpad,
                    confirm,
                    UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>(new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((a, _, _) =>
                    {
                        OnAccept?.Invoke(a);
                    })),
                    UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(OnCancel),
                    placeholder);
        }
        public static bool IsValidWorldID(string input)
        {
            return Regex.IsMatch(input, @"(^$|offline|(wrld|wld)_[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})");
        }
        public static void HideCurrentPopUp()
        {
            VRCUiManager.prop_VRCUiManager_0.HideScreen("POPUP");
        }
        
    }
}
