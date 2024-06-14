using MineSweeper.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MineSweeper.Interfaces
{
    public interface IMineSweeperBoard
    {
        GameStatus Status { get; set; }
        string[,] Squares { get; set; }
        CellStatus[,] SquareStatus { get; set; }
        int Lives { get; set; }
        int Moves { get; set; }
        string CurrentPosition { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
        int CurrentXPosition { get; set; }
        int CurrentYPosition { get; set; }
        string MakeMove(string move);
    }
}
