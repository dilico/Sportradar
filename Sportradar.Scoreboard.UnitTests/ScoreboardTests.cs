namespace Sportradar.Scoreboard.UnitTests;

[TestClass]
public class ScoreboardTests
{
  [TestMethod]
  public void Create_ReturnsEmptyListOfMatches()
  {
    var scoreboard = new Scoreboard();
    Assert.AreEqual(0, scoreboard.GetMatches().Count);
  }

  [TestMethod]
  public void StartMatch_WithValidTeams_AddsMatchToList()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(homeTeam, awayTeam);
    Assert.AreEqual(1, scoreboard.GetMatches().Count);
  }

  [TestMethod]
  public void StartMatch_MultipleTimes_AddsAllMatchesToList()
  {
    var firstMatch = DummyMatchesRepository.Get()[0];
    var secondMatch = DummyMatchesRepository.Get()[1];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(firstMatch.homeTeam, firstMatch.awayTeam);
    scoreboard.StartMatch(secondMatch.homeTeam, secondMatch.awayTeam);
    Assert.AreEqual(2, scoreboard.GetMatches().Count);
  }

  [TestMethod]
  public void UpdateMatch_WithValidScores_SetsScore()
  {
    var (homeTeam, awayTeam, homeScore, awayScore) = DummyMatchesRepository.Get()[0];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(homeTeam, awayTeam);
    scoreboard.UpdateMatch(homeTeam, awayTeam, homeScore, awayScore);
    Assert.AreEqual(homeScore, scoreboard.GetMatches()[0].HomeScore);
    Assert.AreEqual(awayScore, scoreboard.GetMatches()[0].AwayScore);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  public void UpdateMatch_WithInvalidValidScores_ThrowsArgumentException()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(homeTeam, awayTeam);
    scoreboard.UpdateMatch(homeTeam, awayTeam, -1, -1);
  }
}
