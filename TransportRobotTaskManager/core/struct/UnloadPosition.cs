namespace TransportRobotTaskManager.Core
{
    public class UnloadPosition : IUnloadPosition
    {
        public bool IsBusy { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
