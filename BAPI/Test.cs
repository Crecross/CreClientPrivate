using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.API.QM;
using MelonLoader;

namespace CreClientTest.BAPI
{
    public class Test : MelonMod
    {
        public static QMNestedButton MainMenu;

        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(Main_BlazeAPI.StartUiManagerInitIEnumerator());
        }
        public static IEnumerator StartUiManagerInitIEnumerator()
        {

            while (UnityEngine.Object.FindObjectOfType<VRC.UI.Elements.QuickMenu>() == null) yield return null;
            QuickMenuInitialized();
            Logs.LogGeneral("Menu's Initialized! :)", false);
            yield return new WaitForSeconds(2);
            Logs.LogGeneral("Thank you for using CreClient ->" + APIUser.CurrentUser.displayName);
        }
        public static void QuickMenuInitialized()
        {
            MainMenu = new Blaze.API.QM.QMNestedButton("Menu_Dashboard", 3f, -0.5f, "CreClient", "CreClient by Crecross#9901", "CreClient");
        }
    }
}
