using CommunityToolkit.Mvvm.ComponentModel;
using MineSweeper.Interfaces;
using MineSweeper.Models;

namespace MineSweeper.ViewModels
{
    public partial class MineSweeperViewModel :  ObservableObject, IMineSweeperViewModel
    {
        public MineSweeperViewModel()
        {
            this.MineSweeperBoard = new MineSweeperBoard();
        }

        #region public properties
        [ObservableProperty] private MineSweeperBoard mineSweeperBoard;

        #endregion

        #region public methods

        public string MakeMove(string move)
        {
            return MineSweeperBoard.MakeMove(move);
        }
        #endregion
    }
}
