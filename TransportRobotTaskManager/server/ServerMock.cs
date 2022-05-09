using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRobotTaskManager.Server
{
    public class ServerMock : IServer
    {
        public double GetRobotBatteryCharge(string robotName)
        {
            return 1;
        }

        public double GetRobotPositionX(string robotName)
        {
            return 0;
        }

        public double GetRobotPositionY(string robotName)
        {
            return 0;
        }
    }
}
