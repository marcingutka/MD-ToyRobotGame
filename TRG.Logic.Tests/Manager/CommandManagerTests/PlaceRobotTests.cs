using NUnit.Framework;
using System.Collections.Generic;
using TRG.Logic.Manager;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager.CommandManagerTests
{
    public class PlaceRobotTests
    {
        private CommandManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CommandManager();
        }

        [Test]
        public void Execute_When_PlaceRobot_Command_And_Point_Is_Not_Wall_Set_Robot_X_To_Provided_Value()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { new GridPoint { Position = new Position { X = 2, Y = 2 }, IsWall = true } };
            Robot robot = null;
            var command = new PlaceRobot(new GridPosition { X = 1, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(grid, gridPoints, robot, command);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
        }
    }
}
