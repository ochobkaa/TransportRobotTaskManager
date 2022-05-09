using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class RobotsTransportEntity
    {
        public long RobotId { get; set; }
        public float Mass { get; set; }
        public float PowerKpi { get; set; }
        public float RollingResistanceCoef { get; set; }
        public float AerodynamicalCoef { get; set; }

        public virtual RobotEntity Robot { get; set; } = null!;
    }
}
