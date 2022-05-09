namespace TransportRobotTaskManager.Core
{
    public interface ILoadingPositionGetter
    {
        public bool IsBusy(IUnit unit);
        public ILoadPosition GetFreeLoadingPosition(IUnit unit);
    }
}
