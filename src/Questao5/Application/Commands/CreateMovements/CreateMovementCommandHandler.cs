using MediatR;
using Questao5.Application.Commands.Movements.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Commands.Movements;

public class CreateMovementCommandHandler : IRequestHandler<CreateMovementCommand, CreateMovementCommandResponse>
{
    public Task<CreateMovementCommandResponse> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}