﻿using System;

namespace Questao5.Infrastructure.Database.Idepotencies.Models;

public class UpdateIdepotencyRequest
{
    public Guid Id { get; set; }
    public string Response { get; set; }
}