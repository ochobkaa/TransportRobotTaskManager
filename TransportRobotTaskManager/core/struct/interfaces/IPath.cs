namespace TransportRobotTaskManager.Core
{
    public interface IPath
    {
        public IPosition Base { get; }
        public IPosition Destination { get; }
        public double Length { get; }
    }
}
