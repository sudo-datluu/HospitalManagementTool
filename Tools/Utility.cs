using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Tools
{
    public static class Utility
    {
        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static void PressKeyContinue()
        {

            Console.WriteLine("\n---------------------------\nPress any key to continue");
            Console.ReadKey();
        }

        public static void PrintMessage(string message, bool success=true)
        {
            if (!success)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            PressKeyContinue();
        }
    }
}
