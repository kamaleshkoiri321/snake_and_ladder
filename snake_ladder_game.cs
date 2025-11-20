using System;

class SnakeAndLadderGame
{
    static int playerPosition = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Snake and Ladder Game\n");

        StartGame();      //  Start the game

        int dieValue = rollDie();  //  Roll the die
        CheckOption(dieValue);     // Check options for die value

        PlayTillWin();    //  Repeat till winning position 100 with all logic inside

        
    }

    //  Method to start the game
    static void StartGame()
    {
        playerPosition = 0;
        Console.WriteLine("Player starts at position: " + playerPosition);
    }

    //  Method to roll a die
    static int rollDie()
    {
        Random random = new Random();
        int dieValue = random.Next(1, 7);
        Console.WriteLine("Player rolled the die and got: " + dieValue);
        return dieValue;
    }

    //  Method to Check Option and update position accordingly
    static void CheckOption(int dieValue)
    {
        Random random = new Random();
        int option = random.Next(0, 3);

        if (option == 0)
        {
            Console.WriteLine("Option: No Play → Player stays in the same position.");
        }
        else if (option == 1)
        {
            Console.WriteLine("Option: Ladder → Player moves ahead by " + dieValue);
            playerPosition += dieValue;

            if (playerPosition > 100)
            {
                Console.WriteLine("Position exceeded 100, stay in previous position.");
                playerPosition -= dieValue;
            }
        }
        else
        {
            Console.WriteLine("Option: Snake → Player moves behind by " + dieValue);
            playerPosition -= dieValue;
            if (playerPosition < 0)
            {
                Console.WriteLine("Position below 0. Restarting from 0.");
                playerPosition = 0;
            }
        }
        Console.WriteLine("Current Player position: " + playerPosition + "\n");
    }

    //Method to repeat turns till player reaches 100
    static void PlayTillWin()
    {
        while (playerPosition < 100)
        {
            int dieValue = rollDie();
            CheckOption(dieValue);
        }

        Console.WriteLine("Player reached the winning position 100! Game over.");
    }
}
