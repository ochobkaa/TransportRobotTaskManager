namespace TransportRobotTaskManager.Core
{
    public class Payload : IPayload
    {
        public double Mass { get; set; }
        public IPayloadSize Size { get; set; }
    }
}
