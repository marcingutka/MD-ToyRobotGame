using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.InputMapperTests
{
    public class ReportTests
    {
        private IInputPlacingValidator validator;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPlacingValidator>();
            mapper = new InputMapper(validator);
        }

        [Test]
        public void Map_When_Report_Command_Is_Correct_Returns_CorrectReportCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "REPORT";

            content.Add(command);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.AreEqual(CommandType.Report, mappedCommand.CommandType);
        }

        [Test]
        public void Map_When_Report_Command_Is_Correct_Returns_CorrectReportObject()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "REPORT";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.IsTrue(mappedCommand is Report);
        }

        [Test]
        public void Map_When_CommandType_Is_Report_PlacingValidator_Is_Not_Called()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "REPORT";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            mapper.Map(content, grid);

            //Assert
            Assert.DoesNotThrow(() => validator.DidNotReceive().Validate(Arg.Any<Grid>(), Arg.Any<int>(), Arg.Any<int>()));
        }
    }
}
