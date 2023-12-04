using System;

class CampoMinado
{
    static void Main()
    {
        int rows = 5;
        int cols = 5;
        int numBombs = 5;

        char[,] gameBoard = CreateBoard(rows, cols, numBombs);
        char[,] displayBoard = InitializeDisplayBoard(rows, cols);

        Console.WriteLine("Bem-vindo ao Campo Minado!");

        while (true)
        {
            PrintBoard(displayBoard);

            Console.Write("Escolha a linha (0 a {0}): ", rows - 1);
            int x = int.Parse(Console.ReadLine());

            Console.Write("Escolha a coluna (0 a {0}): ", cols - 1);
            int y = int.Parse(Console.ReadLine());

            if (x < 0 || x >= rows || y < 0 || y >= cols)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
                continue;
            }

            if (gameBoard[x, y] == '*')
            {
                Console.WriteLine("Você perdeu! Tente novamente.");
                break;
            }

            Reveal(gameBoard, displayBoard, x, y);

            if (CheckWin(displayBoard, numBombs))
            {
                Console.WriteLine("Parabéns! Você venceu!");
                break;
            }
        }
    }

    static char[,] CreateBoard(int rows, int cols, int bombs)
    {
        char[,] board = new char[rows, cols];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                board[i, j] = ' ';
            }
        }

        int bombsPlaced = 0;
        while (bombsPlaced < bombs)
        {
            int x = random.Next(rows);
            int y = random.Next(cols);

            if (board[x, y] != '*')
            {
                board[x, y] = '*';
                bombsPlaced++;
            }
        }

        return board;
    }

    static char[,] InitializeDisplayBoard(int rows, int cols)
    {
        char[,] displayBoard = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                displayBoard[i, j] = '-';
            }
        }

        return displayBoard;
    }

    static void PrintBoard(char[,] board)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Reveal(char[,] gameBoard, char[,] displayBoard, int x, int y)
    {
        if (displayBoard[x, y] != '-')
        {
            return;
        }

        int rows = gameBoard.GetLength(0);
        int cols = gameBoard.GetLength(1);

        if (gameBoard[x, y] == '*')
        {
            return;
        }

        int count = CountBombs(gameBoard, x, y);

        displayBoard[x, y] = count.ToString()[0];

        if (count == 0)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (newX >= 0 && newX < rows && newY >= 0 && newY < cols)
                    {
                        Reveal(gameBoard, displayBoard, newX, newY);
                    }
                }
            }
        }
    }

    static int CountBombs(char[,] board, int x, int y)
    {
        int count = 0;
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int newX = x + i;
                int newY = y + j;

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && board[newX, newY] == '*')
                {
                    count++;
                }
            }
        }

        return count;
    }

    static bool CheckWin(char[,] displayBoard, int numBombs)
    {
        int rows = displayBoard.GetLength(0);
        int cols = displayBoard.GetLength(1);

        int count = 0;
        foreach (char cell in displayBoard)
        {
            if (cell == '-')
            {
                count++;
            }
        }

        return count == numBombs;
    }
}