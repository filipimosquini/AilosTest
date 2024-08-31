using Questao5.Infrastructure.Configurations.Exceptions;
using System.Net;

namespace Questao5.Infrastructure.Exceptions;

public class AccountInactiveException : AppCustomException
{
    public AccountInactiveException() : base("INACTIVE_ACCOUNT", HttpStatusCode.BadRequest)
    {
    }
}