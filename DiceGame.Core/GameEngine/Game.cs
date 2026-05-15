using DiceGame.Models;

namespace DiceGame.GameEngine;

public class Game
{
    public List<Player> Players { get; }
    public int Round { get; set; }
    private int _currentPlayerIndex;

    public Game(List<Player> players)
    {
        Players = players;
        Round = 1;
        _currentPlayerIndex = 0;
    }
    
    public Player CurrentPlayer => Players[_currentPlayerIndex];
    
    public bool IsGameOver() => Players.All(p => p.PlayerScoreCard.Rows.All(row => row.Value != null));
    
    public void NextPlayer()
    {
        _currentPlayerIndex++;
        if (_currentPlayerIndex >= Players.Count)
        {
            _currentPlayerIndex = 0;
            Round++;
        }
    }
}