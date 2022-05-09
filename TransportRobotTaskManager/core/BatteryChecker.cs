namespace TransportRobotTaskManager.Core
{
    public class BatteryChecker : IBatteryChecker
    {
        private IPathCreator _pathCreator;
        private IPathTimeCalculator _pathTimeCalculator;

        public BatteryChecker(IPathCreator pathCreator, IPathTimeCalculator pathTimeCalculator)
        {
            _pathCreator = pathCreator;
            _pathTimeCalculator = pathTimeCalculator;
        }

        private double GetMovingToChargeStationTime(IRobot robot, ITaskInfo taskInfo)
        {
            var toChargeStationPath = _pathCreator.CreatePath(taskInfo.UnloadPosition, robot.ChargeStationPosition);
            var toChargeStationTime = _pathTimeCalculator.CalculateMovingTime(toChargeStationPath, robot);
            return toChargeStationTime;
        }

        private ITaskEnergy GetTaskEnergy(IRobot robot, ITaskInfo taskInfo, double toChargeStationTime)
        {
            var movingEnergy = robot.Energy.MotorPower * (taskInfo.MovingTime + taskInfo.TransportingTime + toChargeStationTime);
            var idleEnergy = robot.Energy.IdlePower * taskInfo.IdleTime;

            return new TaskEnergy()
            {
                Idle = idleEnergy,
                Moving = movingEnergy
            };
        }

        private double GetMeanCurrent(IRobot robot, ITaskEnergy taskEnergy, ITaskInfo taskInfo, double toChargeStationTime)
        {
            var idleCapacity = taskEnergy.Idle / robot.Energy.Voltage;
            var movingCapacity = taskEnergy.Moving / robot.Energy.Voltage;
            var meanCurrent = (idleCapacity + movingCapacity) / (taskInfo.Time + toChargeStationTime);
            return meanCurrent;
        }

        public bool IsBatteryEnough(IRobot robot, IRobotTask task, ITaskInfo taskInfo)
        {
            var toChargeStationTime = GetMovingToChargeStationTime(robot, taskInfo);

            var taskEnergy = GetTaskEnergy(robot, taskInfo, toChargeStationTime);
            var meanCurrent = GetMeanCurrent(robot, taskEnergy, taskInfo, toChargeStationTime);

            var energyRemains = robot.Energy.BatteryCapacity * (robot.Energy.BattetyCharge - robot.Energy.MinChargeThreshold);
            var peukertCapacity = Math.Pow(energyRemains, robot.Energy.PeukertExponent)
                * Math.Pow(robot.Energy.CRating, robot.Energy.PeukertExponent - 1);
            var timeRemains = peukertCapacity / Math.Pow(meanCurrent, robot.Energy.PeukertExponent) * 3600;

            return timeRemains > taskInfo.Time + toChargeStationTime;
        }
    }
}
