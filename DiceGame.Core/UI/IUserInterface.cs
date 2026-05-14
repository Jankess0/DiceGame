using DiceGame.Models;

namespace DiceGame.UI;

public interface IUserInterface
{
    Task ShowDiceAsync(Dice[] dices);
    Task<bool[]> AskHoldAsync(Dice[] currentDices);
    Task<ScoreRow> AskScoreRowAsync(List<ScoreRow> availableRows);
    Task ShowScore(List<Player> players);
    Task ShowWinnerAsync(List<Player> players);
    Task ShowScoreCardAsync(Player player);
    Task<int> AskPlayerCountAsync();
    Task<string> AskPlayerNameAsync(int playerIndex);
}