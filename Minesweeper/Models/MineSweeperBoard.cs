using MineSweeper.Enums;
using MineSweeper.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MineSweeper.Models
{
    public partial class MineSweeperBoard : ObservableObject, IMineSweeperBoard
    {
        [ObservableProperty] private GameStatus status;
        [ObservableProperty] private string[,] squares;
        [ObservableProperty] private CellStatus[,] squareStatus;
        [ObservableProperty] private int moves;
        [ObservableProperty] private int lives;
        [ObservableProperty] private int mines;
        [ObservableProperty] private string currentPosition;
        [ObservableProperty] private int rows;
        [ObservableProperty] private int columns;
        [ObservableProperty] private int currentXPosition;
        [ObservableProperty] private int currentYPosition;
        private int MaxRows;
        private int MaxColumns;

        public MineSweeperBoard(int numberOfLives = 3, int numberOfMines = 27, int rows = 8, int columns = 8, int startXPosition = 0, int startYPosition = 3)
        {
            try
            {
                // Validate row , columns etc
                if (columns <= 0) throw new ArgumentOutOfRangeException(nameof(columns));
                if (rows <= 0) throw new ArgumentOutOfRangeException(nameof(rows));
                if (startXPosition > rows) throw new ArgumentOutOfRangeException(nameof(startXPosition));
                if (startYPosition > columns) throw new ArgumentOutOfRangeException(nameof(startYPosition));
                if (startXPosition < 0) throw new ArgumentOutOfRangeException(nameof(startXPosition));
                if (startYPosition < 0) throw new ArgumentOutOfRangeException(nameof(startYPosition));

                this.Squares = new string[columns, rows];
                this.SquareStatus = new CellStatus[columns, rows];

                // Initialise board
                for (int x = 0; x < columns; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                        this.Squares[x, y] = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(y, 1)) + (x + 1).ToString();
                        this.SquareStatus[x, y] = CellStatus.Empty;
                    }
                }

                // Set mines
                for (int i = 0; i < numberOfMines; i++)
                {
                    int xPos = new Random().Next(0, rows);
                    int yPos = new Random().Next(0, columns);
                    this.SquareStatus[xPos, yPos] = CellStatus.Mined;
                }

                this.MaxColumns = columns;
                this.MaxRows = rows;
                this.CurrentXPosition = startXPosition;
                this.CurrentYPosition = startYPosition;
                this.Lives = numberOfLives;
                this.SquareStatus[this.CurrentXPosition, this.CurrentYPosition] = CellStatus.MovedTo;
                this.CurrentPosition = this.Squares[this.CurrentXPosition, this.CurrentYPosition];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string MakeMove(string move)
        {
            try
            {
                int newXPos = this.CurrentXPosition;
                int newYPos = this.CurrentYPosition;

                switch (move.ToUpper())
                {
                    case "U": newYPos--; break;
                    case "D": newYPos++; break;
                    case "L": newXPos--; break;
                    case "R": newXPos++; break;

                    case "Q":
                        this.Status = GameStatus.Lost;
                        return string.Empty;

                    default: return "Invalid command!";
                }

                // Validate move
                if (newXPos < 0) { return "Invalid move - cannot move left!"; }
                if (newYPos < 0) { return "Invalid move - cannot move up!"; }
                if (newYPos > this.MaxRows) { return "Invalid move - cannot move down!"; }
                if (newXPos > this.MaxColumns - 1)
                {
                    this.Status = GameStatus.Won;
                    return "You win!!!!";
                }

                this.Moves++;

                this.CurrentXPosition = newXPos;
                this.CurrentYPosition = newYPos;

                if (this.SquareStatus[this.CurrentXPosition, this.CurrentYPosition] == CellStatus.Mined)
                {
                    this.Lives--;

                    if (this.Lives == 0)
                    {
                        this.Status = GameStatus.Lost;
                        return "******* You lost game *******";
                    }
                    else
                        return "******* BOOM ******* ";
                }

                this.SquareStatus[this.CurrentXPosition, this.CurrentYPosition] = CellStatus.MovedTo;
                this.CurrentPosition = this.Squares[this.CurrentXPosition, this.CurrentYPosition];

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
