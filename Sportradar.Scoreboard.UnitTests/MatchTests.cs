namespace Sportradar.Scoreboard.UnitTests;

[TestClass]
public class MatchTests
{
  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  [DataRow(null, "West Ham", DisplayName = "Invalid home team")]
  [DataRow("West Ham", null, DisplayName = "Invalid away team")]
  [DataRow(null, null, DisplayName = "Invalid home and away teams")]
  public void Create_WithInvalidTeams_ThrowsArgumentException(string home, string away)
  {
    _ = new Match(home, away);
  }

  [TestMethod]
  public void GetHome_ReturnsHomeTeam()
  {
    var home = "West Ham";
    var match = new Match(home, "AC Milan");
    Assert.AreEqual(home, match.HomeTeam.Name);
  }

  [TestMethod]
  public void GetHome_ReturnsAwayTeam()
  {
    var away = "AC Milan";
    var match = new Match("West Ham", away);
    Assert.AreEqual(away, match.AwayTeam.Name);
  }

  [TestMethod]
  public void GetHomeScore_WhenMatchStarts_ReturnsZero()
  {
    var match = new Match("West Ham", "AC Milan");
    Assert.AreEqual(0, match.HomeScore);
  }

  [TestMethod]
  public void GetAwayScore_WhenMatchStarts_ReturnsZero()
  {
    var match = new Match("West Ham", "AC Milan");
    Assert.AreEqual(0, match.AwayScore);
  }
}
