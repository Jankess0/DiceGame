namespace DiceGame.Models;

public class Player
{
    public string Name { get; set; }
    public ScoreCard PlayerScoreCard { get; set; }

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