using System;

class SnakeAndLadderGame
{
    static void Main(string[] args)
    {
        Console.WriteLine("Snake and Ladder Game\n");
        StartGame();
        rollDie();
    }

    // Method to start the game
    static void StartGame()
    {
        int playerPosition = 0;
        Console.WriteLine("\nPlayer starts at position: " + playerPosition);
    }

    // Method to roll a die
    static int rollDie()
    {
        Random random = new Random();
        int dieValue = random.Next(1, 7);
        Console.WriteLine("Player rolled the die and got: " + dieValue);
        return dieValue;
    }
}
