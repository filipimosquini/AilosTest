﻿using Questao5.BuildingBlocks.Exceptions;
using System.Net;

namespace Questao5.Infrastructure.Exceptions;

public class MovementNotRegisteredException : AppCustomException
{
    public MovementNotRegisteredException() : base("NOTREGISTERED_MOVEMENT", HttpStatusCode.UnprocessableEntity)
    {
    }
}