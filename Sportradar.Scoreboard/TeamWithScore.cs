namespace Sportradar.Scoreboard;

internal class TeamWithScore(Team team)
{
  public Team Team { get; } = team;
  public int Score { get; } = 0;
}
