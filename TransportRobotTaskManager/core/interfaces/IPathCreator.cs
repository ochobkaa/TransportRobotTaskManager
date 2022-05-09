namespace TransportRobotTaskManager.Core
{
    public interface IPathCreator
    {
        public IPath CreatePath(IPosition basePosition, IPosition destination);
    }
}
