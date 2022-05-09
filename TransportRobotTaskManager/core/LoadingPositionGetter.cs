namespace TransportRobotTaskManager.Core
{
    public class LoadingPositionGetter : ILoadingPositionGetter
    {
        public ILoadPosition GetFreeLoadingPosition(IUnit unit)
        {
            var loadPosition = unit.LoadPositions.Where(pos => !pos.IsBusy).FirstOrDefault();

            if (loadPosition != null)
                return loadPosition;

            else
                throw new LoadingPositionsAreBusyException("All loading positions are busy");
        }

        public bool IsBusy(IUnit unit)
        {
            var isBusy = unit.LoadPositions.All(x => x.IsBusy);

            return isBusy;
        }
    }
}
