using System.Reflection;

namespace DiceGame.Models;

public static class ScoreRowExnetsions
{
    public static ScoreSection GetSection(this ScoreRow row)
    {
        var field = typeof(ScoreRow).GetField(row.ToString())!;
        return field.GetCustomAttribute<ScoreSectionsAttribute>()!.Section;
    }
}