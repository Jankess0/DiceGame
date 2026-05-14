namespace DiceGame.Models;

public class Dice
{
    public int Value { get; private set; }
    public bool IsHeld { get; set; }

    public void Roll()
    {
        if (IsHeld) return;
        Value = Random.Shared.Next(1, 7);
    }
}