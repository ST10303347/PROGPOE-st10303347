using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Declarations   
            Boolean screenON = true;
          

            double scale = 1;
            double newScale = 1;




            //Starts Here

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Recipe.net8!!!!!!!!");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            //Boolean to keep screen on, Application will always return to the begining of a while loop after breaking out of a if statement or switch case
            while (screenON)
            {
                Console.Clear();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1.Create a new recipe\n2.View Recipe\n3.Scale recipe\n4.Reset Quantities\n5.Delete Recipe\n6.Exit Aplication");
                //int menuchoice = InputMethods.numbervalidation("choose an option from 1-6", 1, 6);
                //Above is a method to validate user input so application does not crash  


            }
        }
    }
}