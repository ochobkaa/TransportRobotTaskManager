namespace TransportRobotTaskManager.Core
{
    public interface ITransportParams
    {
        public double Mass { get; }
        public double MechanicalPower { get; }
        public double RollingResistanceCoef { get; }
        public double AerodynamicalCoef { get; }
    }
}
