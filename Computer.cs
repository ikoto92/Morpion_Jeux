using System;
using System.Collections.Generic;

namespace ConsoleAppTutoTicTacToe
{
    public class Computer
    {
        private Board board;

        public Computer(Board board)
        {
            this.board = board;
        }

        public void TakeTurn()
        {
            var emptyBox = new List<(int X, int Y)>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.GetGrid()[i, j] == ' ')
                    {
                        emptyBox.Add((i, j));
                    }
                }
            }
            var (X, Y) = emptyBox[new Random().Next(0, emptyBox.Count)];
            board.SetCell(X, Y, 'O');
        }
    }
}
