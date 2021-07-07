using System.Collections.Generic;
using System.Data.Common;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Theory]
        [MemberData(nameof(ScenariosThatCauseDeath))]
        public void DecidesCellShouldDieIfIncorrectNumberOfNeighbours(
            ScenariosThatCauseDeathData scenariosThatCauseDeathData)
        {
            var world = new World(
                new Grid(10, 10, scenariosThatCauseDeathData.LiveCells));

            var cellShouldDie = world.CellShouldDie(scenariosThatCauseDeathData.XCoordToUpdate,
                scenariosThatCauseDeathData.YCoordToUpdate);

            Assert.True(cellShouldDie);
        }

        [Theory]
        [MemberData(nameof(ScenariosThatKeepCellAlive))]
        public void DecidesCellShouldStayAliveIfEnoughLiveNeighbours(ScenariosThatKeepCellAliveData scenariosThatKeepCellAliveData)
        {
            var world = new World(
                new Grid(10, 10, scenariosThatKeepCellAliveData.LiveCells));

            var cellShouldDie = world.CellShouldDie(scenariosThatKeepCellAliveData.XCoordToUpdate,
                scenariosThatKeepCellAliveData.YCoordToUpdate);

            Assert.False(cellShouldDie);
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