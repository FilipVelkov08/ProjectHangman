using System;
using System.Linq;

class HangmanGame
{
    static void Main()
    {
        string[] hangmanFrames = {
            // Death Animation Frames
            "   ╔═══╗\n   |   ║\n   O   ║\n  /|\\  ║\n  / \\  ║\n       ║\n══════╩═══",
            "   ╔═══╗\n   |   ║\n   O   ║\n  /|\\  ║\n  /    ║\n       ║\n══════╩═══",
            "   ╔═══╗\n   |   ║\n   O   ║\n  /|\\  ║\n       ║\n       ║\n══════╩═══",
            "   ╔═══╗\n   |   ║\n   O   ║\n  /|   ║\n       ║\n       ║\n══════╩═══",
            "   ╔═══╗\n   |   ║\n   O   ║\n   |   ║\n       ║\n       ║\n══════╩═══",
            "   ╔═══╗\n   |   ║\n   O   ║\n       ║\n       ║\n       ║\n══════╩═══",
            "   ╔═══╗\n   |   ║\n       ║\n       ║\n       ║\n       ║\n══════╩═══"
        };

        string[] words = { "hangman", "python", "programming", "code", "developer", "challenge" };
        string wordToGuess = words[new Random().Next(words.Length)];
        HashSet<char> guessedLetters = new HashSet<char>();
        int incorrectGuesses = 0;

        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine(DisplayWord(wordToGuess, guessedLetters));

        while (true)
        {
            Console.Write("Guess a letter: ");
            char guess = Console.ReadLine().ToLower()[0];

            if (Char.IsLetter(guess) && guessedLetters.Add(guess))
            {
                if (!wordToGuess.Contains(guess))
                {
                    incorrectGuesses++;
                    Console.WriteLine(hangmanFrames[incorrectGuesses - 1]);
                }

                string displayedWord = DisplayWord(wordToGuess, guessedLetters);
                Console.WriteLine(displayedWord);

                if (!displayedWord.Contains('*'))
                {
                    Console.WriteLine("Congratulations! You guessed the word!");
                    Console.WriteLine("┌───────────────────────────┐\n" +
                                      "│                           │\n" +
                                      "│                           │\n" +
                                      "│                           │\n" +
                                      "│                           │\n" +
                                      "│                           │\n" +
                                      "│        Good job!          │\n" +
                                      "│ You guessed the word!     │\n" +
                                      "└───────────────────────────┘");
                    break;
                }

                if (incorrectGuesses == hangmanFrames.Length)
                {
                    Console.WriteLine($"Sorry, you lost! The word was: {wordToGuess}");
                    Console.WriteLine("┌────────────────────────────────────┐\n" +
                                      "│                                    │\n" +
                                      "│                                    │\n" +
                                      "│                                    │\n" +
                                      "│                                    │\n" +
                                      "│                                    │\n" +
                                      "│         Better luck next time!     │\n" +
                                      "│                                    │\n" +
                                      "└────────────────────────────────────┘");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid letter.");
            }
        }
    }

    static string DisplayWord(string word, HashSet<char> guessedLetters)
    {
        return new string(word.Select(c => guessedLetters.Contains(c) ? c : '*').ToArray());
    }
}