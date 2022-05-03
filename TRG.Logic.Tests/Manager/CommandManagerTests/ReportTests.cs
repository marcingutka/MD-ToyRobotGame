using NUnit.Framework;
using System.Collections.Generic;
using TRG.Logic.Manager;
using TRG.Logic.Tests.Helpers;
using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager.CommandManagerTests
{
    public class ReportTests
    {
        private ICommandManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CommandManager();
        }

        [Test]
        public void Execute_WHEN_Report_Command_AND_There_Is_No_Robot_Returns_Null()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = null;
            var command = new Report();

            //Act
            var result = manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [Test]
        public void Execute_WHEN_Report_Command_AND_There_Is_Robot_Returns_Robot_Position()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = CreatorHelper.CreateRobot(3, 2, Models.Enums.OrientationState.North);
            var command = new Report();

            //Act
            var result = manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual("3,2,NORTH", result);
        }
    }
}
