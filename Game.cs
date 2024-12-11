using System;

namespace ConsoleAppTutoTicTacToe
{
    public class Game
    {
        public bool QuitGame { get; private set; }
        public bool PlayerTurn { get; private set; }
        private Board board;
        private Player player;
        private Computer computer;

        public Game()
        {
            QuitGame = false;
            PlayerTurn = true;
            board = new Board();
            player = new Player(board);
            computer = new Computer(board);
        }

        public void Start()
        {
            while (!QuitGame)
            {
                board.Reset();
                while (!QuitGame)
                {
                    if (PlayerTurn)
                    {
                        player.TakeTurn();
                        if (board.CheckLines('X'))
                        {
                            EndGame("Tu es le vainqueur!");
                            break;
                        }
                    }
                    else
                    {
                        computer.TakeTurn();
                        if (board.CheckLines('O'))
                        {
                            EndGame("Tu as perdu !");
                            break;
                        }
                    }
                    PlayerTurn = !PlayerTurn;
                    if (board.CheckDraw())
                    {
                        EndGame("Pas de vainqueur !");
                        break;
                    }
                }
                if (!QuitGame)
                {
                    Console.WriteLine("Appuyer sur [Escape] pour quitter, [Enter] pour rejouer.");
                    GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            QuitGame = true;
                            Console.Clear();
                            break;
                        default:
                            goto GetKey;
                    }
                }
            }
        }

        private void EndGame(string msg)
        {
            Console.Clear();
            board.Render();
            Console.WriteLine(msg);
        }
    }
}
