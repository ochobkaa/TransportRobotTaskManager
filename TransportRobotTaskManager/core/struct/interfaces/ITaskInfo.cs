namespace TransportRobotTaskManager.Core
{
    public interface ITaskInfo
    {
        public ILoadPosition LoadPosition { get; }
        public IUnloadPosition UnloadPosition { get; }
        public double MovingTime { get; }
        public double IdleTime { get; }
        public double TransportingTime { get; }
        public double Time { get; }
    }
}
