namespace Sportradar.Scoreboard;

public class Match(string homeTeam, string awayTeam)
{
  private TeamWithScore Home { get; } = new TeamWithScore(new Team(homeTeam));
  private TeamWithScore Away { get; } = new TeamWithScore(new Team(awayTeam));
  public Team HomeTeam => Home.Team;
  public Team AwayTeam => Away.Team;
  public int HomeScore => Home.Score;
  public int AwayScore => Away.Score;
}
