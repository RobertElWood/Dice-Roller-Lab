using System;

namespace Dice_Roller_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Boolean trigger for restarting the loop
            bool runAgain = true;

            //User welcome statement. Welcomes user to the dice rolling game
            Console.WriteLine("Welcome to the dice simulator game! This application can simulate any two dice rolls with dice of your choice!\n");
            Console.WriteLine("It's all the thrill of the casino without any of the winnings! How...exciting.");

            //While Loop which loops through the dice rolls
            while (runAgain) 
            {
                //Asks the user for their input, binding both to a variable.
                //Checks if the user's input is valid using TryParse. Prompts user to re-enter their data if it is not.

                Console.WriteLine("\nBefore we roll, how many sides would you like your first die to have?\n");
                var IsNumeric = int.TryParse(Console.ReadLine(), out int dieOne);
                
                if (IsNumeric == false) 
                {
                    Console.WriteLine("\nI'm sorry, I don't think you entered a valid number. Please try again.\n");
                    continue;
                }

                Console.WriteLine("\nHow many sides should your second die have?\n");
                var IsNumeric2 = int.TryParse(Console.ReadLine(), out int dieTwo);

                if (IsNumeric2 == false)
                {
                    Console.WriteLine("\nI'm sorry, I don't think you entered a valid number. Please try again.\n");
                    continue;
                }

                Console.WriteLine($"\nAlright! So, one die with {dieOne} sides, and the other with {dieTwo} sides.\n");

                //asks to confirm the user's input before die numbers are used by associated method.

                Console.WriteLine("Are we ready to roll? If you're ready, type 'roll'. If not, type anything else and you can reselect your dice.\n");

                var input = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (input == "roll" && (dieOne + dieTwo) != 12) 
                {
                    //Rolls the dice according to the numbers specified by the user

                    Console.WriteLine("\nYou rolled the dice.\n");

                    int resultOne = RandomNumberGenerator(dieOne);

                    int resultTwo = RandomNumberGenerator(dieTwo);

                    DiceOutput(resultOne, resultTwo);
                } 
                else if (input == "roll" && dieOne == 6 && dieTwo == 6) 
                {
                    //rolls the dice, but...
                    //provides a call to the method for six-sided dice, so the correct string can also be printed.
                    Console.WriteLine("\nYou rolled the dice.\n");

                    int resultOne = RandomNumberGenerator(dieOne);

                    int resultTwo = RandomNumberGenerator(dieTwo);

                    DiceOutput(resultOne, resultTwo);
                    Console.WriteLine();

                    Console.WriteLine(SixSidedOutput(resultOne, resultTwo));
                }  
                else 
                { 
                    continue;
                }

                runAgain = RunAgain();

            }
            
        }

        //Method to generate random numbers to be used by the app
        public static int RandomNumberGenerator (int die)
        {
            Random r = new Random();

            int randomN = r.Next(1, (die + 1));

            return randomN;
        }

        //Method to display the dice output to the user
        public static void DiceOutput (int resultOne, int resultTwo) 
        {
            Console.WriteLine($"Die one roll:\t{resultOne}\n");
            Console.WriteLine($"Die two roll:\t{resultTwo}\n");
            Console.WriteLine($"Total Roll was:\t{resultOne + resultTwo}\n");
        }

        //Method to display message for six-sided dice

        public static string SixSidedOutput(int resultOne, int resultTwo) 
        {

            if (resultOne == 1 && resultTwo == 1)
            {
                return "You got...Snake Eyes!\n\nThat's Craps. You lose!\n";
            }
            else if (resultOne + resultTwo == 3)
            {
                return "An Ace Deuce!\n\nThat's Craps. You lose!\n";
            }
            else if (resultOne == 6 && resultTwo == 6)
            {
                return "Box Cars! You got double sixes!\n\nThat's Craps. You lose!\n";
            }
            else if (resultOne + resultTwo == 7 || resultOne + resultTwo == 11)
            {
                return $"You got {resultOne + resultTwo}!\n\nYou Win!\n";
            } 
            else 
            {
                return "";
            }

        }

        //Looping method to restart the program, or end it, based on user input
        public static bool RunAgain()
        {
            Console.WriteLine("\nThank you for your playing!");
            Console.WriteLine("\nWould you like to roll again? Y/N?\n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine();
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("\nThanks for using our dice simulator! Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't understand that. Please try again!");
                return RunAgain();
            }

        }

    }

}


