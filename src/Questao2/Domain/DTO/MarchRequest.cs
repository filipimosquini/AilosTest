namespace Questao2.Domain.DTO;

public class MarchRequest
{
    public int Year { get; set; }
    public string Team1 { get; set; }

    public string ToQueryString(int page)
        => $"?year={Year}&team1={Team1}&page={page}";
}