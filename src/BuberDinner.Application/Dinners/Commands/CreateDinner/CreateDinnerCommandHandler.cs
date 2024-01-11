using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner;

public class CreateDinnerCommandHandler : IRequestHandler<CreateDinnerCommand, ErrorOr<Dinner>>
{
    private readonly IDinnerRepository _dinnerRepository;

    private readonly IUserRepository _userRepository;

    public CreateDinnerCommandHandler(IUserRepository userRepository, IDinnerRepository dinnerRepository)
    {
        _userRepository = userRepository;
        _dinnerRepository = dinnerRepository;
    }

    public async Task<ErrorOr<Dinner>> Handle(CreateDinnerCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(request.HostId) is not User user)
        {
            return Errors.GeneralErrors.Unexpected;
        }

        var createdDinnerResult = Dinner.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            user);

        await _dinnerRepository.AddAsync(createdDinnerResult);

        return createdDinnerResult;
    }
}
