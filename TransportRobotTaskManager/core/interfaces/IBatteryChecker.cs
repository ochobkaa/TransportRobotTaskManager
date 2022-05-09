namespace TransportRobotTaskManager.Core
{
    public interface IBatteryChecker
    {
        public bool IsBatteryEnough(IRobot robot, IRobotTask task, ITaskInfo taskTime);
    }
}
