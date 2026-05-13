using DiceGame.Logic;
using DiceGame.Models;
using DiceGame.UI;

namespace DiceGame.GameEngine;

public class GameEngine
{
    private readonly IUserInterface _ui;
    private readonly Game _game;

    public GameEngine(IUserInterface ui, Game game)
    {
        _ui = ui;
        _game = game;
    }

    public void PlayTurn(Player player)
    {
        _ui.ShowTurnStart(player.Name);
        
        Dice[] dices = new[]
        {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice()
        };

        for (int rollNumber = 1; rollNumber <= 3; rollNumber++)
        {
            foreach (Dice dice in dices)
            {
                dice.Roll();
            }
            
            _ui.ShowDice(dices);

            if (rollNumber < 3)
            {
                bool[] heldDices = _ui.AskHold();
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

        ScoreRow chosenRow = _ui.AskScoreRow(availableRows);

        int score = Scorer.Calculate(chosenRow, dices);
        
        player.PlayerScoreCard.MarkScore(chosenRow, score);
    }

    public void NextPlayer()
    {
        throw new NotImplementedException();
    }

    public bool CheckGameEnd()
    {
        throw new NotImplementedException();
    }
}