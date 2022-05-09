using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class RobotTaskEntity
    {
        public RobotTaskEntity()
        {
            Robots = new HashSet<RobotEntity>();
        }

        public long Id { get; set; }
        public long BaseUnit { get; set; }
        public long DestinationUnit { get; set; }
        public DateTime? FinishTime { get; set; }
        public float? LoadingTime { get; set; }
        public float? UnloadingTime { get; set; }
        public int? Priority { get; set; }
        public float? PayloadMass { get; set; }
        public float? PayloadSizeX { get; set; }
        public float? PayloadSizeY { get; set; }
        public float? PayloadSizeZ { get; set; }

        public virtual UnitEntity BaseUnitNavigation { get; set; } = null!;
        public virtual UnitEntity DestinationUnitNavigation { get; set; } = null!;
        public virtual ICollection<RobotEntity> Robots { get; set; }
    }
}
