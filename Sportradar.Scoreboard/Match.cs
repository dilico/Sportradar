namespace Sportradar.Scoreboard;

public class Match
{
  public Team HomeTeam { get; }
  public Team AwayTeam { get; }
  public int HomeScore { get; private set; } = 0;
  public int AwayScore { get; private set; } = 0;
  public DateTime StartTime { get; } = DateTime.UtcNow;

  public Match(string homeTeam, string awayTeam)
  {
    var home = new Team(homeTeam);
    var away = new Team(awayTeam);
    if (string.Equals(home.Name, away.Name))
    {
      throw new ArgumentException("Match cannot have same team for home and away");
    }
    HomeTeam = home;
    AwayTeam = away;
  }

  public void UpdateScores(int homeScore, int awayScore)
  {
    if (homeScore < 0)
    {
      throw new ArgumentException("Home score cannot be negative");
    }
    if (awayScore < 0)
    {
      throw new ArgumentException("Away score cannot be negative");
    }
    HomeScore = homeScore;
    AwayScore = awayScore;
  }
}
