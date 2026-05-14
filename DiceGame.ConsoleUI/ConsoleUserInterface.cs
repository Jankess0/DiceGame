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
        Console.WriteLine("\nChoose which category you want to score:");
        for (int i = 0; i < availableRows.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableRows[i]}");
        }

        while (true)
        {
            Console.WriteLine("Your choice:");
            string input = await Console.In.ReadLineAsync();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= availableRows.Count)
            {
                return availableRows[choice - 1];
            }
            Console.WriteLine("Invalid choice. Try again.");
        }
    }

    public Task ShowScore(List<Player> players)
    {
        Console.WriteLine("\n----- Score Board ----");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.PlayerScoreCard.TotalScore}");
        }
        return Task.CompletedTask;
    }

    public Task ShowWinnerAsync(List<Player> players)
    {
        Console.WriteLine("\n=============================");
        Console.WriteLine("          End Game        ");
        Console.WriteLine("=============================");
        
        var sortedPlayers = players.OrderByDescending(p => p.PlayerScoreCard.TotalScore).ToList();
        
        Console.WriteLine($"\nWinner: {sortedPlayers.First().Name} with score: {sortedPlayers.First().PlayerScoreCard.TotalScore} points!");
        
        return ShowScore(sortedPlayers);
    }

    public Task ShowScoreCardAsync(Player player)
    {
        Console.Clear();
        Console.WriteLine($"\n--- Player: {player.Name} Turn ---");
        return Task.CompletedTask;
    }

    public async Task<int> AskPlayerCountAsync()
    {
        int minPlayers = 2;
        int maxPlayers = 4;
        Console.WriteLine("Welcome to DiceGame!");
        while (true)
        {
            Console.Write("Enter number of players(2-4): ");
            string? input = await Console.In.ReadLineAsync();
            if (int.TryParse(input, out int count) && count >= minPlayers && count <= maxPlayers)
            {
                return count;
            }
            Console.WriteLine("Invalid choice. Try again.");
        }
    }

    public async Task<string> AskPlayerNameAsync()
    {
        Console.Write("Enter player name: ");
        string? name = await Console.In.ReadLineAsync();
        return string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
    }
}