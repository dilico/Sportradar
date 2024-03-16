namespace Sportradar.Scoreboard;

public class Scoreboard
{
  private IList<Match> Matches { get; } = [];

  public IList<Match> GetMatches()
  {
    return Matches;
  }

  public void StartMatch(string homeTeam, string awayTeam)
  {
    var match = new Match(homeTeam, awayTeam);
    Matches.Add(match);
  }

  public void UpdateMatch(string homeTeam, string awayTeam, int homeScore, int awayScore)
  {
    foreach (var match in Matches)
    {
      if (IsSameTeam(match.HomeTeam, homeTeam)
        && IsSameTeam(match.AwayTeam, awayTeam))
      {
        match.UpdateScores(homeScore, awayScore);
        break;
      }
    }
  }

  private static bool IsSameTeam(Team team, string name)
  {
    return string.Equals(team.Name.Trim(), name?.Trim(),
      StringComparison.OrdinalIgnoreCase);
  }
}
