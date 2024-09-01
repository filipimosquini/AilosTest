using System;

namespace Questao5.Infrastructure.Database.Idepotencies.Models;

public class CreateIdepotencyRequest
{
    public Guid Id { get; set; }
    public string Request { get; set; }
}