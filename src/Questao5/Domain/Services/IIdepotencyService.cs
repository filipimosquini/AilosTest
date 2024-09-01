using System.Threading.Tasks;
using System;

namespace Questao5.Domain.Services;

public interface IIdepotencyService
{
    Task<(bool Created, bool RequestOverwrited, bool HasResponse, string Request, string Response)>
        CreateIdepotencyAsync(Guid idepotencyToken, string jsonRequest);
    Task UpdateIdepotencyAsync(Guid idepotencyToken, string jsonResponse);
}