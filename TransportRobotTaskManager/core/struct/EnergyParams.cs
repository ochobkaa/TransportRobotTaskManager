namespace TransportRobotTaskManager.Core
{
    public class EnergyParams : IEnergyParams
    {
        public double BattetyCharge { get; set; }
        public double BatteryCapacity { get; set; }
        public double MinChargeThreshold { get; set; }
        public double MotorPower { get; set; }
        public double IdlePower { get; set; }
        public double Voltage { get; set; }
        public double PeukertExponent { get; set; }
        public double CRating { get; set; }
    }
}
