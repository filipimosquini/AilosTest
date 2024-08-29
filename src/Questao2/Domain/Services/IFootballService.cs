using Questao2.Domain.Models;

namespace Questao2.Domain.Services;

public interface IFootballService
{
    Task<Team> GetTeamInformation(int year, string teamName);
}