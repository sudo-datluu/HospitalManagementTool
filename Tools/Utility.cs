using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Tools
{
    // Class for common use tools
    public static class Utility
    {
        // Get user input from message
        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Let user stop and read the console until press any key
        public static void PressKeyContinue()
        {

            Console.WriteLine("\n---------------------------\nPress any key to continue");
            Console.ReadKey();
        }

        // Let user print message, change color to red if success=false
        public static void PrintMessage(string message, bool success=true)
        {
            if (!success)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            PressKeyContinue();
        }

        // Get user input but the input will be encode as *
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                    Console.Write(prompt);
                isPrompt = false;

                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                // Break the loop if press enter
                if (inputKey.Key == ConsoleKey.Enter) break;
                
                // Delete 1 '*' character if user press backspace
                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b");
                }
                // Append new '*' character 
                else if (inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write("*");
                }

            }
            Console.WriteLine();
            return input.ToString();
        }

        // Write a banner menu
        public static void writeBanner(string banner)
        {
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine();
        }

        // Generate a random digits string
        public static string generateDigits(int minLength, int maxLength)
        {
            Random random = new Random();
            int length = random.Next(minLength, maxLength + 1); // Random length between minLength and maxLength (inclusive)

            char[] digits = new char[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)(random.Next(10) + '0'); // Generate random digit (0-9) and convert to char
            }

            return new string(digits);
        }
    }
}
