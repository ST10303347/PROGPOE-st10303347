using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PROGPOE
{
    internal class Recipe
    {
        public String RecipeName { get; set; }

        public List<String> Ingredients { get; set; }
        public List<double> Quantities { get; set; }
        public List<String> Measurements { get; set; }
        public List<String> RecipeSteps { get; set; }
        public List<double> Calories { get; set; }
        public List<String> FoodGroup { get; set; }

        public Recipe(string recipeName, List<string> ingredients, List<double> quantities, List<string> measurements, List<string> recipeSteps, List<double> calories, List<string> foodGroup)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Quantities = quantities;
            Measurements = measurements;
            RecipeSteps = recipeSteps;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public Recipe()
        {
        }

        public override string ToString()
        {

            //neat to string for displaying my recipe 
            StringBuilder finalString = new StringBuilder();
            finalString.AppendLine("Recipe Name: " + RecipeName);
            finalString.AppendLine("\nIngredients\n ");

            //I used negative alignment numbers to align it left positive numbers were aligning text right
            finalString.AppendLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-35} {4,-10}", "No.", "Ingredient", "Quantity", "FoodGroup", "Calories"));
   
            for (int i = 0; i < Ingredients.Count; i++)
            {
                int n = i + 1;

                finalString.AppendLine(string.Format("{0,-5} {1,-20} {2,-15} {3,-35} {4,-10}",
                    n,
                    Ingredients[i],
                    $"{Quantities[i]} {Measurements[i]}",
                    FoodGroup[i],
                    $"{Calories[i]} Calories"));
            }
            double totalCalories = Recipe.listTotal( Calories);
            string color;

           

            finalString.AppendLine("\n"+"Total Calories: "+totalCalories);
            Console.ForegroundColor = ConsoleColor.White;


            finalString.AppendLine("\nRecipe Steps: ");
            for (int i = 0; i < RecipeSteps.Count; i++)
            {
                int n = i + 1;
                finalString.AppendLine("Step " + n + ": " + RecipeSteps[i]);

            }
            finalString.AppendLine();

    //Calorie paragraphs are ai generated i just wrote the code
            if (totalCalories <= 100) {


                finalString.AppendLine("These light snacks and small meals are perfect for those looking to maintain a low-calorie diet or find healthy snack options throughout the day. They are ideal for those aiming to lose weight as they offer nutrient-rich choices without adding too many calories. Options like a medium apple, hard-boiled egg, or a cup of strawberries provide essential vitamins and fiber while keeping calorie intake minimal. These foods can be enjoyed individually or combined to create satisfying, low-calorie meals.");


            }

                if (totalCalories >100&&totalCalories <=200)
            {
                finalString.AppendLine("This range includes light meals and snacks that provide a bit more substance while still being low in calories. Perfect for weight loss or maintaining a balanced diet, these options include a medium banana, a serving of hummus with carrot sticks, or a low-fat cheese stick. They offer a mix of proteins, healthy fats, and carbohydrates to keep you energized without overloading on calories. These foods are great for in-between meals or as part of a light breakfast or lunch.");
            }
            else if (totalCalories > 200 && totalCalories <= 400)
            {
                finalString.AppendLine("Meals and snacks in this calorie range are more substantial and can serve as main components of a balanced diet. They include options like oatmeal, a grilled chicken breast, or a turkey sandwich. These foods are ideal for those looking to maintain or gradually lose weight while still enjoying satisfying and nutritious meals. This range provides a good balance of protein, fiber, and healthy fats, ensuring you stay full and energized throughout the day without excessive calorie intake.");
            }
            else if(totalCalories >=400)
            {
                finalString.AppendLine("These meals are more calorie-dense and can be part of a well-rounded diet when consumed in moderation. They include dishes like grilled chicken Caesar salad, spaghetti with marinara sauce, or a cheeseburger. While higher in calories, these meals can be balanced with lighter snacks and meals throughout the day. They provide the necessary energy and nutrients for those with higher calorie needs or for occasions when a more filling meal is desired. For those managing their weight, portion control and mindful eating are key when enjoying these more calorie-rich foods.");
            }

            return finalString.ToString();
        }
        public static void Scale(double currentScale, Recipe myRecipe, double newScale)
        {

            for (int i = 0; i < myRecipe.Quantities.Count; i++)
            {
                myRecipe.Quantities[i] /= currentScale;
                myRecipe.Calories[i] /= currentScale;   
                myRecipe.Quantities[i] *= newScale;
                myRecipe.Calories[i] *= newScale;   
            }


        }
        public static void measurementConversion(Recipe anObj)
        {


            for (int i = 0; i < anObj.Ingredients.Count; i++)
            {


                switch (anObj.Measurements[i])
                {
                    case "ml":
                    case "mililitre" when anObj.Quantities[i] >= 1000:
                        anObj.Measurements[i] = "litres";
                        anObj.Quantities[i] = anObj.Quantities[i] / 1000;

                        break;
                    case "l":
                    case "litre" when anObj.Quantities[i] < 1:
                        anObj.Measurements[i] = "mililitre";
                        anObj.Quantities[i] = anObj.Quantities[i] * 1000;

                        break;
                    case "tbsp":
                    case "tablespoon" when anObj.Quantities[i] >= 16:
                        anObj.Measurements[i] = "cup";
                        anObj.Quantities[i] = anObj.Quantities[i] / 16;

                        break;
                    case "cup" when anObj.Quantities[i] < 1:
                        anObj.Measurements[i] = "tablespoon";
                        anObj.Quantities[i] = anObj.Quantities[i] * 16;

                        break;
                    case "g":
                    case "gram" when anObj.Quantities[i] >= 1000:
                        anObj.Measurements[i] = "kilogram";
                        anObj.Quantities[i] = anObj.Quantities[i] / 1000;

                        break;
                    case "kilogram" when anObj.Quantities[i] < 1:
                        anObj.Measurements[i] = "gram";
                        anObj.Quantities[i] = anObj.Quantities[i] * 1000;

                        break;
                    default:
                        break;
                }


            }
        }

        public static void DisplayList(List<Recipe> recipes)
        {
            if (ListWork.recipeList.Count > 0) {

                for (int i = 0; i < ListWork.recipeList.Count; i++) {

                    Console.WriteLine(i+1 + ". " + recipes[i].RecipeName);
                }
            
            }
            else { Console.WriteLine("There are no recipes currently"); }

           }
        public static double listTotal(List<double> thelst) { 
        double total = 0;

            try
            {
                foreach (double number in thelst)
                {
                    total += number;


                }
            }
            catch (NullReferenceException ex)
            {

                return 0;
            }

            if (total <= 0 ) {

                return 0;
            
            }
        return total;



        }
       

}
}
