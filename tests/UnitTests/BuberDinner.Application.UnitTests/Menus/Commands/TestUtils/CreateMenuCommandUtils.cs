using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using System.Linq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils 
{
    // name
    // description
    //list of sections
    public static CreateMenuCommand CreateCommand() => 
        new CreateMenuCommand(
            Constants.Host.Id.Value.ToString(),
            Constants.Menu.Name,
            Constants.Menu.Description,
            CreateSectionsCommand());

    public static List<CreateMenuSectionCommand> CreateSectionsCommand(int sectionCount = 1) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDescriptionFromIndex(index),
                    CreateItemsCommand()))
            .ToList();

    public static List<CreateMenuItemCommand> CreateItemsCommand(int sectionCount = 1) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuItemCommand(
                    Constants.Menu.ItemNameFromIndex(index),
                    Constants.Menu.ItemDescriptionFromIndex(index)))
            .ToList();
}