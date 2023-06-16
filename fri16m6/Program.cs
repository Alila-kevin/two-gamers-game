using System;

class Program
{
    static char[,] gameBoard = new char[3, 3];
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        InitializeGameBoard();
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            DrawGameBoard();

            Console.WriteLine("Player {0}, enter your move (row, column):", currentPlayer);
            string[] input = Console.ReadLine().Split(',');

            int row, col;
            if (input.Length == 2 && int.TryParse(input[0], out row) && int.TryParse(input[1], out col))
            {
                if (IsValidMove(row, col))
                {
                    MakeMove(row, col);

                    if (CheckWin())
                    {
                        gameOver = true;
                        Console.Clear();
                        DrawGameBoard();
                        Console.WriteLine("Player {0} wins! email: alilakevin4@gmail.com for you prize", currentPlayer);
                    }
                    else if (CheckDraw())
                    {
                        gameOver = true;
                        Console.Clear();
                        DrawGameBoard();
                        Console.WriteLine("It's a draw! thanks ");
                    }
                    else
                    {
                        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter row and column numbers separated by a comma.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void InitializeGameBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gameBoard[i, j] = ' ';
            }
        }
    }

    static void DrawGameBoard()
    {
        Console.WriteLine("   0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("{0}  ", i);
            for (int j = 0; j < 3; j++)
            {
                Console.Write(gameBoard[i, j]);
                if (j < 2)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (i < 2)
            {
                Console.WriteLine("   -+-+-");
            }
        }
        Console.WriteLine();
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && gameBoard[row, col] == ' ';
    }

    static void MakeMove(int row, int col)
    {
        gameBoard[row, col] = currentPlayer;
    }

    static bool CheckWin()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (gameBoard[i, 0] != ' ' && gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
            {
                return true;
            }
        }

        // Check columns
        for (int j = 0; j < 3; j++)
        {
            if (gameBoard[0, j] != ' ' && gameBoard[0, j] == gameBoard[1, j] && gameBoard[1, j] == gameBoard[2, j])
            {
                return true;
            }
        }

        // Check diagonals
        if (gameBoard[0, 0] != ' ' && gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
        {
            return true;
        }
        if (gameBoard[2, 0] != ' ' && gameBoard[2, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[0, 2])
        {
            return true;
        }

        return false;
    }

    static bool CheckDraw()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (gameBoard[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
