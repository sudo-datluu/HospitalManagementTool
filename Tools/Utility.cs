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
    }
}
