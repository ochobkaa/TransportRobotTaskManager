using TransportRobotTaskManager.Core;

namespace TransportRobotTaskManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var payloadChecker = new PayloadChecker();
            var loadingPositionGetter = new LoadingPositionGetter();
            var unloadingPositionGetter = new UnloadingPositionGetter();
            var pathCreator = new MockPathCreator();
            var timeCalculator = new PathTimeCalculator();
            var batteryChecker = new BatteryChecker(pathCreator, timeCalculator);

            var taskManger = new TaskManager(payloadChecker, loadingPositionGetter, unloadingPositionGetter, batteryChecker, pathCreator, timeCalculator);

            IRobot robot = new Robot() {
                AvailableToWork = true,
                Position = new Position()
                {
                    X = 38.97,
                    Y = 35.05
                },
                Task = null,
                ChargeStationPosition = new Position()
                {
                    X = 0.21,
                    Y = 15.79
                },
                MaxPayload = new Payload()
                {
                    Mass = 400,
                    Size = new PayloadSize()
                    {
                        X = 0.67,
                        Y = 3.33,
                        Z = 1.60
                    }
                },
                Transport = new TransportParams()
                {
                    Mass = 161.3,
                    MechanicalPower = 60.4,
                    RollingResistanceCoef = 0.006,
                    AerodynamicalCoef = 0.88
                },
                Energy = new EnergyParams()
                {
                    BattetyCharge = 0.05,
                    BatteryCapacity = 35,
                    MinChargeThreshold = 0,
                    MotorPower = 127.7,
                    IdlePower = 5.7,
                    Voltage = 24.1,
                    PeukertExponent = 1.09,
                    CRating = 0.05
                }
            };

            var unit1 = new Unit()
            {
                Name = "Unit 1",
                LoadPositions = new List<ILoadPosition>()
                {
                    new LoadPosition()
                    {
                        X = 39.02,
                        Y = 36.11
                    },
                    new LoadPosition()
                    {
                        X = 29.02,
                        Y = 25.23
                    }
                },
                UnloadPositions = new List<IUnloadPosition>()
                {
                    new UnloadPosition()
                    {
                        X = 27.90,
                        Y = 4.12
                    },
                    new UnloadPosition()
                    {
                        X = 17.85,
                        Y = 3.12
                    },
                }
            };

            var unit2 = new Unit()
            {
                Name = "Unit 2",
                LoadPositions = new List<ILoadPosition>()
                {
                    new LoadPosition()
                    {
                        X = 26.32,
                        Y = 11.31
                    }
                },
                UnloadPositions = new List<IUnloadPosition>()
                {
                    new UnloadPosition()
                    {
                        X = 27.10,
                        Y = 15.49
                    }
                }
            };

            var unit3 = new Unit()
            {
                Name = "Unit 3",
                LoadPositions = new List<ILoadPosition>()
                {
                    new LoadPosition()
                    {
                        X = 8.05,
                        Y = 31.28
                    }
                },
                UnloadPositions = new List<IUnloadPosition>()
                {
                    new UnloadPosition()
                    {
                        X = 8.79,
                        Y = 36.32
                    }
                }
            };

            var unit4 = new Unit()
            {
                Name = "Unit 4",
                LoadPositions = new List<ILoadPosition>()
                {
                    new LoadPosition()
                    {
                        X = 29.79,
                        Y = 9.09
                    },
                    new LoadPosition()
                    {
                        X = 29.64,
                        Y = 4.09
                    }
                },
                UnloadPositions = new List<IUnloadPosition>()
                {
                    new UnloadPosition()
                    {
                        X = 9.32,
                        Y = 12.35
                    }
                }
            };

            var tasks = new List<IRobotTask>()
            {
                new RobotTask()
                {
                    Payload = new Payload()
                    {
                        Mass = 26.6,
                        Size = new PayloadSize()
                        {
                            X = 0.40,
                            Y = 1.85,
                            Z = 0.15
                        }
                    },
                    Base = unit1,
                    Destination = unit2,
                    PreLoadingTime = 0,
                    LoadingTime = 20,
                    UnloadingTime = 20,
                    Priority = 1
                },
                new RobotTask()
                {
                    Payload = new Payload()
                    {
                        Mass = 205.9,
                        Size = new PayloadSize()
                        {
                            X = 0.60,
                            Y = 3.20,
                            Z = 0.65
                        }
                    },
                    Base = unit1,
                    Destination = unit3,
                    PreLoadingTime = 0,
                    LoadingTime = 20,
                    UnloadingTime = 20,
                    Priority = 1
                },
                new RobotTask()
                {
                    Payload = new Payload()
                    {
                        Mass = 75.1,
                        Size = new PayloadSize()
                        {
                            X = 0.33,
                            Y = 0.25,
                            Z = 1.54
                        }
                    },
                    Base = unit2,
                    Destination = unit3,
                    PreLoadingTime = 82.4,
                    LoadingTime = 20,
                    UnloadingTime = 20,
                    Priority = 1
                },
                new RobotTask()
                {
                    Payload = new Payload()
                    {
                        Mass = 279.4,
                        Size = new PayloadSize()
                        {
                            X = 0.60,
                            Y = 3.03,
                            Z = 1.45
                        }
                    },
                    Base = unit3,
                    Destination = unit4,
                    PreLoadingTime = 0,
                    LoadingTime = 20,
                    UnloadingTime = 20,
                    Priority = 1
                }
            };

            robot = taskManger.SetTaskToRobot(robot, tasks);
            Console.WriteLine($"{robot.Task.Base.Name} {robot.Task.Destination.Name}");
        }
    }
}
