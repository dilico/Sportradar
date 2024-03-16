namespace Sportradar.Scoreboard.UnitTests;

[TestClass]
public class TeamTests
{
  [TestMethod]
  [DataRow("West Ham", "West Ham")]
  [DataRow(" West Ham", "West Ham")]
  [DataRow("West Ham ", "West Ham")]
  [DataRow(" West Ham ", "West Ham")]
  [DataRow("  West Ham  ", "West Ham")]
  public void Create_SetsName(string name, string expected)
  {
    var team = new Team(name);
    Assert.AreEqual(expected, team.Name);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentException))]
  [DataRow(" ", DisplayName = "Team name with only whitespaces")]
  [DataRow("", DisplayName = "Empty team name")]
  [DataRow(null, DisplayName = "Null team name")]
  public void Create_WithInvalidName_ThrowsArgumentException(string name)
  {
    _ = new Team(name);
  }
}