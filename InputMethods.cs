using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE
{
    internal class InputMethods
    {

        public InputMethods()
        {
        }




        public static int numbervalidation(String msg, int min, int max)
        {

            int finalChoice = 0;
            bool correctInput = false;
            string userInput;
            int intUserInput;

            while (!correctInput)
            {
                userInput = Console.ReadLine();

                try
                {
                    intUserInput = int.Parse(userInput);

                    if (intUserInput >= min && intUserInput <= max)
                    {
                        Console.Clear();
                        finalChoice = intUserInput;
                        correctInput = true;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(msg);
                    }


                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);

                }
            }

            return finalChoice;
        }

        public static string measurementValidation()
        {

            bool correctInput = false;
            String userInput;
            String finalmeasure = "";
            //below is a list of valid measurements i created
            string[] ingredientMeasurements = {
    "ml", "millilitre", "litre","l", "tsp", "tbsp", "tablespoon", "cup", "gram", "g", "kilogram", "kg", "teaspoon", "mg", "teaspoons" , "mililitres" };
            while (!correctInput)
            {
                Console.Write("Measurement: ");
                userInput = Console.ReadLine().Trim().ToLower();
                bool matchesValidMeasurement = ingredientMeasurements.Any(item => item.Equals(userInput, StringComparison.OrdinalIgnoreCase));


                if (matchesValidMeasurement)
                {

                    finalmeasure = userInput;
                    correctInput = true;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not correct measurement! ");


                }



            }




            return finalmeasure;
        }
        public static double QuantityValid(String msg)
        {

            double finalChoice = 0;
            bool correctInput = false;
            string userInput;
            double DUserInput;

            while (!correctInput)
            {
                Console.Write("Quantity: ");
                userInput = Console.ReadLine();

                try
                {
                    //Used this special parse method to handle periods in the code, the Replace("," , "") was reading 0.5 as 5
                    //This method correctly interprets decimals 
                    DUserInput = double.Parse(userInput, System.Globalization.CultureInfo.InvariantCulture);


                    if (DUserInput >= double.MinValue && DUserInput <= double.MaxValue)
                    {
                        Console.Clear();
                        finalChoice = DUserInput;
                        correctInput = true;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(msg);
                    }


                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);

                }
            }

            return finalChoice;
        }

    }
}
