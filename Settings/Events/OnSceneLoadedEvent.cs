using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreClientTest.Settings
{
    public interface OnSceneLoadedEvent
    {
        void OnSceneWasLoadedEvent(int buildIndex, string sceneName);
    }
}
