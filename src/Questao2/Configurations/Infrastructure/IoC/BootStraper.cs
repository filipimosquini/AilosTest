using Questao2.Domain.Services;
using Questao2.Infrastructure.Repositories;
using RestSharp;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Questao2.Configurations.Infrastructure.IoC;

public class BootStraper
{
    public Container Container;

    public void Configure()
    {
        Container = new Container();
        Container.Options.DefaultLifestyle = Lifestyle.Transient;
        Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        Container.RegisterSingleton(() => new RestClient("https://jsonmock.hackerrank.com/api/football_matches"));

        Container.Register<IFootballRepository, FootballRepository>(Lifestyle.Scoped);
        Container.Register<IFootballService, FootballService>(Lifestyle.Scoped);

        Container.Verify();
    }
}