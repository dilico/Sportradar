namespace Sportradar.Scoreboard;

public class Scoreboard
{
  private IList<Match> Matches { get; } = [];

  public IList<Match> GetMatches()
  {
    return Matches;
  }
}
