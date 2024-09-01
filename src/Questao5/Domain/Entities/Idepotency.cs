using System;

namespace Questao5.Domain.Entities;

public class Idepotency
{
    public string Id { get; set; }
    public string Request { get; set; }
    public string Response { get; set; }
}