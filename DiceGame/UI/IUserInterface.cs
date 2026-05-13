using DiceGame.Models;

namespace DiceGame.UI;

public interface IUserInterface
{
    void ShowDice(Dice[] dices);
    bool[] AskHold();
    ScoreRow AskScoreRow(List<ScoreRow> availableRows);
    void ShowScore(List<Player> players);
    void ShowScoreOptions();
    void ShowTurnStart(string name);
}