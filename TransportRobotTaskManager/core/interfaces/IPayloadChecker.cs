namespace TransportRobotTaskManager.Core
{
    public interface IPayloadChecker
    {
        public bool CanPayloadBeTransported(IRobotTask task, IRobot robot);
    }
}
