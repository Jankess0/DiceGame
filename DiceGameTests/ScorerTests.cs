using DiceGame.Logic;
using DiceGame.Models;

namespace DiceGameTests;

public class ScorerTests
{
    private Dice[] CreateDice(int d1, int d2, int d3, int d4, int d5)
    {
        return new[]
        {
            new Dice { Value = d1 },
            new Dice { Value = d2 },
            new Dice { Value = d3 },
            new Dice { Value = d4 },
            new Dice { Value = d5 }
        };
    }

    [Theory]
    [InlineData(1, 1, 2, 3, 4, 2)]
    [InlineData(1, 1, 1, 1, 1, 5)]
    [InlineData(2, 3, 4, 5, 6, 0)]
    public void Calculate_Ones_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.Ones, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(6, 6, 6, 6, 6, 30)]
    [InlineData(6, 6, 6, 2, 1, 18)]
    public void Calculate_Sixex_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.Sixes, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(6, 6, 6, 6, 6, 30)]
    [InlineData(6, 6, 6, 2, 1, 21)]
    [InlineData(6, 6, 3, 2, 1, 0)]
    public void Calculate_ThreeOfAKind_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.ThreeOfAKind, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(6, 6, 6, 6, 6, 30)]
    [InlineData(6, 6, 6, 2, 1, 0)]
    [InlineData(6, 6, 6, 6, 1, 25)]
    public void Calculate_FourOfAKind_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.FourOfAKind, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(4, 4, 4, 2, 2, 25)]
    [InlineData(4, 4, 4, 2, 1, 0)]
    public void Calculate_Full_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.Full, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 2, 30)]
    [InlineData(2, 3, 4, 5, 2, 30)]
    [InlineData(3, 4, 5, 6, 6, 30)]
    [InlineData(3, 4, 6, 6, 6, 0)]
    public void Calculate_SmallStraigth_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.SmallStraight, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5, 40)]
    [InlineData(2, 3, 4, 5, 6, 40)]
    [InlineData(3, 4, 5, 6, 6, 0)]
    public void Calculate_LargeStraigth_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.LargeStraight, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(5, 5, 5, 5, 5, 50)]
    [InlineData(5, 5, 5, 5, 6, 0)]
    public void Calculate_King_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.King, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }

    [Theory]
    [InlineData(5, 5, 5, 5, 5, 25)]
    [InlineData(5, 2, 3, 4, 1, 15)]
    public void Calculate_Chance_ReturnsCorrectScore(int d1, int d2, int d3, int d4, int d5, int excepted)
    {
        // Arrange
        var dice = CreateDice(d1, d2, d3, d4, d5);
        
        // Act
        var result = Scorer.Calculate(ScoreRow.Chance, dice);
        
        // Assert
        Assert.Equal(excepted, result);
    }
}