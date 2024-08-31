using System.Net;
using Questao5.Infrastructure.Configurations.Exceptions;

namespace Questao5.Infrastructure.Exceptions;

public class AccountNotFoundException : AppCustomException
{
    public AccountNotFoundException() : base("INVALID_ACCOUNT", HttpStatusCode.NotFound)
    {
    }
}