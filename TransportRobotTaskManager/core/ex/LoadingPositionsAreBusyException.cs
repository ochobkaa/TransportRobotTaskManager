namespace TransportRobotTaskManager.Core
{
    public class LoadingPositionsAreBusyException : Exception
    {
        public LoadingPositionsAreBusyException(string e) : base(e) { }
    }
}
