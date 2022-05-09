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

        private IEnumerable<RobotTaskEntity> SelectTasksByPriority(IEnumerable<RobotTaskEntity> tasks)
        {
            var selectedTasks = from task in tasks
                                where task.Priority == tasks.Max(task => task.Priority)
                                select task;

            return selectedTasks;
        }

        private IEnumerable<RobotTaskEntity> SelectTasksByPayload(IEnumerable<RobotTaskEntity> tasks, 
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
