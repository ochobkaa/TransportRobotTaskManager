namespace TransportRobotTaskManager.Core
{
    public interface IUnloadPosition : IPosition
    {
        public bool IsBusy { get; }
    }
}
