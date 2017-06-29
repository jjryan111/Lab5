using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = "y";
            Random rng = new Random();
            while (yesNo == "Y" || yesNo == "y")
            {
                Console.WriteLine();
                int numDice = GetInput("How many dice? ");
                int[] rollDice = new int[numDice];
                int dieSide = GetInput("How many sides should each die have? ");
                dieSide++;
                //foreach (int i in rollDice)
                for(int i = 0; i < rollDice.Length; i++)
                {
                    rollDice[i] = rng.Next(1, dieSide);
                }
                PrintRoll(rollDice);
                if (numDice == 2 && (dieSide-1)== 6)
                {
                    SpecialRoll(rollDice);
                }
                Console.WriteLine();
                yesNo = ynInput();
            }
        }

        public static void SpecialRoll(int [] test)
        {
            Console.WriteLine("Special Rules");
            if (test[0]==1 && test[1] == 1)
            {
                Console.WriteLine("Snake Eyes!");
            }
            else if (test[0] == 6 && test[1] == 6)
            {
                Console.WriteLine("Boxcars!");
            }
            else if (test[0] == test[1])
            {
                Console.WriteLine("Doubles!");
            }
        }
        public static void PrintRoll(int [] roll )
        {
           for (int j = 0; j < roll.Length; j++)
                //                foreach (int j in rollDice)
                {
                    Console.WriteLine("Die"+(j+1)+": " + roll[j]);
                }
        }
        public static int GetInput(string question)
        {
            bool validInput = false;
            int exitNum = 0;
            while (!validInput)
            {
                Console.Write(question);
                bool inp = int.TryParse(Console.ReadLine(), out exitNum);
                if (!inp || exitNum < 1)
                {
                    Console.WriteLine("That's not valid input!");
                }
                else
                {
                    validInput = true;
                }
            }
            return exitNum;
        }

        static string ynInput()
        {
            string input = "";
            bool invalid = true;
            while (invalid)
            {
                Console.WriteLine("");
                Console.WriteLine("Continue? (y/n): ");
                input = Console.ReadLine();
                if ((input == "y") || (input == "n") || (input == "Y") || (input == "N"))
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("Please answer y or n.");
                }
            }
            return input;
        }
    }
}

