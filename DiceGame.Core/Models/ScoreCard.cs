namespace DiceGame.Models;

public class ScoreCard
{
    private bool _bonusAwarded;
    public Dictionary<ScoreRow, int?> Rows { get; set; } = new Dictionary<ScoreRow, int?>();
    public int TotalScore { get; private set; }

    private int _tableOneTotalScore;
    private readonly int _minValueToGetBonus = 63;
    private readonly int _bonus = 35;

    public ScoreCard()
    {
        _bonusAwarded = false;
        TotalScore = 0;
        _tableOneTotalScore = 0;
        foreach (ScoreRow row in Enum.GetValues(typeof(ScoreRow)))
        {
            Rows.Add(row, null);
        }
    }

    public void MarkScore(ScoreRow row, int score)
    {
        if (Rows[row] != null) return;
        
        Rows[row] = score;
        TotalScore += score;
        
        if (row.GetSection() == ScoreSection.Upper)
        {
            _tableOneTotalScore += score;
        
            if (!_bonusAwarded && _tableOneTotalScore >= _minValueToGetBonus)
            {
                _bonusAwarded = true;
                TotalScore += _bonus;
            }
        }
    }
}