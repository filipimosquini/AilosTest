using Questao2.Domain.DTO;
using Questao2.Domain.Models;
using Questao2.Infrastructure.Repositories;

namespace Questao2.Domain.Services;

public class FootballService : IFootballService
{
    private readonly IFootballRepository _footballRepository;

    public FootballService(IFootballRepository footballRepository)
    {
        _footballRepository = footballRepository;
    }

    public async Task<Team> GetTeamInformation(int year, string teamName)
    {
        var response = await _footballRepository.GetMatches(new MarchRequest
        {
            Year = year,
            Team1 = teamName
        });

        if (!response.Data.Any())
        {
            return new Team()
            {
                Name = teamName,
                Goals = 0
            };
        }

        return new Team()
        {
            Name = teamName,
            Goals = response.Data.Sum(x => x.Team1Goals)
        };
    }
}