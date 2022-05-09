namespace TransportRobotTaskManager.Core
{
    public class LoadPosition : ILoadPosition
    {
        public bool IsBusy { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
