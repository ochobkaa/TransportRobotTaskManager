namespace TransportRobotTaskManager.Core
{
    public class PathTimeCalculator : IPathTimeCalculator
    {
        private const double G = 9.81;

        private double CalculateVelocity(double mass, double power, double aerodynamicalCoeff, double rollingResistanceCoeff)
        {
            var qube = Math.Pow(rollingResistanceCoeff * mass * G / (3 * aerodynamicalCoeff), 3);
            var square = Math.Pow(power / (2 * aerodynamicalCoeff), 2);
            var sqrt = Math.Sqrt(square + qube);
            var qubeRoot1 = Math.Pow(power / aerodynamicalCoeff + sqrt, 1 / 3);
            var qubeRoot2 = Math.Pow(power / aerodynamicalCoeff - sqrt, 1 / 3);
            var velocity = qubeRoot1 + qubeRoot2;

            return velocity;
        }

        public double CalculateMovingTime(IPath path, IRobot robot)
        {
            var velocity = CalculateVelocity(
                robot.Transport.Mass,
                robot.Transport.MechanicalPower,
                robot.Transport.AerodynamicalCoef,
                robot.Transport.RollingResistanceCoef
            );

            var time = path.Length / velocity;

            return time;
        }

        public double CalculateTransportTime(IPath path, double mass, IRobot robot)
        {
            var velocity = CalculateVelocity(
                robot.Transport.Mass + mass,
                robot.Transport.MechanicalPower,
                robot.Transport.AerodynamicalCoef,
                robot.Transport.RollingResistanceCoef
            );

            var time = path.Length / velocity;

            return time;
        }
    }
}
