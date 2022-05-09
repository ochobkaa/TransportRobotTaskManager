using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace TransportRobotTaskManager.Db
{
    public partial class TransportTasksDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["TransportTasksDb"].ConnectionString;
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
