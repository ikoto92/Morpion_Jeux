using System;

namespace ConsoleAppTutoTicTacToe
{
    public class Player
    {
        private Board board;

        public Player(Board board)
        {
            this.board = board;
        }

        public void TakeTurn()
        {
            var (row, column) = (0, 0);
            bool moved = false;
            while (!moved)
            {
                Console.Clear();
                board.Render();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide puis appuyer sur [Enter].");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.RightArrow:
                        column = (column >= 2) ? 0 : column + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        column = (column <= 0) ? 2 : column - 1;
                        break;
                    case ConsoleKey.UpArrow:
                        row = (row <= 0) ? 2 : row - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        row = (row >= 2) ? 0 : row + 1;
                        break;
                    case ConsoleKey.Enter:
                        if (board.GetGrid()[row, column] == ' ')
                        {
                            board.SetCell(row, column, 'X');
                            moved = true;
                        }
                        break;
                }
            }
        }
    }
}
