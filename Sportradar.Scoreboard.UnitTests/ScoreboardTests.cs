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
}
