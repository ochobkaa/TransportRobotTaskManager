namespace TransportRobotTaskManager.Core
{
    public class Unit : IUnit
    {
        public string Name { get; set; }
        public IEnumerable<ILoadPosition> LoadPositions { get; set; }
        public IEnumerable<IUnloadPosition> UnloadPositions { get; set; }
    }
}
