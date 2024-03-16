﻿namespace Sportradar.Scoreboard;

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

  private Match? FindMatch(string homeTeam, string awayTeam)
  {
    return Matches
      .SingleOrDefault(m => IsSameTeam(m.HomeTeam, homeTeam)
        && IsSameTeam(m.AwayTeam, awayTeam));
  }

  private static bool IsSameTeam(Team team, string name)
  {
    return string.Equals(team.Name.Trim(), name?.Trim(),
      StringComparison.OrdinalIgnoreCase);
  }
}
