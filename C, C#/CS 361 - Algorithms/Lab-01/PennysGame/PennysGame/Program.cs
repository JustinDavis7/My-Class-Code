using System;
using System.Collections.Generic;

namespace PennysGame
{
    public class Program
    {
        private static Random _random = new Random();
        public static void Main(string[] args)
        {
            var userChoice = "Y";

            int userScore = 0;
            int compScore = 0;

            
            var flips = string.Empty; // same as ""

            while (userChoice == "Y")
            {
                int user_first = _random.Next(2);
                var faceNumber = _random.Next(2);

                flips += faceNumber == 0 ? "H" : "T";

                var usersSequence = "";
                var compSequence = "";

                if (user_first == 0)
                {
                    Console.WriteLine("The user gets to go first.\nPlease enter your sequence: ");
                    usersSequence = Console.ReadLine();
                    if (usersSequence[1] == 'T')
                    {
                        compSequence = "H";
                        compSequence += (usersSequence[0]);
                        compSequence += (usersSequence[1]);
                    }
                    else
                    {
                        compSequence = "T";
                        compSequence += (usersSequence[0]);
                        compSequence += (usersSequence[1]);
                    }
                }
                else
                {
                    for (var i = 0; i < 3; ++i)
                    {
                        faceNumber = _random.Next(2);
                        compSequence += faceNumber == 0 ? "H" : "T";
                    }
                    Console.WriteLine($"The computer chose first. Here is their sequence: {compSequence}\nPlease enter your sequence: ");
                    usersSequence = Console.ReadLine();
                }

                var containsUserSequence = false;
                var containsCompSequence = false;

                while (containsCompSequence == false && containsUserSequence == false)
                {
                    faceNumber = _random.Next(2);

                    flips += faceNumber == 0 ? "H" : "T";
                    containsUserSequence = flips.Contains(usersSequence);
                    containsCompSequence = flips.Contains(compSequence);
                }
                
                Console.WriteLine($"\nThe game sequence is: {flips}");

                Console.WriteLine($"Your sequence is: {usersSequence}");
                Console.WriteLine($"Computer sequence is: {compSequence}");

                if (containsUserSequence)
                {
                    Console.WriteLine("\nYour sequence was correct. You win!");
                    userScore += 1;
                }
                else if (containsCompSequence)
                {
                    Console.WriteLine("\nThe computer's sequence was correct. You lose.");
                    compScore += 1;
                }
                else
                {
                    Console.WriteLine("\nNeither of your sequences was correct. You're both bad at this.");
                }

                Console.WriteLine($"\nThe current score is: User {userScore} - Comp {compScore}");
                Console.WriteLine("Would you like to continue playing: Y/N");
                userChoice = Console.ReadLine();
                userChoice = userChoice.ToUpper();
                flips = string.Empty;
                Console.WriteLine("\n\n--------------------------------");
            }
        }
    }
}
