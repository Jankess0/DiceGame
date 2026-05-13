using DiceGame.Models;

namespace DiceGame.GameEngine;

public class Game
{
    public List<Player> Players { get; set; }
    public int Round { get; set; }

    public Game(List<Player> players)
    {
        Players = players;
        Round = 1;
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}