using System;

class SnakeAndLadderGame
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== UC1: Snake and Ladder Game ===\n");

        int[,] board = CreateBoard(10);        // Create 10x10 board
        DisplayBoard(board);                   // Show the board
        DefineSnakesAndLadders();              // Define snake and ladder positions
        StartGame();                           // Player starts at 0
    }

    // Method to create a 10x10 board in zig-zag format
    static int[,] CreateBoard(int size)
    {
        int[,] board = new int[size, size];
        int number = 1;

        for (int i = size - 1; i >= 0; i--)
        {
            if ((size - 1 - i) % 2 == 0) // even rows (left→right)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = number++;
                }
            }
            else // odd rows (right→left)
            {
                for (int j = size - 1; j >= 0; j--)
                {
                    board[i, j] = number++;
                }
            }
        }

        return board;
    }

    // Method to display the board neatly
    static void DisplayBoard(int[,] board)
    {
        Console.WriteLine("Snake and Ladder Board (Zig-Zag):\n");

        int size = board.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(board[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }

    // Method to define snakes and ladders
    static void DefineSnakesAndLadders()
    {
        // Each pair is { start, end }
        int[,] snakes = { { 38, 20 }, { 51, 10 }, { 91, 73 }, { 76, 54 }, { 97, 61 } };
        int[,] ladders = { { 6, 25 }, { 11, 40 }, { 60, 85 }, { 46, 90 }, { 17, 69 } };

        Console.WriteLine("\nDefined Snakes :");
        for (int i = 0; i < snakes.GetLength(0); i++)
        {
            Console.WriteLine("From " + snakes[i, 0] + " to " + snakes[i, 1]);
        }

        Console.WriteLine("\nDefined Ladders :");
        for (int i = 0; i < ladders.GetLength(0); i++)
        {
            Console.WriteLine("From " + ladders[i, 0] + " to " + ladders[i, 1]);
        }
    }

    // Method to start the game
    static void StartGame()
    {
        int playerPosition = 0;
        Console.WriteLine("\nPlayer starts at position: " + playerPosition);
    }
}
