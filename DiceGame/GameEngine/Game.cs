using DiceGame.Models;

namespace DiceGame.GameEngine;

public class Game
{
    public List<Player> Players { get; set; }
    public int Round { get; set; }
    public int CurrentPlayerIndex { get; set; }

    public Game(List<Player> players)
    {
        Players = players;
        Round = 1;
        CurrentPlayerIndex = 0;
    }
}