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
}
