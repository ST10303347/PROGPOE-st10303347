using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PROGPOE
{


    public delegate void AlertDelegate(double a);
    internal class Program
    {
         static void CalorieWarning(double a)
        {

            if (a > 500)
            {
                MessageBox.Show("Warning: We have now exceeded 500 calories \nCurrent calorie count : " + a);

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }



            

        }
        

        static void Main(string[] args)
        {
            
        //Declarations   
        Boolean screenON = true;
            List<String> emptyarr = new List<string> { };
            List<double> emptyarr2 = new List<double>();
            Recipe testOB = new Recipe(" ", emptyarr, emptyarr2, emptyarr, emptyarr, emptyarr2, emptyarr);
            double scale = 1;
            double newScale = 1;
            List<string> FoodGroups = new List<string>() { "Starchy foods", "Vegetables and fruits", "Dry beans, peas, lentils and soya", "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oil", "Water", };
            String Foodgroupmsg = ("Enter which Food group this ingredient belongs to: \n1.Starchy foods\n2.Vegetables and fruits\n3.Dry beans, peas, lentils and soya\n4.Chicken, fish, meat and eggs\n5.Milk and dairy products\n6.Fats and oil, and\n7.Water");
            
         AlertDelegate alert = CalorieWarning;

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
                Console.WriteLine("1.Create a new recipe\n2.View Recipe\n3.Scale recipe\n4.Delete Recipe\n5.Exit Aplication");
                int menuchoice = InputMethods.numbervalidation("choose an option from 1-6", 1, 5);
                //Above is a method to validate user input so application does not crash  
                switch (menuchoice)
                {
                    case 1:

                        //Aplication takes user input and stores it in arrays if it can be more than 1 but the name is stored in a string                        
                        Console.WriteLine("What is your recipe name");
                        string name = Console.ReadLine();
                        Console.WriteLine("How many ingredients will you be entering?");
                        int noOfIngredients = InputMethods.numbervalidation("enter ingredients between 1-100", 1, 100);
                        List<String> ingredientsArr = new List<String>(noOfIngredients);
                        List<Double> QuantitiesArr = new List<Double>(noOfIngredients);
                        List<String> ingMeasurementArr = new List<String>(noOfIngredients);
                        List<Double> CaloriesArr = new List<Double>(noOfIngredients);
                        List<String> foodGroup = new List<String>(noOfIngredients);
                        Console.Clear();
                        //Clear method keeps screen neat
                        double totalCalories = 0;
                        for (int i = 0; i < noOfIngredients; i++)
                        {

                            int n = 1 + i;
                            Console.Write("Ingredient " + n + "\nName: ");
                            String ingName = Console.ReadLine();
                            ingredientsArr.Add(ingName);

                            String ingMeasurement = InputMethods.measurementValidation();
                            ingMeasurementArr.Add(ingMeasurement);
                            //Quantity is verified using Double.min and max methods in Input methods class                             


                            double quantity = InputMethods.QuantityandCalorieValid("Please enter the quantity of your ingredients", "Quantity");
                            QuantitiesArr.Add(quantity);

                            double ingCalories = InputMethods.QuantityandCalorieValid("Please enter the number of calories for this item", "Calories");
                            CaloriesArr.Add(ingCalories);
                            totalCalories += CaloriesArr[i]; // Update the total calories
                            alert(totalCalories);

                            Console.WriteLine(Foodgroupmsg);
                            int ingfoodgroup = InputMethods.numbervalidation("Please pick a number from the provided list", 1, 7);
                            ingfoodgroup--;
                            foodGroup.Add(FoodGroups[ingfoodgroup]);

                          
                            // Check if totalCalories exceed 500 and display a warning message through a popup window

                            Console.Clear();

                        }
                        //the number of steps becomes the array size and prompts you to fill the array
                        Console.WriteLine("How many Steps will the recipe have?");
                        int noOfSteps = InputMethods.numbervalidation("Please enter the number of steps your recipe has!!", 1, 100);
                        List<String> stepsArr = new List<String>(noOfSteps);
                        for (int i = 0; i < noOfSteps; i++)
                        {
                            int n = 1 + i;
                            Console.WriteLine("Step " + n + ": ");
                            String step = Console.ReadLine();
                            stepsArr.Add(step);


                        }
                        testOB = new Recipe(name, ingredientsArr, QuantitiesArr, ingMeasurementArr, stepsArr, CaloriesArr, foodGroup);

                        ListWork.recipeList.Add(testOB);

                        Console.WriteLine("Recipe Created");




                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Clear();
                        foreach (var item in ListWork.recipeList)
                        {
                            Recipe.measurementConversion(item);
                        }

                        if (ListWork.recipeList.Count > 0)
                        {
                            Console.WriteLine("Pick a Recipe to display Fully");
                            var sortedRecipes = ListWork.recipeList.OrderBy(r => r.RecipeName).ToList();
                            Recipe.DisplayList(sortedRecipes);
                            int displayFully = InputMethods.numbervalidation(("Pick a Recipe to display Fully. Options 1 to " + sortedRecipes.Count), 1, sortedRecipes.Count);
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
                        if (ListWork.recipeList.Count > 0)
                        {

                            newScale = 1;

                            scale = newScale;

                            Console.WriteLine("Welcome to scaling! Pick a recipe to Scale\n");
                            var sortedRecipes = ListWork.recipeList.OrderBy(r => r.RecipeName).ToList();
                            Recipe.DisplayList(sortedRecipes);
                            int displayFully = InputMethods.numbervalidation(("Pick a Recipe to display Fully. Options 1 to " + sortedRecipes.Count), 1, sortedRecipes.Count);
                            displayFully--;
                            Recipe.Scale(scale, sortedRecipes[displayFully], newScale);
                            Console.WriteLine(sortedRecipes[displayFully].ToString());
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("1.Half");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("2. Double");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("3.Triple");
                            Console.ForegroundColor = ConsoleColor.White;
                            int scaling = InputMethods.numbervalidation("Please choose a scaling option from 1-3", 1, 3);
                            switch (scaling)
                            {
                                //The colour of the menu option chosen is the colour the sclaled recipe will print                          
                                case 1:
                                    Console.ResetColor();
                                    Console.Clear();
                                    Console.WriteLine(sortedRecipes[displayFully].ToString()); Console.WriteLine("*******New Recipe*******"); Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    newScale = 0.5;
                                    Recipe.Scale(scale, testOB, newScale);
                                    scale = newScale;

                                    break;
                                case 2:
                                    Console.ResetColor();
                                    Console.Clear();
                                    Console.WriteLine(sortedRecipes[displayFully].ToString()); Console.WriteLine("*******New Recipe*******"); Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    newScale = 2;
                                    Recipe.Scale(scale, testOB, newScale);
                                    scale = newScale;



                                    break;
                                case 3:
                                    Console.ResetColor();
                                    Console.Clear();
                                    Console.WriteLine(sortedRecipes[displayFully].ToString()); Console.WriteLine("*******New Recipe*******"); Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    newScale = 3;
                                    Recipe.Scale(scale, testOB, newScale);
                                    scale = newScale;



                                    break;


                            }
                            Recipe.measurementConversion(testOB);
                            Recipe.measurementConversion(testOB);

                            Console.WriteLine(testOB.ToString());

                        }
                        else
                        {

                            Console.WriteLine("You have not Created a recipe yet");
                        }


                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();







                        break;
                    case 4:


                        if (ListWork.recipeList.Count > 0)
                        {
                            Console.WriteLine("Welcome to scaling! Pick a recipe to Delete\n");
                            var sortedRecipes = ListWork.recipeList.OrderBy(r => r.RecipeName).ToList();
                            Recipe.DisplayList(sortedRecipes);
                            int displayFully = InputMethods.numbervalidation(("Pick a Recipe to display Fully. Options 1 to " + sortedRecipes.Count), 1, sortedRecipes.Count);
                            displayFully--;
                            int originalIndex = ListWork.recipeList.IndexOf(sortedRecipes[displayFully]);
                            ListWork.recipeList.RemoveAt(originalIndex);
                            Console.WriteLine("Recipe deleted successfully!");




                        }
                        else
                        {


                            Console.WriteLine("NO RECIPES TO DELETE");


                        }
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Have an amazing day ;)");
                        System.Environment.Exit(0);
                        break;

                }
            }
        }
    }
}