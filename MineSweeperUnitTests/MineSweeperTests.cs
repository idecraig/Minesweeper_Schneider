using MineSweeper.Interfaces;
using MineSweeper.Models;

namespace MineSweeperUnitTests
{
    public class Tests
    {
        [Test]
        public void MineSweeperBoardGoodContruction()
        {
            IMineSweeperBoard board = new MineSweeper.Models.MineSweeperBoard(3, 0, 8, 8, 0, 3);

            Assert.IsTrue(board != null);
        }

        [Test]
        public void MineSweeperBoardBadContruction()
        {
            Assert.That(() => new MineSweeper.Models.MineSweeperBoard(3, 0, 88, 88, -1, 3),
                Throws.Exception);

            Assert.That(() => new MineSweeper.Models.MineSweeperBoard(3, 0, 88, 88, 3, -3),
                Throws.Exception);
        }

        // Todo - add more constructor tests

        [Test]
        public void MoveRightOneSpace()
        {
            IMineSweeperBoard board = new MineSweeper.Models.MineSweeperBoard(3, 0, 8, 8, 0, 3);
            board.CurrentXPosition = 0;
            var p1 = board.CurrentXPosition;

            var result = board.MakeMove("R");
            var p2 = board.CurrentXPosition;
            var p3 = p2 - p1;

            Assert.IsTrue(result == string.Empty);
            Assert.AreNotEqual(p1, p2);
            Assert.IsTrue(p3 == 1);
        }

        // Todo - add more up and down space checking ...

        [Test]
        public void BoomTest()
        {
            IMineSweeperBoard board = new MineSweeper.Models.MineSweeperBoard(3, 99, 3, 3, 0, 1);
            board.CurrentXPosition = 0;
            var p1 = board.CurrentXPosition;
            var result = board.MakeMove("R");

            Assert.IsTrue(result.Trim() == "******* BOOM *******");
            Assert.AreNotEqual(p1, board.CurrentXPosition);
            Assert.IsTrue((board.CurrentXPosition - p1) == 1);
            Assert.IsTrue(board.Lives == 2);
        }

        [Test]
        public void MoveLeftOneSpace()
        {
            IMineSweeperBoard board = new MineSweeper.Models.MineSweeperBoard();
            board.CurrentXPosition = 0;
            var p1 = board.CurrentXPosition;
            var result = board.MakeMove("L");

            Assert.IsTrue(result == "Invalid move - cannot move left!");
            Assert.AreEqual(p1, board.CurrentXPosition);
            Assert.IsTrue((board.CurrentXPosition - p1) == 0);
        }

        [Test]
        public void MoveToWinningSpace()
        {
            IMineSweeperBoard board = new MineSweeper.Models.MineSweeperBoard();
            board.CurrentXPosition = 7;
            var p1 = board.CurrentXPosition;
            var result = board.MakeMove("R");

            Assert.IsTrue(result == "You win!!!!");
            Assert.IsTrue((board.CurrentXPosition - p1) == 0);
        }
    }
}