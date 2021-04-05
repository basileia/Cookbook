using System;
using System.Collections.Generic;
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
            string userInput = Console.ReadLine();

            while (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Hodnota nemůže zůstat prázdná.");
                Console.WriteLine(question);
                userInput = Console.ReadLine();

            }
            
            return userInput;
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
    }
}
