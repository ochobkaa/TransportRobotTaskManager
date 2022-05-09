using Microsoft.EntityFrameworkCore;

namespace TransportRobotTaskManager.Db
{
    public partial class TransportTasksDbContext : DbContext, ITransportTasksDbContext
    {
        public TransportTasksDbContext()
        {
        }

        public TransportTasksDbContext(DbContextOptions<TransportTasksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChargeStationEntity> ChargeStations { get; set; } = null!;
        public virtual DbSet<LoadingPositionEntity> LoadingPositions { get; set; } = null!;
        public virtual DbSet<RobotEntity> Robots { get; set; } = null!;
        public virtual DbSet<RobotTaskEntity> RobotTasks { get; set; } = null!;
        public virtual DbSet<RobotsEnergyEntity> RobotsEnergies { get; set; } = null!;
        public virtual DbSet<RobotsMaxPayloadEntity> RobotsMaxPayloads { get; set; } = null!;
        public virtual DbSet<RobotsTransportEntity> RobotsTransports { get; set; } = null!;
        public virtual DbSet<UnitEntity> Units { get; set; } = null!;
        public virtual DbSet<UnloadingPositionEntity> UnloadingPositions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChargeStationEntity>(entity =>
            {
                entity.HasKey(e => e.RobotId)
                    .HasName("charge_stations_pkey");

                entity.ToTable("charge_stations");

                entity.Property(e => e.RobotId)
                    .ValueGeneratedNever()
                    .HasColumnName("robot_id");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");
            });

            modelBuilder.Entity<LoadingPositionEntity>(entity =>
            {
                entity.ToTable("loading_positions");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IsBusy)
                    .HasColumnName("is_busy")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.LoadingPositions)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_id");
            });

            modelBuilder.Entity<RobotEntity>(entity =>
            {
                entity.ToTable("robots");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.RobotTaskId).HasColumnName("robot_task_id");

                entity.HasOne(d => d.RobotTask)
                    .WithMany(p => p.Robots)
                    .HasForeignKey(d => d.RobotTaskId)
                    .HasConstraintName("robot_task_id");

                entity.Property(e => e.AvailableToWork).HasColumnName("available_to_work");
            });

            modelBuilder.Entity<RobotTaskEntity>(entity =>
            {
                entity.ToTable("robot_tasks");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BaseUnit).HasColumnName("base_unit");

                entity.Property(e => e.DestinationUnit).HasColumnName("destination_unit");

                entity.Property(e => e.FinishTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("finish_time");

                entity.Property(e => e.LoadingTime)
                    .HasColumnName("loading_time")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PayloadMass)
                    .HasColumnName("payload_mass")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PayloadSizeX)
                    .HasColumnName("payload_size_x")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PayloadSizeY)
                    .HasColumnName("payload_size_y")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PayloadSizeZ)
                    .HasColumnName("payload_size_z")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UnloadingTime)
                    .HasColumnName("unloading_time")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.BaseUnitNavigation)
                    .WithMany(p => p.RobotTaskBaseUnitNavigations)
                    .HasForeignKey(d => d.BaseUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("base_unit");

                entity.HasOne(d => d.DestinationUnitNavigation)
                    .WithMany(p => p.RobotTaskDestinationUnitNavigations)
                    .HasForeignKey(d => d.DestinationUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("destination_unit");
            });

            modelBuilder.Entity<RobotsEnergyEntity>(entity =>
            {
                entity.HasKey(e => e.RobotId)
                    .HasName("robots_energy_pkey");

                entity.ToTable("robots_energy");

                entity.Property(e => e.RobotId)
                    .ValueGeneratedNever()
                    .HasColumnName("robot_id");

                entity.Property(e => e.BatteryCapacity).HasColumnName("battery_capacity");

                entity.Property(e => e.CRating).HasColumnName("c_rating");

                entity.Property(e => e.IdlePower).HasColumnName("idle_power");

                entity.Property(e => e.MovingPower).HasColumnName("moving_power");

                entity.Property(e => e.PeukertExponent).HasColumnName("peukert_exponent");

                entity.Property(e => e.Voltage).HasColumnName("voltage");

                entity.HasOne(d => d.Robot)
                    .WithOne(p => p.RobotsEnergy)
                    .HasForeignKey<RobotsEnergyEntity>(d => d.RobotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("robot_id");
            });

            modelBuilder.Entity<RobotsMaxPayloadEntity>(entity =>
            {
                entity.HasKey(e => e.RobotId)
                    .HasName("robots_max_payload_pkey");

                entity.ToTable("robots_max_payload");

                entity.Property(e => e.RobotId)
                    .ValueGeneratedNever()
                    .HasColumnName("robot_id");

                entity.Property(e => e.MaxMass).HasColumnName("max_mass");

                entity.Property(e => e.MaxSizeX).HasColumnName("max_size_x");

                entity.Property(e => e.MaxSizeY).HasColumnName("max_size_y");

                entity.Property(e => e.MaxSizeZ).HasColumnName("max_size_z");

                entity.HasOne(d => d.Robot)
                    .WithOne(p => p.RobotsMaxPayload)
                    .HasForeignKey<RobotsMaxPayloadEntity>(d => d.RobotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("robot_id");
            });

            modelBuilder.Entity<RobotsTransportEntity>(entity =>
            {
                entity.HasKey(e => e.RobotId)
                    .HasName("robots_transport_pkey");

                entity.ToTable("robots_transport");

                entity.Property(e => e.RobotId)
                    .ValueGeneratedNever()
                    .HasColumnName("robot_id");

                entity.Property(e => e.AerodynamicalCoef).HasColumnName("aerodynamical_coef");

                entity.Property(e => e.Mass).HasColumnName("mass");

                entity.Property(e => e.PowerKpi).HasColumnName("power_kpi");

                entity.Property(e => e.RollingResistanceCoef).HasColumnName("rolling_resistance_coef");

                entity.HasOne(d => d.Robot)
                    .WithOne(p => p.RobotsTransport)
                    .HasForeignKey<RobotsTransportEntity>(d => d.RobotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("robot_id");
            });

            modelBuilder.Entity<UnitEntity>(entity =>
            {
                entity.ToTable("units");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UnloadingPositionEntity>(entity =>
            {
                entity.ToTable("unloading_positions");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IsBusy)
                    .HasColumnName("is_busy")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.UnloadingPositions)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
