using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRobotTaskManager.Db
{
    public class TasksSelector
    {
        private readonly ITransportTasksDbContext _dbContext;

        public TasksSelector(ITransportTasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<RobotTaskEntity> SelectTasksByPriority(IQueryable<RobotTaskEntity> tasks)
        {
            var selectedTasks = from task in tasks
                                where task.Priority == tasks.Max(task => task.Priority)
                                select task;

            return selectedTasks;
        }

        private IQueryable<RobotTaskEntity> SelectTasksByPayload(IQueryable<RobotTaskEntity> tasks, 
            double maxMass, double maxSizeX, double maxSizeY, double maxSizeZ)
        {
            var selectedTasks = from task in tasks
                                where task.PayloadMass < maxMass
                                    && task.PayloadSizeX < maxSizeX
                                    && task.PayloadSizeY < maxSizeY
                                    && task.PayloadSizeZ < maxSizeZ
                                select task;

            return selectedTasks;
        }
    }
}
