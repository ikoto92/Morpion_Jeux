using System;

namespace ConsoleAppTutoTicTacToe
{
    public class Board
    {
        private char[,] grid;

        public Board()
        {
            grid = new char[3, 3];
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public void Render()
        {
            Console.WriteLine();
            Console.WriteLine($" {grid[0, 0]}  |  {grid[0, 1]}  |  {grid[0, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grid[1, 0]}  |  {grid[1, 1]}  |  {grid[1, 2]}");
            Console.WriteLine("    |     |");
            Console.WriteLine("----+-----+----");
            Console.WriteLine("    |     |");
            Console.WriteLine($" {grid[2, 0]}  |  {grid[2, 1]}  |  {grid[2, 2]}");
        }

        public bool CheckLines(char c) =>
            grid[0, 0] == c && grid[1, 0] == c && grid[2, 0] == c ||
            grid[0, 1] == c && grid[1, 1] == c && grid[2, 1] == c ||
            grid[0, 2] == c && grid[1, 2] == c && grid[2, 2] == c ||
            grid[0, 0] == c && grid[0, 1] == c && grid[0, 2] == c ||
            grid[1, 0] == c && grid[1, 1] == c && grid[1, 2] == c ||
            grid[2, 0] == c && grid[2, 1] == c && grid[2, 2] == c ||
            grid[0, 0] == c && grid[1, 1] == c && grid[2, 2] == c ||
            grid[2, 0] == c && grid[1, 1] == c && grid[0, 2] == c;

        public bool CheckDraw() =>
            grid[0, 0] != ' ' && grid[1, 0] != ' ' && grid[2, 0] != ' ' &&
            grid[0, 1] != ' ' && grid[1, 1] != ' ' && grid[2, 1] != ' ' &&
            grid[0, 2] != ' ' && grid[1, 2] != ' ' && grid[2, 2] != ' ';

        public char[,] GetGrid()
        {
            return grid;
        }

        public void SetCell(int row, int column, char value)
        {
            grid[row, column] = value;
        }
    }
}
