namespace TransportRobotTaskManager.Core
{
    public interface ILoadPosition : IPosition
    {
        public bool IsBusy { get; }
    }
}
