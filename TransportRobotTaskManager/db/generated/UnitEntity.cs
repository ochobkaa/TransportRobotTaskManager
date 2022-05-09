using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class UnitEntity
    {
        public UnitEntity()
        {
            LoadingPositions = new HashSet<LoadingPositionEntity>();
            RobotTaskBaseUnitNavigations = new HashSet<RobotTaskEntity>();
            RobotTaskDestinationUnitNavigations = new HashSet<RobotTaskEntity>();
            UnloadingPositions = new HashSet<UnloadingPositionEntity>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<LoadingPositionEntity> LoadingPositions { get; set; }
        public virtual ICollection<RobotTaskEntity> RobotTaskBaseUnitNavigations { get; set; }
        public virtual ICollection<RobotTaskEntity> RobotTaskDestinationUnitNavigations { get; set; }
        public virtual ICollection<UnloadingPositionEntity> UnloadingPositions { get; set; }
    }
}
