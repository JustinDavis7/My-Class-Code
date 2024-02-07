using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecommenderApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var recomendation = new Recommender();
            string accountName;
            int choice = 0;
            string quit = "A";
            do
            {
                do
                {
                    Console.WriteLine("Please enter your Account name: ");
                    accountName = Console.ReadLine();
                } while ((accountName == null) || !recomendation.SignIn(accountName));
                do
                {
                    Console.WriteLine("Would you like to get recomendations for books to (1) read, or (2) stay way from:");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    { 

                    }
                
                } while (choice != 1 && choice != 2);
           
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Your recommended books are: {recomendation.GetSuggestions(accountName, 1)}");
                        break;
                    case 2:
                        Console.WriteLine($"You should stay away from these books: {recomendation.GetSuggestions(accountName, 2)}");
                        break;
                }
                Console.WriteLine("Would you like to quit out of the system? Y/N");
                quit = Console.ReadLine().ToUpper();
            } while (quit != "Y");
            
        }
        
    }
}