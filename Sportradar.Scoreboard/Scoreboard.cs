using System.Text;

namespace Sportradar.Scoreboard;

public class Scoreboard
{
  private IList<Match> Matches { get; } = [];

  public void StartMatch(string homeTeam, string awayTeam)
  {
    var match = new Match(homeTeam, awayTeam);
    Matches.Add(match);
  }

  public void UpdateMatch(string homeTeam, string awayTeam, int homeScore, int awayScore)
  {
    var match = FindMatch(homeTeam, awayTeam);
    match?.UpdateScores(homeScore, awayScore);
  }

  public void FinishMatch(string homeTeam, string awayTeam)
  {
    var match = FindMatch(homeTeam, awayTeam);
    if (match != null)
    {
      Matches.Remove(match);
    }
  }

  public IList<Match> GetMatches() => Matches
    .OrderByDescending(m => m.HomeScore + m.AwayScore)
    .ThenByDescending(m => m.StartTime)
    .ToList();

  public string GetSummary()
  {
    var builder = new StringBuilder();
    var matches = GetMatches();
    for (int i = 0; i < matches.Count; i += 1)
    {
      var match = matches[i];
      builder.AppendLine(@$"{i + 1}. {match.HomeTeam.Name} {match.HomeScore} - {match.AwayTeam.Name} {match.AwayScore}");
    }
    return builder.ToString().TrimEnd('\r', '\n');
  }

  private Match? FindMatch(string homeTeam, string awayTeam) =>
    Matches.SingleOrDefault(m => IsSameTeam(m.HomeTeam, homeTeam)
      && IsSameTeam(m.AwayTeam, awayTeam));

  private static bool IsSameTeam(Team team, string name) =>
    string.Equals(team.Name.Trim(), name?.Trim(), StringComparison.OrdinalIgnoreCase);
}
