using System;

class SnakeAndLadderGame
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== UC2: Snake and Ladder Game ===\n");

        int[,] board = CreateBoard(10);    // Create 10x10 board
        DisplayBoard(board);               // Show the board
        DefineSnakesAndLadders();          // Define snake and ladder positions
        StartGame();                       // Player rolls the die
    }

    // Create 10x10 board in zig-zag format
    static int[,] CreateBoard(int size)
    {
        int[,] board = new int[size, size];
        int number = 1;

        for (int i = size - 1; i >= 0; i--)
        {
            if ((size - 1 - i) % 2 == 0)
            {
                for (int j = 0; j < size; j++)
                    board[i, j] = number++;
            }
            else
            {
                for (int j = size - 1; j >= 0; j--)
                    board[i, j] = number++;
            }
        }

        return board;
    }

    // Display the board neatly
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

    // Define snakes and ladders
    static void DefineSnakesAndLadders()
    {
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

    // UC2: Player rolls die (1–6) using Random
    static void StartGame()
    {
        Random random = new Random();
        int playerPosition = 0;

        Console.WriteLine("\nPlayer starts at position: " + playerPosition);

        // Roll the die once
        int dieRoll = random.Next(1, 7); // generates random number between 1 and 6
        Console.WriteLine("\nPlayer rolled the die: " + dieRoll);
    }
}
