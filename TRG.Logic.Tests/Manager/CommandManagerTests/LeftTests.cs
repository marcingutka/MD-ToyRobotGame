using NUnit.Framework;
using System.Collections.Generic;
using TRG.Logic.Manager;
using TRG.Logic.Tests.Helpers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager.CommandManagerTests
{
    public class LeftTests
    {
        private CommandManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CommandManager();
        }

        [Test]
        public void Execute_WHEN_Left_Command_AND_There_Is_No_Robot_DO_NOT_Change_Orientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = null;
            var command = new Movement(MovementCommand.Left);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.IsNull(robot);
        }

        [Test]
        public void Execute_WHEN_Left_Command_AND_There_Is_Robot_With_Orientation_North_SET_Robot_Orientation_To_West()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(1, 1, OrientationState.North);
            var command = new Movement(MovementCommand.Left);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.West, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Left_Command_AND_There_Is_Robot_With_Orientation_West_SET_Robot_Orientation_To_South()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(1, 1, OrientationState.West);
            var command = new Movement(MovementCommand.Left);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.South, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Left_Command_AND_There_Is_Robot_With_Orientation_South_SET_Robot_Orientation_To_East()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(1, 1, OrientationState.South);
            var command = new Movement(MovementCommand.Left);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.East, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Left_Command_AND_There_Is_Robot_With_Orientation_East_SET_Robot_Orientation_To_North()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(1, 1, OrientationState.East);
            var command = new Movement(MovementCommand.Left);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }
    }
}
