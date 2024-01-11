using BuberDinner.Domain.DinnerAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner;

public record CreateDinnerCommand(
    string HostId,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime) : IRequest<ErrorOr<Dinner>>;