namespace Sportradar.Scoreboard.UnitTests;

public class DummyMatchesRepository
{
  public static IList<(string homeTeam, string awayTeam, int homeScore, int awayScore)> Get()
  {
    return [
      ("Mexico", "Canada", 0, 5),
      ("Spain", "Brazil", 10, 2),
      ("Germany", "France", 2, 2),
      ("Uruguay", "Italy", 6, 6),
      ("Argentina", "Australia", 3, 1),
    ];
  }
}
