![Header](./Resources/Sportradar-Brand-Line_Color_White.svg#gh-dark-mode-only)
![Header](./Resources/Sportradar-Brand-Line_Color_Black.svg#gh-light-mode-only)

## 📖 About 
The Sportradar Live Football World Cup Scoreboard is a library for dotnet programs, which gives access to all the ongoing matches and their scores.

## 🚀 Usage
Start a new match:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("West Ham", "AC Milan");
// Scoreboard has one match: West Ham 0 - AC Milan 0
```

Update a score:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("West Ham", "AC Milan");
// Scoreboard has one match: West Ham 0 - AC Milan 0

scoreboard.UpdateMatch("West Ham", "AC Milan", 1, 1);
// Scoreboard has one match: West Ham 1 - AC Milan 1
```

Finish a match:
```C#
var scoreboard = new Scoreboard();

scoreboard.StartMatch("West Ham", "AC Milan");
// Scoreboard has one match: West Ham 0 - AC Milan 0

scoreboard.FinishMatch("West Ham", "AC Milan");
// Scoreboard is empty
```

Get a summary of matches in progress ordered by their total score:
```C#
```

## 💡 Assumptions
* The only constraint on score updates is that new scores must be positive numbers. There are no requirements on how often a match is updated, so a new score could include multiple additional goals. Also, a new score could be less than the current one, if for example a goal has been disallowed.

## 🙋 Questions

## 👯 Contributors
<a href="https://github.com/dilico">
  <img src="https://github.com/dilico.png" width="40px;"/>
</a>