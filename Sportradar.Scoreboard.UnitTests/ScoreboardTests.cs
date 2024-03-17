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

  [TestMethod]
  public void FinishMatch_WhenMatchInList_RemovesMatchFromList()
  {
    var (homeTeam, awayTeam, _, _) = DummyMatchesRepository.Get()[0];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(homeTeam, awayTeam);
    scoreboard.FinishMatch(homeTeam, awayTeam);
    Assert.AreEqual(0, scoreboard.GetMatches().Count);
  }

  [TestMethod]
  public void FinishMatch_WhenMatchNotInList_DoesntChangeList()
  {
    var firstMatch = DummyMatchesRepository.Get()[0];
    var secondMatch = DummyMatchesRepository.Get()[1];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(firstMatch.homeTeam, firstMatch.awayTeam);
    Assert.AreEqual(1, scoreboard.GetMatches().Count);
    scoreboard.FinishMatch(secondMatch.homeTeam, secondMatch.awayTeam);
    Assert.AreEqual(1, scoreboard.GetMatches().Count);
  }

  [TestMethod]
  public void GetMatches_ReturnsMatchesOrderedByTotalScore()
  {
    var firstMatch = DummyMatchesRepository.Get()[0];
    var secondMatch = DummyMatchesRepository.Get()[1];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(firstMatch.homeTeam, firstMatch.awayTeam);
    scoreboard.StartMatch(secondMatch.homeTeam, secondMatch.awayTeam);
    scoreboard.UpdateMatch(secondMatch.homeTeam,
      secondMatch.awayTeam, 1, 1);
    var scoreboardMatches = scoreboard.GetMatches();
    Assert.AreEqual(2, scoreboardMatches.Count);
    Assert.AreEqual(secondMatch.homeTeam, scoreboardMatches[0].HomeTeam.Name);
    Assert.AreEqual(secondMatch.awayTeam, scoreboardMatches[0].AwayTeam.Name);
    Assert.AreEqual(firstMatch.homeTeam, scoreboardMatches[1].HomeTeam.Name);
    Assert.AreEqual(firstMatch.awayTeam, scoreboardMatches[1].AwayTeam.Name);
  }

  [TestMethod]
  public void GetMatches_WithSameScore_ReturnsMatchesOrderedByMostRecent()
  {
    var firstMatch = DummyMatchesRepository.Get()[0];
    var secondMatch = DummyMatchesRepository.Get()[1];
    var scoreboard = new Scoreboard();
    scoreboard.StartMatch(firstMatch.homeTeam, firstMatch.awayTeam);
    scoreboard.UpdateMatch(firstMatch.homeTeam,
      firstMatch.awayTeam, 1, 1);
    scoreboard.StartMatch(secondMatch.homeTeam, secondMatch.awayTeam);
    scoreboard.UpdateMatch(secondMatch.homeTeam,
      secondMatch.awayTeam, 1, 1);
    var scoreboardMatches = scoreboard.GetMatches();
    Assert.AreEqual(2, scoreboardMatches.Count);
    Assert.AreEqual(secondMatch.homeTeam, scoreboardMatches[0].HomeTeam.Name);
    Assert.AreEqual(secondMatch.awayTeam, scoreboardMatches[0].AwayTeam.Name);
    Assert.AreEqual(firstMatch.homeTeam, scoreboardMatches[1].HomeTeam.Name);
    Assert.AreEqual(firstMatch.awayTeam, scoreboardMatches[1].AwayTeam.Name);
  }

  [TestMethod]
  public void GetSummary_ReturnsSummaryOfMatchesInOrder()
  {
    var scoreboard = new Scoreboard();
    foreach (var (homeTeam, awayTeam, homeScore, awayScore) in DummyMatchesRepository.Get())
    {
      scoreboard.StartMatch(homeTeam, awayTeam);
      scoreboard.UpdateMatch(homeTeam, awayTeam, homeScore, awayScore);
    }
    var expected = @$"1. Uruguay 6 - Italy 6{Environment.NewLine}2. Spain 10 - Brazil 2{Environment.NewLine}3. Mexico 0 - Canada 5{Environment.NewLine}4. Argentina 3 - Australia 1{Environment.NewLine}5. Germany 2 - France 2";
    Assert.AreEqual(expected, scoreboard.GetSummary());
  }

  [TestMethod]
  public void GetSummary_EmptyScoreboard_ReturnsEmptyString()
  {
    var scoreboard = new Scoreboard();
    Assert.IsTrue(string.IsNullOrEmpty(scoreboard.GetSummary()));
  }
}