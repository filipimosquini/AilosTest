using Questao2.Configurations.Infrastructure.IoC;
using Questao2.Domain.Services;
using SimpleInjector.Lifestyles;

public class Program
{
    private static BootStraper _bootStraper;

    public static void Main()
    {

        _bootStraper = new BootStraper();
        _bootStraper.Configure();

        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        using (_ = AsyncScopedLifestyle.BeginScope(_bootStraper.Container))
        {
            var service = _bootStraper.Container.GetInstance<IFootballService>();
            var teamInformation = Task.Run(async () => await service.GetTeamInformation(year, team)).Result;

            return teamInformation.Goals;
        }
    }

}