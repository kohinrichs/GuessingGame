using System;

Main();

void Main()
{
    Console.WriteLine("Welcome to the Guessing Game!");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine();

    guessNumber();

    int count = 1;

    while (count < 5)
    {
        bool Valid = false;
        int answerInt;

        while (Valid == false)
        {
            string answer = Console.ReadLine();
            if (int.TryParse(answer, out answerInt))
            {
                Valid = true;
                int secretNumber = 42;

                if (answerInt != secretNumber && count == 4)
                {
                    Console.WriteLine("Sorry. You're out of guesses. Better luck next time!");
                }
                else if (answerInt != secretNumber)
                {
                    Console.Write("Dang. That's not it. ");
                    guessNumber();
                }
                else
                {
                    Console.WriteLine("Success! You guessed the secret number.");
                    count = 5;
                }
                count++;
            }
            else
            {
                Console.Write("Please guess a whole number: ");
            }
        }
    }


    void guessNumber()
    {
        Console.Write("Guess a whole number: ");
    };

}


