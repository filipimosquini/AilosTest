using Questao5.BuildingBlocks.Exceptions;
using System.Net;

namespace Questao5.Infrastructure.Exceptions;

public class AccountInactiveException : AppCustomException
{
    public AccountInactiveException() : base("INACTIVE_ACCOUNT", HttpStatusCode.BadRequest)
    {
    }
}