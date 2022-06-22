using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreClientTest.Settings
{
    public interface OnPlayerJoinEvent
    {
        void OnPlayerJoin(VRC.Player player);
    }
}
