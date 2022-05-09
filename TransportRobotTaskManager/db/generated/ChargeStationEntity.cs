using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class ChargeStationEntity : IEntity
    {
        public long RobotId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
