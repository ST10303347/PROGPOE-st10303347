using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Recipe testOB = new Recipe(" ", emptyarr, emptyarr2, emptyarr, emptyarr, emptyarr2);
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
                            double[] CaloriesArr = new double[noOfIngredients];
                            Console.Clear();
                        //Clear method keeps screen neat
                        double totalCalories = 0;
                        for (int i = 0; i < noOfIngredients; i++)
                            {

                                int n = 1 + i;
                                Console.Write("Ingredient " + n + "\nName: ");
                                String ingName = Console.ReadLine();

                                String ingMeasurement = InputMethods.measurementValidation();
                                //Quantity is verified using Double.min and max methods in Input methods class                             

                           
                                double quantity = InputMethods.QuantityandCalorieValid("Please enter the quantity of your ingredients", "Quantity");
                                double ingCalories = InputMethods.QuantityandCalorieValid("Please enter the number of calories for this item", "Calories");
                                ingredientsArr[i] = ingName;
                                ingMeasurementArr[i] = ingMeasurement;
                                QuantitiesArr[i] = quantity;
                                CaloriesArr[i] = ingCalories;

                            totalCalories += ingCalories; // Update the total calories

                            // Check if totalCalories exceed 500 and display a warning
                            if (totalCalories > 500)
                            {
                                MessageBox.Show("Warning: We have now exceeded 500 calories \nCurrent calorie count : " + totalCalories);
                                
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                            }
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
                            testOB = new Recipe(name, ingredientsArr, QuantitiesArr, ingMeasurementArr, stepsArr, CaloriesArr);

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
                            var sortedRecipes = ListWork.recipeList.OrderBy(r => r.RecipeName).ToList();
                            Recipe.DisplayList(sortedRecipes);
                            int displayFully = InputMethods.numbervalidation(("Pick a Recipe to display Fully. Options 1 to " + sortedRecipes.Count), 1,sortedRecipes.Count);
                            displayFully--;
                            Console.WriteLine(sortedRecipes[displayFully].ToString());
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
                    case 3:
                        if (ListWork.recipeList.Count > 0) {
                        
                        
                        
                        
                        }
                        else { 
                        
                        
                        
                        }





                        break;
                    case 4: break;
                        if (ListWork.recipeList.Count > 0) { }
                        else { }
                    case 5: break;
                        if (ListWork.recipeList.Count > 0) { }
                        else { }
                    case 6: break;
                }
                }
        }
    }
}