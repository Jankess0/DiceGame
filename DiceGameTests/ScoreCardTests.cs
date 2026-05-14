using DiceGame.Models;

namespace DiceGameTests;

public class ScoreCardTests
{
    private readonly ScoreCard _scoreCard = new ScoreCard();

    [Theory]
    [InlineData(63, 98)]
    [InlineData(62, 62)]
    public void MarkScore_ShouldAddBonus(int score, int totalScore)
    {
        // Act
        _scoreCard.MarkScore(ScoreRow.Ones, score);

        // Assert
        var result = _scoreCard.TotalScore;
        Assert.Equal(totalScore, result);
    }
    
    
}