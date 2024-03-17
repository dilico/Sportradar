namespace Sportradar.Scoreboard.UnitTests;

[TestClass]
public class MatchTests
{
  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  [DataRow(null, "Brazil", DisplayName = "Invalid home team")]
  [DataRow("Brazil", null, DisplayName = "Invalid away team")]
  [DataRow(null, null, DisplayName = "Invalid home and away teams")]
  public void Create_WithInvalidTeams_ThrowsArgumentException(string home, string away)
  {
    _ = new Match(home, away);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void Create_WithSameTeams_ThrowsArgumentException()
  {
    _ = new Match("Brazil", "Brazil");
  }

  [TestMethod]
  public void GetHomeTeam_ReturnsHomeTeam()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var match = new Match(homeTeam, awayTeam);
    Assert.AreEqual(homeTeam, match.HomeTeam.Name);
  }

  [TestMethod]
  public void GetAwayTeam_ReturnsAwayTeam()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var match = new Match(homeTeam, awayTeam);
    Assert.AreEqual(awayTeam, match.AwayTeam.Name);
  }

  [TestMethod]
  public void GetHomeScore_WhenMatchStarts_ReturnsZero()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var match = new Match(homeTeam, awayTeam);
    Assert.AreEqual(0, match.HomeScore);
  }

  [TestMethod]
  public void GetAwayScore_WhenMatchStarts_ReturnsZero()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var match = new Match(homeTeam, awayTeam);
    Assert.AreEqual(0, match.AwayScore);
  }

  [TestMethod]
  public void UpdateScore_WithValidScores_SetsScores()
  {
    var homeScore = 1;
    var awayScore = 1;
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var match = new Match(homeTeam, awayTeam);
    match.UpdateScore(homeScore, awayScore);
    Assert.AreEqual(homeScore, match.HomeScore);
    Assert.AreEqual(awayScore, match.AwayScore);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  [DataRow(-1, 2, DisplayName = "Invalid home score")]
  [DataRow(3, -2, DisplayName = "Invalid away score")]
  [DataRow(-3, -2, DisplayName = "Invalid home and away scores")]
  public void UpdateScore_WithInvalidScores_ThrowsArgumentException(int homeScore, int awayScore)
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var match = new Match(homeTeam, awayTeam);
    match.UpdateScore(homeScore, awayScore);
  }
}
