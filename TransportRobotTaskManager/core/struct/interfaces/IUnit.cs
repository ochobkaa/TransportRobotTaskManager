namespace TransportRobotTaskManager.Core
{
    public interface IUnit
    {
        public string Name { get; }
        public IEnumerable<ILoadPosition> LoadPositions { get; }
        public IEnumerable<IUnloadPosition> UnloadPositions { get; }
    }
}
