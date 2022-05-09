namespace TransportRobotTaskManager.Core
{
    public class PayloadChecker : IPayloadChecker
    {
        public bool CanPayloadBeTransported(IRobotTask task, IRobot robot)
        {
            bool byMass = task.Payload.Mass < robot.MaxPayload.Mass;
            bool bySizeX = task.Payload.Size.X < robot.MaxPayload.Size.X;
            bool bySizeY = task.Payload.Size.Y < robot.MaxPayload.Size.Y;
            bool bySizeZ = task.Payload.Size.Z < robot.MaxPayload.Size.Z;

            return byMass && bySizeX && bySizeY && bySizeZ;
        }
    }
}
