namespace TransportRobotTaskManager.Core
{
    public class TransportParams : ITransportParams
    {
        public double Mass { get; set; }
        public double MechanicalPower { get; set; }
        public double RollingResistanceCoef { get; set; }
        public double AerodynamicalCoef { get; set; }
    }
}
