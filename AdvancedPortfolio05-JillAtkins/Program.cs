/*
Purpose: Advanced Portfolio #5 - Class Composition (Driving Simulator)

Input: - Add Fuel
       - Modify fuel economy
       - Driving distance
       - Menu option

Processes: - Add fuel (from empty or existing)
           - Drive car (add KMs & subtract fuel - fuel economy)
           - Calculate if vehicle has enough fuel to travel
           - Code to change fuel economy

Output: - Prompts
        - Current fuel level
        - Driving the vehicle (km increase / fuel decrease)
 
Author: Jill Atkins
Last Modified: 2020.04.24
*/

using System;

namespace AdvancedPortfolio05_JillAtkins
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARE
            Vehicle myVehicle = new Vehicle();
            
            int menuOptionChoice;

            do
            {
                menuOptionChoice = MenuOptions();
                ExecuteMenuOption(menuOptionChoice, myVehicle);

            } while (menuOptionChoice != 0);

        } // end Main() method

        static int MenuOptions()
        {
            // This method displays the option menu and
            // returns the option value inputted by the user
            int serviceOption;

            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("|         CPSC1012 Raceway          |");
            Console.WriteLine("|-----------------------------------|");
            Console.WriteLine("| 1. Add Fuel                       |");
            Console.WriteLine("| 2. Drive Vehicle                  |");
            Console.WriteLine("| 0. Exit                           |");
            Console.WriteLine("|-----------------------------------|");
            Console.Write("Option: ");
            serviceOption = GetUserInt();

            return serviceOption;
        } // end MenuOptions() method

        static void ExecuteMenuOption(int menuOption, Vehicle myVehicle)
        {
            // This method executes the chosen menu option

            switch (menuOption)
            {
                case 1:
                    // Add Fuel
                    myVehicle.vehicleFuelGauge.AddFuel(); // not sure what/where to assign this
                    break;

                case 2:
                    // Drive the vehicle
                    
                    Console.Write("Enter distance to drive: ");
                    double distanceToDrive = GetUserDouble();
                    
                    myVehicle.DriveVehicle(distanceToDrive);
                    break;

                case 0:
                    Console.WriteLine("\nGoodbye! Please come again!\n");
                    break;

                default:
                    Console.WriteLine("Hey! How'd you get here?");
                    break;
            } // end switch
        } // end ExecuteMenuOption() method

        public static double GetUserDouble()
        {
            // This method gets a valid double from the user
            string userInput;
            double userDouble = 0;

            userInput = ChangeInputTextToBlue();
            try
            {
                userDouble = double.Parse(userInput);
            } // end try

            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a positive number");
                Console.ResetColor();
            } // end catch

            return userDouble;
        } // end GetUserDouble() method

        public static char GetUserChar()
        {
            // This method gets a valid char (letter) input from the user

            // DECLARE
            string userInput;
            char userChar = ' ';
            bool validInput = false, validLetter = false;

            // Prompt the user for input until valid input is entered
            do
            {
                userInput = ChangeInputTextToBlue();
                try
                {
                    userChar = char.Parse(userInput);
                    userChar = char.ToUpper(userChar); // force the letter to uppercase

                    // check if the letter entered is a Letter Char (not a number or other character)
                    validLetter = Char.IsLetter(userChar);

                    if (validLetter == true)
                    {
                        if (userChar == 'Y' || userChar == 'N')
                        {
                            validInput = true;
                        } // end inner-if

                        else
                        {
                            throw new Exception();
                        } // end inner-else      
                        
                    } // end if

                    else
                    {
                        throw new Exception();
                    } // end else

                } // end try

                catch
                {
                    Console.WriteLine("Invalid input. Please enter y/n.");
                } // end catch

            } while (validInput == false);

            return userChar;
        } // end GetUserChar() method

        public static string ChangeInputTextToBlue()
        {
            // This method changes all user input text to blue
            string userInput;

            Console.ForegroundColor = ConsoleColor.Blue;
            userInput = Console.ReadLine();
            Console.ResetColor();

            return userInput;
        } // end ChangeInputTextToBlue() method

        static int GetUserInt()
        {
            // This method gets a valid integer from the user
            string userInput;
            int userInt = 0;
            bool valid = false;

            do
            {
                userInput = ChangeInputTextToBlue();
                try
                {
                    userInt = int.Parse(userInput);

                    if (userInt >= 0)
                    {
                        if (userInt == 0 || userInt == 1 || userInt == 2)
                        {
                            valid = true;
                        } // end inner-if

                        else
                        {
                            throw new Exception();
                        } // end inner-else
                    } // end if

                    else
                    {
                        valid = false;
                        throw new Exception();
                    } // end else
                } // end try

                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number between 0 and 2 inclusive");
                    Console.ResetColor();
                } // end catch

            } while (valid == false);

            return userInt;
        } // end GetUserInt() method

    } // end class
} // end namespace
