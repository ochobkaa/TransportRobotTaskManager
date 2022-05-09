namespace TransportRobotTaskManager.Core
{
    public interface IRobot
    {
        public string Name { get; set; }
        public bool AvailableToWork { get; }
        public IPosition Position { get; }
        public IRobotTask Task { get; }
        public IPosition ChargeStationPosition { get; }
        public IPayload MaxPayload { get; }
        public ITransportParams Transport { get; }
        public IEnergyParams Energy { get; }
    }
}
