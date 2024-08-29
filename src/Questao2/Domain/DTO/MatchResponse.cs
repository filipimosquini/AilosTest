using Newtonsoft.Json;

namespace Questao2.Domain.DTO;

public partial class MatchResponse
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    [JsonProperty("data")]
    public IEnumerable<MatchDataResponse> Data { get; set; }

    public MatchResponse()
    {
        Data = new List<MatchDataResponse>();
    }
}