namespace TransportRobotTaskManager.Core
{
    public interface IPayload
    {
        public double Mass { get; }
        public IPayloadSize Size { get; }
    }
}
