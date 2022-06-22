
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CreClientTest
{
    abstract class BaseModule
    {
        private static int copyAmount = 0;
        private static QMButtonGroup lastcetagory;

        public string name;
        public bool toggled;
        public bool save;

        string discription;
        QMButtonGroup category;
        bool isToggle;
        Sprite image;

        public BaseModule(string name, string discription, QMButtonGroup category, Sprite image = null, bool isToggle = false, bool save = false)
        {
            this.name = name;
            this.discription = discription;
            this.category = category;
            this.isToggle = isToggle;
            this.save = save;
            this.image = image;
            this.OnUIInit();
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void OnUIInit()
        {
            category.buttonamount++;
            if (category.buttonamount > 4)
            {
                if (lastcetagory == null)
                {
                    lastcetagory = new QMButtonGroup(category.buttonGroup.transform.parent, category.buttonGroup.name + copyAmount);
                }
                category = lastcetagory;
                copyAmount++;
            }
            else
            {
                lastcetagory = null;
            }

            if (isToggle)
            {
                QMToggleButton qMToggleButton = new QMToggleButton(category.buttonGroup.transform, name, discription, new Action<bool>((bool state) =>
                {
                    this.toggled = state;
                    if (state)
                    {
                        OnEnable();
                    }
                    else
                    {
                        OnDisable();
                    }
                    Main_BlazeAPI.Instance.onEventEventArray = Main_BlazeAPI.Instance.onEventEvents.ToArray();
                    Main_BlazeAPI.Instance.onPlayerJoinEventArray = Main_BlazeAPI.Instance.onPlayerJoinEvents.ToArray();
                    Main_BlazeAPI.Instance.onPlayerLeaveEventArray = Main_BlazeAPI.Instance.onPlayerLeaveEvents.ToArray();
                    Main_BlazeAPI.Instance.onRPCEventArray = Main_BlazeAPI.Instance.onRPCEvents.ToArray();
                    Main_BlazeAPI.Instance.onSendOPEventArray = Main_BlazeAPI.Instance.onSendOPEvents.ToArray();
                    Main_BlazeAPI.Instance.onUdonEventArray = Main_BlazeAPI.Instance.onUdonEvents.ToArray();
                    Main_BlazeAPI.Instance.onUpdateEventArray = Main_BlazeAPI.Instance.onUpdateEvents.ToArray();
                    Main_BlazeAPI.Instance.OnAssetBundleLoadEventArray = Main_BlazeAPI.Instance.OnAssetBundleLoadEvents.ToArray();
                    Main_BlazeAPI.Instance.onSceneLoadedEventArray = Main_BlazeAPI.Instance.onSceneLoadedEvents.ToArray();
                    Main_BlazeAPI.Instance.onWorldInitEventArray = Main_BlazeAPI.Instance.onWorldInitEvents.ToArray();
                }));
                if (save)
                {
                    if (Main_BlazeAPI.Instance.config.getConfigBool(name))
                    {
                        qMToggleButton.SetToggle(true);
                    }
                }
            }
            else
            {
                new QMSingleButton(category.buttonGroup.transform, name, discription, image, delegate
                {
                    OnEnable();
                });
            }
        }
    }
}

