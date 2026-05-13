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
            ScoreRow.ThreeOfAKind => groups.Any(g => g.Count() >= 3) ? values.Sum() : 0,
            ScoreRow.FourOfAKind => groups.Any(g => g.Count() >= 4) ? values.Sum() : 0,
            ScoreRow.Full => groups.Any(g => g.Count() == 2) && groups.Any(g => g.Count() == 3) ? 25 : 0,
            ScoreRow.SmallStraight => IsSmallStraigth(values) ? 30 : 0,
            ScoreRow.LargeStraight => IsLargeStraigth(values) ? 40 : 0,
            ScoreRow.King => groups.Count == 1 ? 50 : 0,
            ScoreRow.Chance => values.Sum(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static bool IsSmallStraigth(List<int> values)
    {
        HashSet<int> set = new HashSet<int>(values);
        if (set.IsSupersetOf(new[] { 1, 2, 3, 4 }) ||
            set.IsSupersetOf(new[] { 2, 3, 4, 5 }) ||
            set.IsSupersetOf(new[] { 3, 4, 5, 6 }))
        {
            return true;
        }
        return false;
    }

    private static bool IsLargeStraigth(List<int> values)
    {
        HashSet<int> set = new HashSet<int>(values);
        if (set.IsSupersetOf(new[] { 1, 2, 3, 4, 5 }) ||
            set.IsSupersetOf(new[] { 2, 3, 4, 5, 6 }))
        {
            return true;
        }
        return false;
    }
    
}