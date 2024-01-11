using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<CreateMenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record CreateMenuSectionCommand(
    string Name,
    string Description,
    List<CreateMenuItemCommand> Items);

public record CreateMenuItemCommand(
    string Name,
    string Description);

