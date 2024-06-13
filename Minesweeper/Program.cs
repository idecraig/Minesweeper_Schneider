
using MineSweeper.Interfaces;
using MineSweeper.ViewModels;
using MineSweeper.Models;

Console.WriteLine("Welcome to MineSweeper!");
Console.WriteLine(" ");
Console.WriteLine("Commands:");
Console.WriteLine("L=Move left");
Console.WriteLine("R=Move right");
Console.WriteLine("U=Move up");
Console.WriteLine("D=Move down");
Console.WriteLine("Q=Quit");
Console.WriteLine(" ");

var command = string.Empty;

var MineSweeperViewModel = new MineSweeperViewModel();

while (MineSweeperViewModel.MineSweeperBoard.Status == MineSweeper.Enums.GameStatus.InProgress)
{
    Console.WriteLine("Current position : " + MineSweeperViewModel.MineSweeperBoard.CurrentPosition);
    Console.WriteLine("Number of moves made : " + MineSweeperViewModel.MineSweeperBoard.Moves);
    Console.WriteLine("Number of lives remaining : " + MineSweeperViewModel.MineSweeperBoard.Lives);
    Console.WriteLine(" ");
    Console.WriteLine("Enter a command (l,r,u,d,q) : ");
    command = Console.ReadLine().ToUpper();
    var result = MineSweeperViewModel.MineSweeperBoard.MakeMove(command);
    Console.WriteLine(result);

    if (MineSweeperViewModel.MineSweeperBoard.Status == MineSweeper.Enums.GameStatus.Lost )
    {
        Console.WriteLine(" ");
        Console.WriteLine("Bad luck");
    }

    if (MineSweeperViewModel.MineSweeperBoard.Status == MineSweeper.Enums.GameStatus.Won)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Well done");
    }
}

Console.WriteLine(" ");
Console.WriteLine("Thanks fpr playing minesweeper");


