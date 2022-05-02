using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.InputMapperTests
{
    public class LeftTests
    {
        private ICommandMapper commandMapper;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            commandMapper = Substitute.For<ICommandMapper>();
            mapper = new InputMapper(commandMapper);
        }

        [Test]
        public void Map_When_Left_Command_Is_Correct_Returns_MovementCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "LEFT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "LEFT"), Arg.Is<List<string>>(x => x == null), Arg.Any<Grid>()).Returns(new Movement(MovementCommand.Left));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.AreEqual(CommandType.Movement, mappedCommand.CommandType);
        }

        [Test]
        public void Map_When_Left_Command_Is_Correct_Returns_MovementObject()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "LEFT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "LEFT"), Arg.Is<List<string>>(x => x == null), Arg.Any<Grid>()).Returns(new Movement(MovementCommand.Left));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.IsTrue(mappedCommand is Movement);
        }

        [Test]
        public void Map_When_Left_Command_Is_Correct_Returns_MovementObject_With_MovementCommand_Equal_Left()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "LEFT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "LEFT"), Arg.Is<List<string>>(x => x == null), Arg.Any<Grid>()).Returns(new Movement(MovementCommand.Left));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as Movement;
            //Assert
            Assert.AreEqual(MovementCommand.Left, mappedCommand.MovementCommand);
        }

        [Test]
        public void Map_When_Left_Command_Has_Parameters_Returns_Null()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "LEFT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "LEFT"), Arg.Is<List<string>>(x => x.Count > 0), Arg.Any<Grid>()).Returns((Movement)null);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }
    }
}
