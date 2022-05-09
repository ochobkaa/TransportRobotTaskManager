namespace TransportRobotTaskManager.Core
{
    public class TaskManager
    {

        private IPayloadChecker _payloadChecker;
        private ILoadingPositionGetter _loadingPositionGetter;
        private IUnloadingPositionGetter _unloadingPositionGetter;
        private IBatteryChecker _batteryChecker;
        private IPathCreator _pathCreator;
        private IPathTimeCalculator _pathTimeCalculator;

        public TaskManager(IPayloadChecker payloadChecker, ILoadingPositionGetter loadingPositionGetter, IUnloadingPositionGetter unloadingPositionGetter,
            IBatteryChecker batteryChecker, IPathCreator pathCreator, IPathTimeCalculator timeCalculator)
        {
            _payloadChecker = payloadChecker;
            _loadingPositionGetter = loadingPositionGetter;
            _unloadingPositionGetter = unloadingPositionGetter;
            _batteryChecker = batteryChecker;
            _pathCreator = pathCreator;
            _pathTimeCalculator = timeCalculator;
        }

        private IList<IRobotTask> SelectTasksByPayload(IRobot robot, IEnumerable<IRobotTask> tasks)
        {
            var selectedTasks = from task in tasks
                                where _payloadChecker.CanPayloadBeTransported(task, robot)
                                select task;

            return selectedTasks.ToList();
        }

        private IList<IRobotTask> SelectTasksByPositionsBusy(IEnumerable<IRobotTask> tasks)
        {
            var selectedTasks = from task in tasks
                                where !_loadingPositionGetter.IsBusy(task.Base)
                                    && !_unloadingPositionGetter.IsBusy(task.Destination)
                                select task;

            return selectedTasks.ToList();
        }

        private double GetMoveToBaseTime(IRobot robot, ILoadPosition loadPosition)
        {
            var moveToBasePath = _pathCreator.CreatePath(robot.Position, loadPosition);
            var moveToBaseTime = _pathTimeCalculator.CalculateMovingTime(moveToBasePath, robot);

            return moveToBaseTime;
        }

        private double GetIdleTime(IRobotTask task, double moveToBaseTime)
        {
            var preloadingTimeDelta = task.PreLoadingTime - moveToBaseTime;
            var preloadingTime = preloadingTimeDelta > 0 ? preloadingTimeDelta : 0;
            var idleTime = preloadingTime + task.LoadingTime + task.UnloadingTime;

            return idleTime;
        }

        private ILoadPosition GetTaskLoadPosition(IRobotTask task)
        {
            var loadPosition = _loadingPositionGetter.GetFreeLoadingPosition(task.Base);

            return loadPosition;
        }

        private IUnloadPosition GetTaskUnloadPosition(IRobotTask task)
        {
            var unloadPosition = _unloadingPositionGetter.GetFreeUnloadingPosition(task.Destination);

            return unloadPosition;
        }

        private double GetTransportingTime(IRobot robot, ILoadPosition loadPosition, IUnloadPosition unloadPosition, double mass)
        {
            var path = _pathCreator.CreatePath(loadPosition, unloadPosition);
            var transportingTime = _pathTimeCalculator.CalculateTransportTime(path, mass, robot);

            return transportingTime;
        }

        private IDictionary<IRobotTask, ITaskInfo> GetTasksInfo(IRobot robot, IList<IRobotTask> tasks)
        {
            var tasksTime = new Dictionary<IRobotTask, ITaskInfo>();

            foreach (var task in tasks)
            {
                var loadPosition = GetTaskLoadPosition(task);
                var unloadPosition = GetTaskUnloadPosition(task);

                var moveToBaseTime = GetMoveToBaseTime(robot, loadPosition);
                var idleTime = GetIdleTime(task, moveToBaseTime);
                var taskPerformTime = GetTransportingTime(robot, loadPosition, unloadPosition, task.Payload.Mass);

                var taskInfo = new TaskInfo()
                {
                    LoadPosition = loadPosition,
                    UnloadPosition = unloadPosition,
                    MovingTime = moveToBaseTime,
                    IdleTime = idleTime,
                    TransportingTime = taskPerformTime
                };
                tasksTime.Add(task, taskInfo);
            }

            return tasksTime;
        }

        private IDictionary<IRobotTask, ITaskInfo> SelectTasksByBattery(IRobot robot, IDictionary<IRobotTask, ITaskInfo> tasksTime)
        {
            var selectedTasks = from task in tasksTime
                                where _batteryChecker.IsBatteryEnough(robot, task.Key, task.Value)
                                select task;

            return selectedTasks.ToDictionary(task => task.Key, task => task.Value);
        }

        private IRobotTask SelectTask(IDictionary<IRobotTask, ITaskInfo> tasksTime)
        {
            var maxPriority = tasksTime.Keys.Max(task => task.Priority);
            var maxPriorityTasks = from task in tasksTime.Keys
                                   where task.Priority == maxPriority
                                   select task;

            var selectedTask = tasksTime.MinBy(taskTime => taskTime.Value.Time).Key;

            return selectedTask;
        }

        public IRobot SetTaskToRobot(IRobot robot, IList<IRobotTask> tasks)
        {
            if (!robot.AvailableToWork) return robot;

            var newRobotState = new Robot()
            {
                Name = robot.Name,
                AvailableToWork = true,
                Position = robot.Position,
                ChargeStationPosition = robot.ChargeStationPosition,
                MaxPayload = robot.MaxPayload,
                Transport = robot.Transport,
                Energy = robot.Energy
            };

            if (tasks.Count == 0) return newRobotState;

            var tasksByPayload = SelectTasksByPayload(robot, tasks);
            if (tasksByPayload.Count == 0) return newRobotState;

            var tasksByPositionBusy = SelectTasksByPositionsBusy(tasks);
            if (tasksByPositionBusy.Count == 0) return newRobotState;

            var tasksTime = GetTasksInfo(robot, tasksByPositionBusy);

            var tasksByBattery = SelectTasksByBattery(robot, tasksTime);
            if (tasksByBattery.Count == 0) return newRobotState;

            var task = SelectTask(tasksByBattery);
            newRobotState.Task = task;
            newRobotState.AvailableToWork = false;
            tasks.Remove(task);

            return newRobotState;
        }
    }
}