namespace Sportradar.Scoreboard;

internal class TeamWithScore(Team team)
{
  public Team Team { get; } = team;
  public int Score { get; set; } = 0;

  public void UpdateScore(int newScore)
  {
    if (newScore < 0)
    {
      throw new ArgumentException("Score cannot be negative");
    }
    Score = newScore;
  }
}
