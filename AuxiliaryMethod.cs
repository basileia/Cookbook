using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    class AuxiliaryMethod
    {
        public static string LoadStringFromConsole(string question)
        {
            Console.WriteLine(question);
            string userInput = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Hodnota nemůže zůstat prázdná.");
                Console.WriteLine(question);
                userInput = Console.ReadLine().Trim();

            }
            
            return userInput.Trim();
        }

        public static double LoadNumberFromConsole(string question)
        {
            double number = 0;
            bool convertResult = false;

            while (convertResult == false || number <= 0)
            {
                Console.WriteLine(question);
                string numberText = Console.ReadLine();
                convertResult = double.TryParse(numberText, out number);

                if (convertResult == false || number <= 0)
                {
                    Console.WriteLine("Toto není číslo větší než nula.");
                }
            }

            return number;
        }

        public static int LoadNumberInRange(string question, int max, int min = 1)
        {
            int userInput = (int)LoadNumberFromConsole(question);
            while (userInput < min || userInput > max)
            {
                Console.WriteLine($"Číslo není v rozmezí {min} až {max}");
                userInput = (int)LoadNumberFromConsole(question);
            }
            return userInput;           
        }

        public static string EnterYesOrNo(string question)
        {
            string userInput = "";
            while (userInput != "n" && userInput != "a")
            {
                userInput = LoadStringFromConsole(question).ToLower();
            }
            return userInput;
        }

       public static string GetProjectDirectory()
        {
            var CurrentProjectDirectory = Directory.GetCurrentDirectory();
            if (CurrentProjectDirectory.Contains("\\bin"))
            {
                int index = CurrentProjectDirectory.IndexOf("\\bin");   
                return CurrentProjectDirectory.Substring(0, index);
            }
            return CurrentProjectDirectory;
            
        }

    }
}
