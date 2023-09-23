using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementTool.Tools
{
    public static class Validator
    {
        // Try to convert input to target type
        // define prompt to announce info for the input
        // isLoop = true if you want to keep user continue to enter input
        // isMsg = true if you want to print error message to console
        public static T Convert<T>(string prompt, bool isLoop = true, bool isMsg=true)
        {
            bool valid = false;
            string? userInput;

            while (!valid)
            {
                userInput = Utility.GetUserInput(prompt);
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default; 
                    }
                }
                catch
                {
                    if (isMsg)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Input. Please try again");
                        Console.ResetColor();
                    }
                }
                if (!isLoop) { break; }
            }
            return default;
        }
    }
}
