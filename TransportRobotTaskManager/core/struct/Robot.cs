namespace TransportRobotTaskManager.Core
{
    public class Robot : IRobot
    {
        public string Name { get; set; }
        public bool AvailableToWork { get; set; }
        public IPosition Position { get; set; }
        public IRobotTask Task { get; set; }
        public IPosition ChargeStationPosition { get; set; }
        public IPayload MaxPayload { get; set; }
        public ITransportParams Transport { get; set; }
        public IEnergyParams Energy { get; set; }
    }
}
