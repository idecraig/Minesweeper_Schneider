using MineSweeper.Models;

namespace MineSweeper.Interfaces
{
    public interface IMineSweeperViewModel
    {
        MineSweeperBoard MineSweeperBoard { get; set; }
        string MakeMove(string move);
    }
}
