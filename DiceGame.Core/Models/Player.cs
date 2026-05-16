namespace DiceGame.Models;

public class Player
{
    public string Name { get; }
    public ScoreCard PlayerScoreCard { get; }

    public Player(string name)
    {
        Name = name;
        PlayerScoreCard = new ScoreCard();
    }

    public int TotalScore()
    {
        return PlayerScoreCard.TotalScore;
    }
}