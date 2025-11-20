using System;

class SnakeAndLadderGame
{
    // Single player state
    static int playerPosition = 0;
    static int diceRollCount = 0;

    // Two player state for UC7
    static int player1Position = 0;
    static int player2Position = 0;
    static int player1RollCount = 0;
    static int player2RollCount = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Snake and Ladder Game\n");

        
        // StartGame();
        // int dieValue = rollDie();
        // CheckOption(dieValue);
        // PlayTillWin();
        // EnsureExactWin();
        // Console.WriteLine($"Total dice rolls: {diceRollCount}");

        // Run the new two-player mode with ladder extra turns and winner report
        TwoPlayerGame();
    }

    // UC1: Start single player game
    static void StartGame()
    {
        playerPosition = 0;
        diceRollCount = 0;
        Console.WriteLine("Player starts at position: " + playerPosition);
    }

    // UC2: Roll die and count for single player
    static int rollDie()
    {
        Random random = new Random();
        int dieValue = random.Next(1, 7);
        diceRollCount++;
        Console.WriteLine($"Player rolled the die ({diceRollCount} times) and got: {dieValue}");
        return dieValue;
    }

    // UC3: Check option and update single player position
    static void CheckOption(int dieValue)
    {
        Random random = new Random();
        int option = random.Next(0, 3);

        if (option == 0)
            Console.WriteLine("Option: No Play → Player stays in the same position.");
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

    // UC4: Repeat turns till single player wins
    static void PlayTillWin()
    {
        while (playerPosition < 100)
        {
            int dieValue = rollDie();
            CheckOption(dieValue);
        }
        Console.WriteLine("Player reached the winning position 100! Game over.");
    }

    // UC5: Ensure single player wins by exact 100
    static void EnsureExactWin()
    {
        while (playerPosition != 100)
        {
            int dieValue = rollDie();

            if (playerPosition + dieValue == 100)
            {
                playerPosition += dieValue;
                Console.WriteLine($"Player moved exactly to position: {playerPosition}");
            }
            else
            {
                Console.WriteLine($"Player rolled {dieValue} but cannot move without exceeding 100. Waiting for exact roll.");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Player reached the exact winning position 100! Game over.");
    }

    // UC7: Two player game with ladder re-roll
    static void TwoPlayerGame()
    {
        player1Position = 0;
        player2Position = 0;
        player1RollCount = 0;
        player2RollCount = 0;
        bool isPlayer1Turn = true;

        Random random = new Random();

        while (player1Position < 100 && player2Position < 100)
        {
            int dieValue = random.Next(1, 7);
            int option = random.Next(0, 3);

            if (isPlayer1Turn)
            {
                player1RollCount++;
                Console.WriteLine($"Player 1 rolled the die ({player1RollCount} times) and got: {dieValue}");

                if (option == 0)
                    Console.WriteLine("Option: No Play → Player 1 stays in the same position.");
                else if (option == 1)
                {
                    Console.WriteLine("Option: Ladder → Player 1 moves ahead by " + dieValue);
                    player1Position += dieValue;
                    if (player1Position > 100)
                    {
                        Console.WriteLine("Position exceeded 100, Player 1 stays in previous position.");
                        player1Position -= dieValue;
                    }
                    Console.WriteLine($"Player 1 position: {player1Position}");
                    if (player1Position == 100) break;
                    Console.WriteLine("Player 1 gets another turn.\n");
                    continue; // Player 1 plays again on ladder
                }
                else
                {
                    Console.WriteLine("Option: Snake → Player 1 moves behind by " + dieValue);
                    player1Position -= dieValue;
                    if (player1Position < 0)
                    {
                        Console.WriteLine("Position below 0. Player 1 restarting from 0.");
                        player1Position = 0;
                    }
                }
                Console.WriteLine($"Player 1 position: {player1Position}\n");
                isPlayer1Turn = false;
            }
            else
            {
                player2RollCount++;
                Console.WriteLine($"Player 2 rolled the die ({player2RollCount} times) and got: {dieValue}");

                if (option == 0)
                    Console.WriteLine("Option: No Play → Player 2 stays in the same position.");
                else if (option == 1)
                {
                    Console.WriteLine("Option: Ladder → Player 2 moves ahead by " + dieValue);
                    player2Position += dieValue;
                    if (player2Position > 100)
                    {
                        Console.WriteLine("Position exceeded 100, Player 2 stays in previous position.");
                        player2Position -= dieValue;
                    }
                    Console.WriteLine($"Player 2 position: {player2Position}");
                    if (player2Position == 100) break;
                    Console.WriteLine("Player 2 gets another turn.\n");
                    continue; // Player 2 plays again on ladder
                }
                else
                {
                    Console.WriteLine("Option: Snake → Player 2 moves behind by " + dieValue);
                    player2Position -= dieValue;
                    if (player2Position < 0)
                    {
                        Console.WriteLine("Position below 0. Player 2 restarting from 0.");
                        player2Position = 0;
                    }
                }
                Console.WriteLine($"Player 2 position: {player2Position}\n");
                isPlayer1Turn = true;
            }
        }

        if (player1Position == 100)
        {
            Console.WriteLine($"Player 1 won the game in {player1RollCount} dice rolls!");
        }
        else if (player2Position == 100)
        {
            Console.WriteLine($"Player 2 won the game in {player2RollCount} dice rolls!");
        }
    }
}
