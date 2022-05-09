using System;
using System.Collections.Generic;

namespace TransportRobotTaskManager.Db
{
    public partial class RobotEntity : IEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? RobotTaskId { get; set; }
        public bool AvailableToWork { get; set; }

        public virtual RobotTaskEntity? RobotTask { get; set; }
        public virtual RobotsEnergyEntity RobotsEnergy { get; set; } = null!;
        public virtual RobotsMaxPayloadEntity RobotsMaxPayload { get; set; } = null!;
        public virtual RobotsTransportEntity RobotsTransport { get; set; } = null!;
    }
}
