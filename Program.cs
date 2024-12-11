using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //Variable
    public static bool quitGame = false;
    public static bool playerTurn = true;
    public static char[,] board;

    //Fonction 
    static void Main(string[] args)
    {
        //bouble de jeu / Game loop
        while (!quitGame)
        {
            board = new char[3, 3]
            {
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
            };
            while (!quitGame)
            {
                if (playerTurn)
                {
                    PlayerTurn();
                }
                else
                {
                    ComputerTurn();
                }

                playerTurn = !playerTurn;
            }
            if (!quitGame)
            {
                Console.WriteLine("Appuyer sur [Escape] pour quitter");
                Getkey:

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:

                        quitGame = true;
                        Console.Clear();
                        break;
                }
            }
        }
    }
    public static void PlayerTurn()
    {
        var (row, column) = (0, 0);
        bool moved = false;

        while (!quitGame && !moved)
        {
            Console.Clear();
            RenderBoard();

            Console.WriteLine();
            Console.WriteLine("Choisir une case valide puis appuyer sur [Entre].");

            Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:

                    quitGame = true;
                    Console.Clear();
                    break;

                case ConsoleKey.RightArrow:

                    if (column >= 2)
                    {
                        column = 0;
                    }
                    else
                    {
                        column = column + 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:

                    if (column <= 0)
                    {
                        column = 2;
                    }
                    else
                    {
                        column = column - 1;
                    }
                    break;

                case ConsoleKey.UpArrow:

                    if (row <= 0)
                    {
                        row = 2;
                    }
                    else
                    {
                        row = row - 1;
                    }
                    break;

                case ConsoleKey.DownArrow:

                    if (row >= 2)
                    {
                        row = 0;
                    }
                    else
                    {
                        row = row + 1;
                    }
                    break;


                case ConsoleKey.Enter:
                    if (board[row, column] is ' ')
                    {
                        board[row, column] = 'x';
                        moved = true;
                    }
                    break;
            }

        }

    }

    public static void ComputerTurn()
    {

    }

    public static void RenderBoard()
    {
        Console.WriteLine();
        Console.WriteLine($" {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}");
        Console.WriteLine("    |     |");
        Console.WriteLine("----+-----+----");
        Console.WriteLine("    |     |");
        Console.WriteLine($" {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}");
        Console.WriteLine("    |     |");
        Console.WriteLine("----+-----+----");
        Console.WriteLine("    |     |");
        Console.WriteLine($" {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}");
    }
}

