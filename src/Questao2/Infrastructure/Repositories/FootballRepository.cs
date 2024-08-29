using Newtonsoft.Json;
using Questao2.Domain.DTO;
using RestSharp;

namespace Questao2.Infrastructure.Repositories;

public class FootballRepository : IFootballRepository
{
    private readonly RestClient _restClient;

    public FootballRepository(RestClient restClient)
    {
        _restClient = restClient;
    }

    public async Task<MatchResponse> GetMatches(MarchRequest request)
    {
        var response = await GetMatches(request, 1);

        if (response.TotalPages == 0 || response.TotalPages == 1)
        {
            return response;
        }

        var pages = 1;

        while (response.TotalPages > pages)
        {
            pages++;
            var response1 = await GetMatches(request, pages);

            if (response1.Data.Any())
            {
                response.Data = response.Data.Concat(response1.Data);
            }
        }

        return response;
    }

    private async Task<MatchResponse> GetMatches(MarchRequest request, int page)
    {
        var response = await _restClient.ExecuteAsync(new RestRequest(request.ToQueryString(page), Method.Get));

        if (!response.IsSuccessStatusCode)
        {
            return new MatchResponse();
        }

        return JsonConvert.DeserializeObject<MatchResponse>(response.Content);
    }
}