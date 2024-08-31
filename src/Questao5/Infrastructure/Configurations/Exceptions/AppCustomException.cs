using System;
using System.Net;

namespace Questao5.Infrastructure.Configurations.Exceptions;

public class AppCustomException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }

    public AppCustomException(string message, HttpStatusCode httpStatusCode) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}