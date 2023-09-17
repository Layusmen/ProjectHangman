using System;
using System.Reflection.Metadata;

namespace ProjectHangman
{
    class Program
    {

        const int MAX_GUESS = 6;
        static void Main(string[] args)
        {
            List<string> words = new List<string> {"standard", "approach", "wonder", "student", "catering" };
            Random random = new Random();
            int secretWordIndex = random.Next(words.Count);
            string secretWord = words[secretWordIndex];

            // Clear the console before each guess
            Console.Clear();

            Console.WriteLine("I have picked a secret word from the list, can you try to guess the word?:");
           
            /*Console.WriteLine(words[secretWordIndex]);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }*/

            Console.WriteLine("Can you guess it?");
            bool isGameOver = false;
            int numberOfGuesses = 0;
            string guessedLetters = "";
            while (!isGameOver)
            {
                Console.WriteLine("Guess a letter:");
                // Use Console.ReadKey() to get the next character pressed by the user
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char guessedLetter = keyInfo.KeyChar;
                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("You already guessed that letter!");
                }
                else
                {
                    guessedLetters += guessedLetter;
                    bool LetterInWord = secretWord.Contains(guessedLetter);
                    if (LetterInWord)
                    {
                        Console.WriteLine("The letter " + guessedLetter + " is in the secret word!");
                    }
                    else
                    {
                        Console.WriteLine("The letter " + guessedLetter + " is not in the secret word!");
                        numberOfGuesses++;
                    }
                    if (numberOfGuesses == MAX_GUESS)
                    {
                        isGameOver = true;
                        Console.WriteLine("You lose!");
                    }
                    else if (guessedLetters.Contains(secretWord))
                    {
                        isGameOver = true;
                        Console.WriteLine("You win!");
                        // Add this line
                        Console.WriteLine("Congratulations!");
                        break;
                    }
                }
                // Clear the console after each guess
                Console.Clear();
                Console.WriteLine("The secret word is: " + getSecretWord(secretWord, guessedLetters));
            }

        }

        static string getSecretWord(string secretWord, string guessedLetters)
        {
            string hiddenWord = "";
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (guessedLetters.Contains(secretWord[i]))
                {
                    hiddenWord += secretWord[i];
                }
                else
                {
                    hiddenWord += "_";
                }
            }
            return hiddenWord;
        }
    }
}
