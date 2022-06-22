using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC;

namespace CreClientTest.Settings
{
    public interface OnUdonEvent
    {
        bool OnUdon(string __0, Player __1);
    }
}
