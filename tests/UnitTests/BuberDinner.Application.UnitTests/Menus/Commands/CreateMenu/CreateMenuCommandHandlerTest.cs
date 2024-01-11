using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests 
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRespository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRespository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRespository.Object);
    }

    // T1: SUT - logical component we're testing
    // T2: Scenario - what we're testing
    // T3: Expected outcome - what we expect the logical component to do

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand) 
    {
        //Act
        //invoke the handler
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();

        //1. Validade correct menu created base on command
        result.Value.ValidateCreatedFrom(createMenuCommand);

        //2. menu added to repository
        _mockMenuRespository.Verify(m => m.AddAsync(result.Value), Times.Once());
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
    }

    //public void Test_HappyFlow() { }

    //public void Creating_A_Menu_Creates_And_Returns_Menu() { }

    //public void Handling_Create_Menu_Stores_Menu_In_DB() { }

    //public void Test_CreateMenuCommandHandler_HandleValid_ReturnsMenu() { }
}