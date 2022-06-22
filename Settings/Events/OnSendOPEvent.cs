using Photon.Realtime;

namespace CreClientTest.Settings
{
    public interface OnSendOPEvent
    {
        bool OnSendOP(byte opCode, ref Il2CppSystem.Object parameters, ref RaiseEventOptions raiseEventOptions);
    }
}
