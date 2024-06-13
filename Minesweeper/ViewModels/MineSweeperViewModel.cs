using MineSweeper.Interfaces;
using MineSweeper.Models;

namespace MineSweeper.ViewModels
{
    public class MineSweeperViewModel : IMineSweeperViewModel
    {
        public MineSweeperViewModel()
        {
            this.MineSweeperBoard = new MineSweeperBoard();
        }

        #region public properties
        public IMineSweeperBoard MineSweeperBoard { get; set; }
        #endregion

        #region public methods

        public string MakeMove(string move)
        {
            return MineSweeperBoard.MakeMove(move);
        }
        #endregion
    }
}
