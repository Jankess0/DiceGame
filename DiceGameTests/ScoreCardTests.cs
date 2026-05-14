using DiceGame.Models;

namespace DiceGameTests;

public class ScoreCardTests
{
    private readonly ScoreCard _scoreCard = new ScoreCard();

    [Theory]
    [InlineData(63, 98, ScoreRow.Ones)]
    [InlineData(62, 62, ScoreRow.Threes)]
    [InlineData(65, 65, ScoreRow.FourOfAKind)]
    public void MarkScore_ShouldAddBonus(int score, int totalScore, ScoreRow scoreRow)
    {
        // Arrange & Act
        _scoreCard.MarkScore(scoreRow, score);

        // Assert
        var result = _scoreCard.TotalScore;
        Assert.Equal(totalScore, result);
    }
    
    
}