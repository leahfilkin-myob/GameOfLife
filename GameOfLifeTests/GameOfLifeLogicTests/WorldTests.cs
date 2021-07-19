using System.Collections.Generic;
using GameOfLife.GameOfLifeLogic;
using Xunit;

namespace GameOfLifeTests.GameOfLifeLogicTests
{
    public class WorldTests
    {
        [Theory]
        [MemberData(nameof(ScenariosThatCauseDeath))]
        public void TurnsLiveCellToDeadIfIncorrectNumberOfNeighbours(
            ScenariosThatCauseDeathData scenariosThatCauseDeathData)
        {
            var world = new World(
                new Grid(10, 10, scenariosThatCauseDeathData.LiveCells));

            world.RunOneGeneration();

            Assert.Equal(scenariosThatCauseDeathData.UpdatedCellStatus, 
                world.Grid.Cells[scenariosThatCauseDeathData.XCoordToUpdate][scenariosThatCauseDeathData.YCoordToUpdate]);
        }

        [Theory]
        [MemberData(nameof(ScenariosThatKeepCellAlive))]
        public void KeepsLiveCellAliveIfEnoughLiveNeighbours(ScenariosThatKeepCellAliveData scenariosThatKeepCellAliveData)
        {
            var world = new World(
                new Grid(10, 10, scenariosThatKeepCellAliveData.LiveCells));

            world.RunOneGeneration();

            Assert.Equal(scenariosThatKeepCellAliveData.UpdatedCellStatus, 
                world.Grid.Cells[scenariosThatKeepCellAliveData.XCoordToUpdate][scenariosThatKeepCellAliveData.YCoordToUpdate]);
        }

        [Fact]
        public void ChangesDeadCellToLiveCellIf3Neighbours()
        {
            var world = new World(
                new Grid(10, 10, new List<Point>
                {
                    new Point(5,4),
                    new Point(5,6),
                    new Point(6,5)
                }));
            
            world.RunOneGeneration();
            
            Assert.Equal(Cell.Alive, world.Grid.Cells[5][5]);

        }

        [Theory]
        [MemberData(nameof(EntireGridUpdate))]
        public void UpdatesAllCellsOnTheGridAtOnce(EntireGridUpdateData entireGridUpdateData)
        {
            var world = new World(
                new Grid(5, 5, entireGridUpdateData.LiveCells));

            world.RunOneGeneration();
            
            Assert.Equal(entireGridUpdateData.UpdatedGrid, world.Grid.Cells);
        }

        public class EntireGridUpdateData
        {
            public List<Point> LiveCells;
            public List<List<Cell>> UpdatedGrid;
        }

        public static IEnumerable<object[]> EntireGridUpdate =>
            new TheoryData<EntireGridUpdateData>
            {
                new EntireGridUpdateData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(2,1),
                        new Point(2,2),
                        new Point(2,3),
                        new Point(3,2)
                    },
                    UpdatedGrid = new List<List<Cell>>
                    {
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead, 
                        },
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Alive,
                            Cell.Dead,
                            Cell.Dead,
                        },
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive, 
                            Cell.Dead,
                        },
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Dead,
                        },
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                        }
                    }
                },
                new EntireGridUpdateData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(1,0),
                        new Point(1,2),
                        new Point(1,4),
                        new Point(2,1),
                        new Point(2,3),
                        new Point(3,0),
                        new Point(3,4),
                        new Point(4,2),
                    },
                    UpdatedGrid = new List<List<Cell>>
                    {
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Alive,
                            Cell.Dead,
                            Cell.Alive,
                            Cell.Dead, 
                        },
                        new List<Cell>
                        {
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                        },
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Dead,
                        },
                        new List<Cell>
                        {
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                            Cell.Alive,
                        },
                        new List<Cell>
                        {
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                            Cell.Dead,
                        }
                    }
                }
            };
        

        public class ScenariosThatKeepCellAliveData
        {
            public List<Point> LiveCells;
            public Cell UpdatedCellStatus;
            public int XCoordToUpdate;
            public int YCoordToUpdate;
        }

        public static IEnumerable<object[]> ScenariosThatKeepCellAlive =>
            new TheoryData<ScenariosThatKeepCellAliveData>
            {
                new ScenariosThatKeepCellAliveData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(5, 5),
                        new Point(5, 6),
                        new Point(6, 5)
                    },
                    UpdatedCellStatus = Cell.Alive,
                    XCoordToUpdate = 5,
                    YCoordToUpdate = 5
                },
                new ScenariosThatKeepCellAliveData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(5, 4),
                        new Point(5, 5),
                        new Point(5, 6),
                        new Point(6, 5)
                    },
                    UpdatedCellStatus = Cell.Alive,
                    XCoordToUpdate = 5,
                    YCoordToUpdate = 5
                }
            };
        public class ScenariosThatCauseDeathData
        {
            public List<Point> LiveCells;
            public Cell UpdatedCellStatus;
            public int XCoordToUpdate;
            public int YCoordToUpdate;
        }

        public static IEnumerable<object[]> ScenariosThatCauseDeath =>
            new TheoryData<ScenariosThatCauseDeathData>
            {
                new ScenariosThatCauseDeathData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(5, 5)
                    },
                    UpdatedCellStatus = Cell.Dead,
                    XCoordToUpdate = 5,
                    YCoordToUpdate = 5
                },
                new ScenariosThatCauseDeathData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(5, 5),
                        new Point(5, 6)
                    },
                    UpdatedCellStatus = Cell.Dead,
                    XCoordToUpdate = 5,
                    YCoordToUpdate = 5
                },                
                new ScenariosThatCauseDeathData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(5, 4),
                        new Point(5, 5),
                        new Point(5, 6),
                        new Point(6, 5),
                        new Point(6, 6),
                    },
                    UpdatedCellStatus = Cell.Dead,
                    XCoordToUpdate = 5,
                    YCoordToUpdate = 5
                },
                new ScenariosThatCauseDeathData
                {
                    LiveCells = new List<Point>
                    {
                        new Point(4,5),
                        new Point(5, 4),
                        new Point(5, 5),
                        new Point(5, 6),
                        new Point(6, 5),
                        new Point(6, 6),
                    },
                    UpdatedCellStatus = Cell.Dead,
                    XCoordToUpdate = 5,
                    YCoordToUpdate = 5
                }
            };

    }

    }