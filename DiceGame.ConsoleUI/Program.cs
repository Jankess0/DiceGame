using DiceGame.ConsoleUI;
using DiceGame.GameEngine;
using DiceGame.Models;
using DiceGame.UI;

IUserInterface ui = new ConsoleUserInterface();

int playerCount = await ui.AskPlayerCountAsync();
List<Player> players = new();

for (int i = 0; i < playerCount; i++)
{
    string name = await ui.AskPlayerNameAsync(i);
    players.Add(new Player(name));
}

Game game = new Game(players);
var gameEngine = new GameEngine(ui, game);

await gameEngine.RunAsync();

Console.WriteLine("\nEnter any key to exit...");
Console.ReadKey();