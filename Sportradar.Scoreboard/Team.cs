namespace Sportradar.Scoreboard;

public class Team
{
  public string Name { get; }

  public Team(string name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new ArgumentException("Team name cannot be empty");
    }
    Name = name.Trim();
  }
}
