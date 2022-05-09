namespace TransportRobotTaskManager.Core
{
    public interface IUnloadingPositionGetter
    {
        public bool IsBusy(IUnit unit);
        public IUnloadPosition GetFreeUnloadingPosition(IUnit unit);
    }
}
