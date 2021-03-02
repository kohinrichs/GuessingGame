using System;

Main();

void Main()
{
    Console.WriteLine("Welcome to the Guessing Game!");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine();

    // Prompt user to select a level.
    Console.Write("Please select a difficulty level - Easy, Medium, or Hard. Or if you really want to win - Cheater. ");
    string level = Console.ReadLine().ToLower();

    // If input does not equal an accepted answer, prompts user again to select a level.
    while (level != "easy" && level != "medium" && level != "hard" && level != "cheater")
    {
        Console.Write("Please select a difficulty level - Easy, Medium, or Hard. Or if you really want to win - Cheater. ");
        level = Console.ReadLine().ToLower();
    }

    // Initial level set to 0
    int setLevelNumber = 0;

    // Initial count set to 0
    int guessCount = 0;

    // Genterates a random secret number between 1 - 100
    int secretNumber = new Random().Next(1, 100);

    // Prints secret number because we're cheating
    // Console.Write(secretNumber);

    // Sets number of guesses depending on the selected level and then calls the appropriate function for the level selected
    if (level == "easy")
    {
        setLevelNumber = 8;
        OtherLevels();
    }
    if (level == "medium")
    {
        setLevelNumber = 6;
        OtherLevels();
    }

    if (level == "hard")
    {
        setLevelNumber = 4;
        OtherLevels();
    }

    if (level == "cheater")
    {
        Cheater();
    }

    // If user has selected a level other than cheater - this function will be called since the number guesses is limited.
    // OtherLevels calls GuessNumber and then starts a while loop. The while loop will continue as long as the guessCount is less
    // than number of guesses for the chosen level. The second while loop on line 70 is checking to be sure the user is entering 
    // an int. If the TryParse can change the entry to an int, it'll continue along that if statement. If the entery can't be changed
    // into an int, it'll display the else portion and prompt the user for a proper entery. With a valid entery, the user will
    // loop through the additional if/else statements depending on the number of guesses they have left. If the user guesses correctly,
    // It'll display a sucess message and exit from the program. (Could rewrite this into 1 function with
    // an if/else.)

    void OtherLevels()
    {
        GuessNumber();

        while (guessCount < setLevelNumber)
        {
            bool Valid = false;

            int answerInt;

            while (Valid == false)
            {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out answerInt))
                {
                    Valid = true;

                    if (answerInt != secretNumber && (guessCount + 1) == setLevelNumber)
                    {
                        Console.WriteLine("Sorry. You're out of guesses. Better luck next time!");
                    }
                    else if (answerInt != secretNumber)
                    {
                        Console.Write("Dang. That's not it. ");
                        if (answerInt > secretNumber)
                        {
                            Console.Write("Your guess is too high. ");
                        }
                        else
                        {
                            Console.Write("Too low! ");
                        }

                        Console.WriteLine($"You have {setLevelNumber - (guessCount + 1)} guesses left. ");
                        GuessNumber();
                    }
                    else
                    {
                        Console.WriteLine("Success! You guessed the secret number.");
                        return;
                    }
                    guessCount++;
                }
                else
                {
                    Console.Write("Please guess a whole number beteen 1 - 100: ");
                }
            }
        }
    }

    // The cheater function will be called if there is no guess limit. The while loop will keep looping until the user guesses the
    // secret number and then the loop will break. 

    void Cheater()
    {
        GuessNumber();

        while (true)
        {
            bool Valid = false;
            int answerInt;

            while (Valid == false)
            {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out answerInt))
                {
                    Valid = true;

                    if (answerInt != secretNumber)
                    {
                        Console.Write("Dang. That's not it. ");
                        if (answerInt > secretNumber)
                        {
                            Console.Write("Your guess is too high. ");
                        }
                        else
                        {
                            Console.Write("Too low! ");
                        }

                        GuessNumber();
                    }
                    else
                    {
                        Console.WriteLine("Success! You guessed the secret number.");
                        return;
                    }
                }
                else
                {
                    Console.Write("Please guess a whole number between 1 - 100: ");
                }
            }
        }
    }

    // This function is used to prompt the user to guess a number.

    void GuessNumber()
    {
        Console.Write("Guess a whole number between 1 - 100: ");
    };
}


