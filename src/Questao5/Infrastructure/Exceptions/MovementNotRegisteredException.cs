using Questao5.Infrastructure.Configurations.Exceptions;
using System.Net;

namespace Questao5.Infrastructure.Exceptions;

public class MovementNotRegisteredException : AppCustomException
{
    public MovementNotRegisteredException() : base("NOTREGISTERED_MOVEMENT", HttpStatusCode.UnprocessableEntity)
    {
    }
}