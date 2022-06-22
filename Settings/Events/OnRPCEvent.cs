using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.SDKBase;

namespace CreClientTest.Settings
{
    public interface OnRPCEvent
    {
        bool OnRPC(VRC.Player sender, VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType vrcBroadcastType, int instagatorId, float fastforward);
    }
}
