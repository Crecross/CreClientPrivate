﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreClientTest.Settings
{
    public interface OnAssetBundleLoadEvent
    {
        bool OnAvatarAssetBundleLoad(GameObject avatar, string avatarID);
    }
}
