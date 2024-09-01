using System;

namespace Questao5.Domain.Entities;

public class Idempotency
{
    public string Id { get; set; }
    public string Request { get; set; }
    public string Response { get; set; }
}