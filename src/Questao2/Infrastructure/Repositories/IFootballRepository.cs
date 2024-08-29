using Questao2.Domain.DTO;

namespace Questao2.Infrastructure.Repositories;

public interface IFootballRepository
{
    public Task<MatchResponse> GetMatches(MarchRequest request);
}