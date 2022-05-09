namespace TransportRobotTaskManager.Core
{
    public interface IPathTimeCalculator
    {
        public double CalculateMovingTime(IPath path, IRobot robot);
        public double CalculateTransportTime(IPath path, double mass, IRobot robot);
    }
}
