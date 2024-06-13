namespace MineSweeper.Interfaces
{
    public interface IMineSweeperViewModel
    {
        IMineSweeperBoard MineSweeperBoard { get; set; }
        string MakeMove(string move);
    }
}
