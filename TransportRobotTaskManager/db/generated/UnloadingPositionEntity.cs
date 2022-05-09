using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class UnloadingPositionEntity
    {
        public long Id { get; set; }
        public bool? IsBusy { get; set; }
        public long UnitId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public virtual UnitEntity Unit { get; set; } = null!;
    }
}
