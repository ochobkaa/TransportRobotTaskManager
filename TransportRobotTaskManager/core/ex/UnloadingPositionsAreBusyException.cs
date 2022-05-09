namespace TransportRobotTaskManager.Core
{
    public class UnloadingPositionsAreBusyException : Exception
    {
        public UnloadingPositionsAreBusyException(string e) : base(e) { }
    }
}
