using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRobotTaskManager.Server
{
    public interface IServer
    {
        public double GetRobotPositionX(string robotName);
        public double GetRobotPositionY(string robotName);
        public double GetRobotBatteryCharge(string robotName);
    }
}
