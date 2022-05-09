namespace TransportRobotTaskManager.Core
{
    public interface IRobotTask
    {
        public IPayload Payload { get; }
        public IUnit Base { get; }
        public IUnit Destination { get; }
        public double PreLoadingTime { get; }
        public double LoadingTime { get; }
        public double UnloadingTime { get; }
        public int Priority { get; }
    }
}
