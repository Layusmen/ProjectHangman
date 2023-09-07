using System;
namespace ProjectHangman
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> words = new List<string>();
            words.Add("Standard");
            words.Add("Approach");
            words.Add("Wonder");
            words.Add("Student");
            words.Add("catering");

            Random random = new Random();
            int secretWordIndex = random.Next(words.Count);
            string secretWord = words[secretWordIndex];

            Console.WriteLine("I have picked a secret word from the list, can you try to guess the word?:");

            Console.WriteLine(words[secretWordIndex]);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Can you guess it?");

            bool isGameOver = false;
            int numberOfGuesses = 0;
            string guessedLetters = "";

            while (!isGameOver)
            {
                Console.WriteLine("Guess a letter:");
                string guessedLetter = Console.ReadLine();

                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("You already guessed that letter!");
                }
                else
                {
                    guessedLetters += guessedLetter;

                    bool isLetterInWord = secretWord.Contains(guessedLetter);

                    if (isLetterInWord)
                    {
                        Console.WriteLine("The letter " + guessedLetter + " is in the secret word!");
                    }
                    else
                    {
                        Console.WriteLine("The letter " + guessedLetter + " is not in the secret word!");
                        numberOfGuesses++;
                    }

                    if (numberOfGuesses == 6)
                    {
                        isGameOver = true;
                        Console.WriteLine("You lose!");
                    }
                }

            }



        }
    }
}