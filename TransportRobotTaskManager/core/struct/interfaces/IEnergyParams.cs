namespace TransportRobotTaskManager.Core
{
    public interface IEnergyParams
    {
        public double BattetyCharge { get; }
        public double BatteryCapacity { get; }
        public double MinChargeThreshold { get; }
        public double MotorPower { get; }
        public double IdlePower { get; }
        public double Voltage { get; }
        public double PeukertExponent { get; }
        public double CRating { get; }
    }
}
