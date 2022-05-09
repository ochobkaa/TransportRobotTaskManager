using Microsoft.EntityFrameworkCore;

namespace TransportRobotTaskManager.Db
{
    public interface ITransportTasksDbContext
    {
        DbSet<ChargeStationEntity> ChargeStations { get; set; }
        DbSet<LoadingPositionEntity> LoadingPositions { get; set; }
        DbSet<RobotEntity> Robots { get; set; }
        DbSet<RobotsEnergyEntity> RobotsEnergies { get; set; }
        DbSet<RobotsMaxPayloadEntity> RobotsMaxPayloads { get; set; }
        DbSet<RobotsTransportEntity> RobotsTransports { get; set; }
        DbSet<RobotTaskEntity> RobotTasks { get; set; }
        DbSet<UnitEntity> Units { get; set; }
        DbSet<UnloadingPositionEntity> UnloadingPositions { get; set; }
    }
}