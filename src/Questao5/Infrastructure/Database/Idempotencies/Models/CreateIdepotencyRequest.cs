using System;

namespace Questao5.Infrastructure.Database.Idempotencies.Models;

public class CreateIdepotencyRequest
{
    public Guid Id { get; set; }
    public string Request { get; set; }
}