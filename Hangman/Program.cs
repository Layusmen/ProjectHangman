using System;
namespace ProjectHangman
{
    class Program
    {
        const int MAX_GUESS = 6;
        const char PLACEHOLDER = '_';
        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "standard", "approach", "wonder", "student", "catering" };
            Random random = new Random();
            int secretWordChosen = random.Next(words.Count);
            string secretWord = words[secretWordChosen];
            char[] revealedWord = new char[secretWord.Length];

            // Initialize the revealed word array with dashes.
            for (int i = 0; i < secretWord.Length; i++)
            {
                revealedWord[i] = PLACEHOLDER;
            }
            // Clear the console and display the welcome message.
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("I have picked a secret word from the list. Can you try to guess the word?");

            // Start the game loop.
            int guessLeft = MAX_GUESS; // Initialize guessLeft to the maximum number of guesses.
            while (guessLeft > 0)
            {
                // Display the current state of the revealed word.
                string guessedWord = new string(revealedWord);
                Console.WriteLine($"\nCurrent word: {guessedWord}");
                Console.WriteLine($"Guesses remaining: {guessLeft}");

                // Read the player's guess.
                Console.Write("Guess a letter: ");
                char guess = Console.ReadKey().KeyChar;

                // Check if the guess is contained in the secret word.
                bool isCorrectGuess = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        revealedWord[i] = guess;
                        isCorrectGuess = true;
                    }
                }
                // If the guess is incorrect, decrement guessLeft.
                if (!isCorrectGuess)
                {
                    guessLeft--; // Decrement guessLeft for an incorrect guess.
                }
                // Check if the player has won or lost the game.
                if (!revealedWord.Contains(PLACEHOLDER))
                {
                    Console.WriteLine($"\nYou win! The secret word was '{secretWord}'.");
                    break;
                }
            }
            // If guessLeft reaches 0, the player has lost.
            if (guessLeft == 0)
            {
                Console.WriteLine($"\nYou lose! The secret word was '{secretWord}'.");
            }
        }
    }
}
