using DiceGame.Models;
using DiceGame.UI;

namespace DiceGame.ConsoleUI;

public class ConsoleUserInterface : IUserInterface
{
    public Task ShowDiceAsync(Dice[] dices)
    {
        Console.WriteLine("\n----- Throw result -----");
        for (int i = 0; i < dices.Length; i++)
        {
            string held = dices[i].IsHeld ? "Held" : "";
            Console.WriteLine($"Dice {i + 1}: {dices[i].Value} {held}");
        }
        return Task.CompletedTask;
    }

    public async Task<bool[]> AskHoldAsync(Dice[] currentDices)
    {
        Console.WriteLine("\nEnter number of dices to held, enter numbers separated by spaces (1 4 3)");
        Console.WriteLine("Press ENTER to reroll dices");
        
        string? input = await Console.In.ReadLineAsync();
        bool[] heldDices = new bool[currentDices.Length];

        for (int i = 0; i < currentDices.Length; i++)
        {
            heldDices[i] = currentDices[i].IsHeld;
        }
        
        if (string.IsNullOrWhiteSpace(input))
            return heldDices;
        
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in parts)
        {
            if (int.TryParse(part, out int diceNumber) && diceNumber >= 1 && diceNumber <= currentDices.Length)
            {
                heldDices[diceNumber - 1] = true;
            }
        }
        return heldDices;
    }

    public async Task<ScoreRow> AskScoreRowAsync(List<ScoreRow> availableRows)
    {
        throw new NotImplementedException();
    }

    public Task ShowScore(List<Player> players)
    {
        throw new NotImplementedException();
    }

    public Task ShowWinnerAsync(List<Player> players)
    {
        throw new NotImplementedException();
    }

    public Task ShowScoreCardAsync(Player player)
    {
        throw new NotImplementedException();
    }

    public Task<int> AskPlayerCountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<string> AskPlayerNameAsync()
    {
        throw new NotImplementedException();
    }
}