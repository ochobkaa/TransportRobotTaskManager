using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class RobotsMaxPayloadEntity
    {
        public long RobotId { get; set; }
        public float MaxMass { get; set; }
        public float MaxSizeX { get; set; }
        public float MaxSizeY { get; set; }
        public float MaxSizeZ { get; set; }

        public virtual RobotEntity Robot { get; set; } = null!;
    }
}
