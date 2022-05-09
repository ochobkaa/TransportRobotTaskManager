namespace TransportRobotTaskManager.Core
{
    public class TaskInfo : ITaskInfo
    {
        public ILoadPosition LoadPosition { get; set; }
        public IUnloadPosition UnloadPosition { get; set; }
        public double MovingTime { get; set; }
        public double IdleTime { get; set; }
        public double TransportingTime { get; set; }
        public double Time => MovingTime + IdleTime + TransportingTime;
    }
}
