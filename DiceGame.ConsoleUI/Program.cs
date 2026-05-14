// See https://aka.ms/new-console-template for more information

using DiceGame.ConsoleUI;
using DiceGame.GameEngine;
using DiceGame.Models;
using DiceGame.UI;

IUserInterface ui = new ConsoleUserInterface();

Player p1 = new Player("P1");
Player p2 = new Player("P2");
List<Player> players = new List<Player>();
players.Add(p1);
players.Add(p2);
Dice[] dices = new[]
{
    new Dice { Value = 1, IsHeld = true},
    new Dice { Value = 2},
    new Dice { Value = 3},
    new Dice { Value = 4},
    new Dice { Value = 5}
};

Game game = new Game(players);
var gameEngine = new GameEngine(ui, game);

await ui.ShowDiceAsync(dices);
