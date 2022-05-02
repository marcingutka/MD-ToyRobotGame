using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.CommandMapperTests
{
    public class ReportTests
    {
        private const string COMMAND_TYPE = "REPORT";

        private IInputPlacingValidator validator;
        private CommandMapper commandMapper;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPlacingValidator>();
            this.commandMapper = new CommandMapper(validator);
        }

        [Test]
        public void Map_When_Report_Command_Is_Correct_Returns_ReportObject()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = null;
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsTrue(result is Report);
        }

        [Test]
        public void Map_When_Report_Command_Has_Parameters_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2" };
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid) as Report;

            //Assert
            Assert.IsNull(result);
        }
    }
}
