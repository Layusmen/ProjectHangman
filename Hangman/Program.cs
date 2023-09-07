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

            //Console.WriteLine(words[secretWordIndex]);
        }
    }
}