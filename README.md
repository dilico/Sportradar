![Header](./Resources/Sportradar-Brand-Line_Color_White.svg#gh-dark-mode-only)
![Header](./Resources/Sportradar-Brand-Line_Color_Black.svg#gh-light-mode-only)

## 📖 About 
The Sportradar Live Football World Cup Scoreboard is a library for dotnet programs, which gives access to all the ongoing matches and their scores.

## 🚀 Usage
Start a new match:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("Brazil", "Germany");
// Scoreboard has one match: Brazil 0 - Germany 0

scoreboard.StartMatch("Spain", "France");
// Scoreboard has two matches:
// Spain 0 - France 0
// Brazil 0 - Germany 0
```

Update a score:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("Brazil", "Germany");
// Scoreboard has one match: Brazil 0 - Germany 0

scoreboard.UpdateScore("Brazil", "Germany", 1, 1);
// Scoreboard has one match: Brazil 1 - Germany 1
```

Finish a match:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("Brazil", "Germany");
// Scoreboard has one match: Brazil 0 - Germany 0

scoreboard.FinishMatch("Brazil", "Germany");
// Scoreboard is empty
```

Get all matches in progress ordered by their total score. If two or more matches have the same total score, they are returned ordered by the most recently started match:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("Brazil", "Germany");
// Scoreboard has one match: Brazil 0 - Germany 0

scoreboard.UpdateScore("Brazil", "Germany", 1, 1);
// Scoreboard has one match: Brazil 1 - Germany 1

scoreboard.StartMatch("Mexico", "Portugal");
// Scoreboard has two matches:
// Brazil 1 - Germany 1
// Mexico 0 - Portugal 0

scoreboard.UpdateScore("Mexico", "Portugal", 1, 1);
// Scoreboard has two matches:
// Mexico 1 - Portugal 1
// Brazil 1 - Germany 1

scoreboard.GetMatches();
// Mexico 1 - Portugal 1
// Brazil 1 - Germany 1
```

Get a summary of matches in progress ordered by their total score. If two or more matches have the same total score, they are returned ordered by the most recently started match:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("Brazil", "Germany");
// Scoreboard has one match: Brazil 0 - Germany 0

scoreboard.UpdateScore("Brazil", "Germany", 1, 1);
// Scoreboard has one match: Brazil 1 - Germany 1

scoreboard.StartMatch("Mexico", "Portugal");
// Scoreboard has two matches:
// Brazil 1 - Germany 1
// Mexico 0 - Portugal 0

scoreboard.UpdateScore("Mexico", "Portugal", 1, 1);
// Scoreboard has two matches:
// Mexico 1 - Portugal 1
// Brazil 1 - Germany 1

Console.WriteLine(scoreboard.GetSummary());
// 1. Mexico 1 - Portugal 1
// 2. Brazil 1 - Germany 1
```

## 💡 Assumptions
* The only constraint on score updates is that new scores must be positive numbers. There are no requirements on how often a match is updated, so a new score could include multiple additional goals. Also, a new score could be less than the current one, if for example a goal has been disallowed.
* The scoreboard is implemented as an in-memory list of matches. When either the summary or the list of the matches is requested, the matches are sorted according to total score and start date. For a high number of requests, storing the matches in a sorted list would be more efficient in order to avoid sorting them each time.

## 👯 Contributors
<a href="https://github.com/dilico">
  <img src="https://github.com/dilico.png" width="40px;"/>
</a>