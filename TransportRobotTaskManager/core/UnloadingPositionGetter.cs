namespace TransportRobotTaskManager.Core
{
    public class UnloadingPositionGetter : IUnloadingPositionGetter
    {
        public IUnloadPosition GetFreeUnloadingPosition(IUnit unit)
        {
            var unloadPosition = unit.UnloadPositions.Where(pos => !pos.IsBusy).FirstOrDefault();

            if (unloadPosition != null)
                return unloadPosition;

            else
                throw new UnloadingPositionsAreBusyException("All unloading positions are busy");
        }

        public bool IsBusy(IUnit unit)
        {
            var isBusy = unit.LoadPositions.All(x => x.IsBusy);

            return isBusy;
        }
    }
}
