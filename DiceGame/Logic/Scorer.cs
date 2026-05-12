using DiceGame.Models;

namespace DiceGame.Logic;

public static class Scorer
{
    public static int Calculate(ScoreRow row, Dice[] dices)
    {
        var values = dices.Select(d => d.Value).ToList();
        var groups = values.GroupBy(v => v).ToList();

        return row switch
        {
            ScoreRow.Ones => values.Where(v => v == 1).Count() * 1,
            ScoreRow.Twos => values.Where(v => v == 2).Count() * 2,
            ScoreRow.Threes => values.Where(v => v == 3).Count() * 3,
            ScoreRow.Fours => values.Where(v => v == 4).Count() * 4,
            ScoreRow.Fives => values.Where(v => v == 5).Count() * 5,
            ScoreRow.Sixes => values.Where(v => v == 6).Count() * 6,
            ScoreRow.ThreeOfAKind => groups.Any(g => g.Count() == 3) ? values.Sum() : 0,
            ScoreRow.FourOfAKind => groups.Any(g => g.Count() == 4) ? values.Sum() : 0,
            ScoreRow.Full => groups.Any(g => g.Count() == 2) && groups.Any(g => g.Count() == 3) ? 25 : 0,
            _ => 0
            //TODO implement logic for rest rows
        };
    }
}