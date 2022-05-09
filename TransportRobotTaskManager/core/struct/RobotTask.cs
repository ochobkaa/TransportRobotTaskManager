
namespace TransportRobotTaskManager.Core
{
    public class RobotTask : IRobotTask
    {
        public IPayload Payload { get; set; }
        public IUnit Base { get; set; }
        public IUnit Destination { get; set; }
        public double PreLoadingTime { get; set; }
        public double LoadingTime { get; set; }
        public double UnloadingTime { get; set; }
        public int Priority { get; set; }
    }
}
