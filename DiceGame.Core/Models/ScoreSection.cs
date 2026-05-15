namespace DiceGame.Models;

public enum ScoreSection
{
    Upper,
    Lower
}

[AttributeUsage(AttributeTargets.Field)]
public class ScoreSectionsAttribute(ScoreSection section) : Attribute
{
    public ScoreSection Section { get; } = section;
}