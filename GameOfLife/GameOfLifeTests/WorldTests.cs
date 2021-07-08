using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
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

            world.UpdateCell(scenariosThatCauseDeathData.XCoordToUpdate,
                scenariosThatCauseDeathData.YCoordToUpdate);

            Assert.Equal(scenariosThatCauseDeathData.UpdatedCellStatus, world.Grid.Cells[5][5]);
        }

        [Theory]
        [MemberData(nameof(ScenariosThatKeepCellAlive))]
        public void KeepsLiveCellAliveIfEnoughLiveNeighbours(ScenariosThatKeepCellAliveData scenariosThatKeepCellAliveData)
        {
            var world = new World(
                new Grid(10, 10, scenariosThatKeepCellAliveData.LiveCells));

            world.UpdateCell(scenariosThatKeepCellAliveData.XCoordToUpdate,
                scenariosThatKeepCellAliveData.YCoordToUpdate);

            Assert.Equal(scenariosThatKeepCellAliveData.UpdatedCellStatus, world.Grid.Cells[5][5]);
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
            
            world.UpdateCell(5, 5);
            
            Assert.Equal(Cell.Alive, world.Grid.Cells[5][5]);

        }
        
        

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