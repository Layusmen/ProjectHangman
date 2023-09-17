using System.Collections;

namespace ProjectHangman
{
    class Program
    {
        const int MAX_GUESS = 6;

        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "standard", "approach", "wonder", "student", "catering" };
            Random random = new Random();
            int secretWordIndex = random.Next(words.Count);
            string secretWord = words[secretWordIndex];

            Console.Clear();
            Console.WriteLine("I have picked a secret word from the list, can you try to guess the word?:");

            Console.WriteLine("Can you guess it?");
            bool isGameOver = false;
            int numberOfGuesses = 0;
            string guessedLetters = "";
            while (!isGameOver)
            {
                Console.WriteLine("Guess a letter:");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char guessedLetter = keyInfo.KeyChar;

                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine("You already guessed that letter!");
                }
                else
                {
                    guessedLetters += guessedLetter;
                    bool letterInWord = secretWord.Contains(guessedLetter);
                    if (letterInWord)
                    {
                        Console.WriteLine("The letter " + guessedLetter + " is in the secret word!");
                    }
                    else
                    {
                        Console.WriteLine("The letter " + guessedLetter + " is not in the secret word!");
                        numberOfGuesses++;
                    }

                    Console.Clear();
                    Console.WriteLine("The secret word is: " + getSecretWord(secretWord, guessedLetters));

                    if (numberOfGuesses == MAX_GUESS)
                    {
                        isGameOver = true;
                        Console.WriteLine("You lose!");
                    }
                    else if (getSecretWord(secretWord, guessedLetters) == secretWord)
                    {
                        isGameOver = true;
                        Console.WriteLine("You win!");
                        Console.WriteLine("Congratulations!");
                        break;
                    }
                }
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
