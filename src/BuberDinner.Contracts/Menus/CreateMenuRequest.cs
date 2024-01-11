namespace BuberDinner.Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<CreateMenuSectionRequest> Sections);

public record CreateMenuSectionRequest(
    string Name,
    string Description,
    List<CreateMenuItemRequest> Items);

public record CreateMenuItemRequest(
    string Name,
    string Description);
