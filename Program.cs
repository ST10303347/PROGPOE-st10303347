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
            String[] emptyarr = { };
            double[] emptyarr2 = { };
            Recipe testOB = new Recipe(" ", emptyarr, emptyarr2, emptyarr, emptyarr);
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
                int menuchoice = InputMethods.numbervalidation("choose an option from 1-6", 1, 6);
                //Above is a method to validate user input so application does not crash  
                switch (menuchoice)
                {
                    case 1:
                      
                            //Aplication takes user input and stores it in arrays if it can be more than 1 but the name is stored in a string                        
                            Console.WriteLine("What is your recipe name");
                            string name = Console.ReadLine();
                            Console.WriteLine("How many ingredients will you be entering?");
                            int noOfIngredients = InputMethods.numbervalidation("enter ingredients between 1-100", 1, 100);
                            String[] ingredientsArr = new String[noOfIngredients];
                            double[] QuantitiesArr = new double[noOfIngredients];
                            String[] ingMeasurementArr = new String[noOfIngredients];
                            Console.Clear();
                            //Clear method keeps screen neat
                            for (int i = 0; i < noOfIngredients; i++)
                            {

                                int n = 1 + i;
                                Console.Write("Ingredient " + n + "\nName: ");
                                String ingName = Console.ReadLine();


                                String ingMeasurement = InputMethods.measurementValidation();
                                //Quantity is verified using Double.min and max methods in Input methods class                             


                                double quantity = InputMethods.QuantityValid("Please enter the quantity of your ingredients");
                                ingredientsArr[i] = ingName;
                                ingMeasurementArr[i] = ingMeasurement;
                                QuantitiesArr[i] = quantity;
                                Console.Clear();

                            }
                            //the number of steps becomes the array size and prompts you to fill the array
                            Console.WriteLine("How many Steps will the recipe have?");
                            int noOfSteps = InputMethods.numbervalidation("Please enter the number of steps your recipe has!!", 1, 100);
                            String[] stepsArr = new string[noOfSteps];
                            for (int i = 0; i < noOfSteps; i++)
                            {
                                int n = 1 + i;
                                Console.WriteLine("Step " + n + ": ");
                                String step = Console.ReadLine();
                                stepsArr[i] = step;


                            }
                            testOB = new Recipe(name, ingredientsArr, QuantitiesArr, ingMeasurementArr, stepsArr);

                            ListWork.recipeList.Add(testOB);

                            Console.WriteLine("Recipe Created");
                        

                       

                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Clear();
                        foreach(var item in ListWork.recipeList)
                        {
                            Recipe.measurementConversion(item);
                        }
                        if (ListWork.recipeList.Count>0)
                        {
                            Console.WriteLine("Pick a Recipe to display Fully");
                            Recipe.DisplayList();
                            int displayFully = InputMethods.numbervalidation(("Pick a Recipe to display Fully. Options 1 to " + ListWork.recipeList.Count), 0, ListWork.recipeList.Count);
                            Console.WriteLine(ListWork.recipeList[displayFully-1].ToString());
                        }
                        //Changed error messages to red colour                       
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have not Created a recipe yet");
                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
                }
        }
    }
}