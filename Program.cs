using System;

Main();

void Main()
{
    Console.WriteLine("Welcome to the Guessing Game!");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine();

    Console.Write("Please select a difficulty level - Easy, Medium, or Hard. Or if you really want to win - Cheater. ");
    string level = Console.ReadLine().ToLower();

    while (level != "easy" && level != "medium" && level != "hard" && level != "cheater")
    {
        Console.Write("Please select a difficulty level - Easy, Medium, or Hard. Or if you really want to win - Cheater. ");
        level = Console.ReadLine().ToLower();
    }

    int SetLevelNumber = 0;
    int count = 1;
    int secretNumber = new Random().Next(1, 100);
    Console.Write(secretNumber);

    if (level == "easy")
    {
        SetLevelNumber = 8;
        OtherLevels();
    }
    if (level == "medium")
    {
        SetLevelNumber = 6;
        OtherLevels();
    }

    if (level == "hard")
    {
        SetLevelNumber = 4;
        OtherLevels();
    }

    if (level == "cheater")
    {
        Cheater();
    }


    void OtherLevels()
    {
        GuessNumber();
        while (count < (SetLevelNumber + 1))
        {
            bool Valid = false;
            int answerInt;

            while (Valid == false)
            {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out answerInt))
                {
                    Valid = true;

                    if (answerInt != secretNumber && count == SetLevelNumber)
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

                        Console.Write($"You have {SetLevelNumber - count} guesses left. ");
                        GuessNumber();
                    }
                    else
                    {
                        Console.WriteLine("Success! You guessed the secret number.");
                        count = SetLevelNumber + 1;
                    }
                    count++;
                }
                else
                {
                    Console.Write("Please guess a whole number: ");
                }
            }
        }
    }

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
                    Console.Write("Please guess a whole number: ");
                }
            }
        }
    }

    void GuessNumber()
    {
        Console.Write("Guess a whole number: ");
    };
}


