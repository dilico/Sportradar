namespace Sportradar.Scoreboard;

public class Match(string homeTeam, string awayTeam)
{
  public Team HomeTeam { get; } = new Team(homeTeam);
  public Team AwayTeam { get; } = new Team(awayTeam);
  public int HomeScore { get; private set; } = 0;
  public int AwayScore { get; private set; } = 0;
  public DateTime StartTime { get; } = DateTime.UtcNow;

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
