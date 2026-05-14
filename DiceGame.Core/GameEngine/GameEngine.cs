using DiceGame.Logic;
using DiceGame.Models;
using DiceGame.UI;

namespace DiceGame.GameEngine;

public class GameEngine
{
    private readonly IUserInterface _ui;
    private readonly Game _game;
    
    private readonly int maxRollsPerTurn = 3;
    public GameEngine(IUserInterface ui, Game game)
    {
        _ui = ui;
        _game = game;
    }
    
    public async Task RunAsync()
    {
        Dice[] dices = new[]
                {
                    new Dice(),
                    new Dice(),
                    new Dice(),
                    new Dice(),
                    new Dice()
                };
        
        while (!CheckGameEnd())
        {
            Player currentPlayer = _game.Players[_game.CurrentPlayerIndex];
            await PlayTurnAsync(currentPlayer, dices);
            NextPlayer();
        }
        await _ui.ShowWinnerAsync(_game.Players);
    }

    public async Task PlayTurnAsync(Player player, Dice[] dices)
    {
        foreach(var dice in dices) { dice.IsHeld = false; }
        
        await _ui.ShowScoreCardAsync(player);
        
        for (int rollNumber = 1; rollNumber <= maxRollsPerTurn; rollNumber++)
        {
            foreach (Dice dice in dices)
            {
                dice.Roll();
            }
            
            await _ui.ShowDiceAsync(dices);

            if (rollNumber < maxRollsPerTurn)
            {
                bool[] heldDices = await _ui.AskHoldAsync(dices);
                for (int i = 0; i < dices.Length; i++)
                {
                    dices[i].IsHeld = heldDices[i];
                }

                if (heldDices.All(h => h == true))
                {
                    break;
                }
            }
        }

        var availableRows = player.PlayerScoreCard.Rows
            .Where(row => row.Value == null)
            .Select(row => row.Key)
            .ToList();

        ScoreRow chosenRow = await _ui.AskScoreRowAsync(availableRows);

        int score = Scorer.Calculate(chosenRow, dices);
        
        player.PlayerScoreCard.MarkScore(chosenRow, score);
    }

    public void NextPlayer()
    {
        _game.CurrentPlayerIndex++;
        if (_game.CurrentPlayerIndex >= _game.Players.Count)
        {
            _game.CurrentPlayerIndex = 0;
            _game.Round++;
        }
    }

    public bool CheckGameEnd()
    {
        return _game.Players.All(p => p.PlayerScoreCard.Rows.All(row => row.Value != null));
    }
}