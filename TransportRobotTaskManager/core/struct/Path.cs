namespace TransportRobotTaskManager.Core
{
    public class Path : IPath
    {
        public IPosition Base { get; set; }
        public IPosition Destination { get; set; }
        public double Length { get; set; }
    }
}
