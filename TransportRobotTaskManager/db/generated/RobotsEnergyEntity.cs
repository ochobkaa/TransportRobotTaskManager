using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class RobotsEnergyEntity : IEntity
    {
        public long RobotId { get; set; }
        public float BatteryCapacity { get; set; }
        public float MovingPower { get; set; }
        public float IdlePower { get; set; }
        public float Voltage { get; set; }
        public float PeukertExponent { get; set; }
        public float CRating { get; set; }

        public virtual RobotEntity Robot { get; set; } = null!;
    }
}
