using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PROGPOE
{
    internal class Recipe
    {
        public String RecipeName { get; set; }

        public String[] Ingredients { get; set; }
        public double[] Quantities { get; set; }
        public String[] Measurements { get; set; }
        public Array RecipeSteps { get; set; }


        public Recipe(string recipeName, string[] ingredients, double[] quantities, string[] measurements, Array recipeSteps)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Quantities = quantities;
            Measurements = measurements;
            RecipeSteps = recipeSteps;
        }

        public override string ToString()
        {

            //neat to string for displaying my recipe 
            StringBuilder finalString = new StringBuilder();
            finalString.AppendLine("Recipe Name: " + RecipeName);
            finalString.AppendLine("\nIngredients ");

            for (int i = 0; i < Ingredients.Length; i++)
            {
                int n = i + 1;
                finalString.AppendLine(n + ". " + Quantities.GetValue(i) + " " + Measurements.GetValue(i) + " of " + Ingredients.GetValue(i));


            }
            finalString.AppendLine("\nRecipe Steps: ");
            for (int i = 0; i < RecipeSteps.Length; i++)
            {
                int n = i + 1;
                finalString.AppendLine("Step " + n + ": " + RecipeSteps.GetValue(i));

            }

            return finalString.ToString();
        }
        public static void Scale(double currentScale, Recipe myRecipe, double newScale)
        {

            for (int i = 0; i < myRecipe.Quantities.Length; i++)
            {
                myRecipe.Quantities[i] /= currentScale;
                myRecipe.Quantities[i] *= newScale;
            }


        }
        public static void measurementConversion(Recipe anObj)
        {


            for (int i = 0; i < anObj.Ingredients.Length; i++)
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

        public static void DisplayList()
        {
            if (ListWork.recipeList.Count > 0) {

                for (int i = 0; i < ListWork.recipeList.Count; i++) {

                    Console.WriteLine(i+1 + ". " + ListWork.recipeList[i].RecipeName);
                }
            
            }
            else { Console.WriteLine("There are no recipes currently"); }

           }

    }
}
