using FluentValidation;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner;

public class CreateDinnerCommandValidator : AbstractValidator<CreateDinnerCommand>
{
    public CreateDinnerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartDateTime).NotEmpty();
        RuleFor(x => x.EndDateTime).NotEmpty();
        RuleFor(x => x.HostId).NotEmpty();
    }
}