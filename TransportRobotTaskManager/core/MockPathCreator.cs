namespace TransportRobotTaskManager.Core
{
    public class MockPathCreator : IPathCreator
    {
        public IPath CreatePath(IPosition basePosition, IPosition destination)
        {
            var distX = Math.Abs(basePosition.X - destination.X);
            var distY = Math.Abs(basePosition.Y - destination.Y);
            var dist = Math.Sqrt(distX * distX + distY * distY);

            return new Path()
            {
                Base = basePosition,
                Destination = destination,
                Length = dist
            };
        }
    }
}
