using System;
using System.Net;

namespace Questao5.BuildingBlocks.Exceptions;

public class AppCustomException : Exception
{
    public HttpStatusCode HttpStatusCode { get; }

    public AppCustomException(string message, HttpStatusCode httpStatusCode) : base(message)
    {
        HttpStatusCode = httpStatusCode;
    }
}