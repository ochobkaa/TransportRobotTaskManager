using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRobotTaskManager.Db
{
    public partial class ChargeStationEntity
    {
        public long Id { get => RobotId; set { RobotId = value; } }
    }
}
