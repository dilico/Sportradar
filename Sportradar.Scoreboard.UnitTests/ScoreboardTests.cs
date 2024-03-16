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
}
