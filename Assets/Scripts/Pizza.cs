using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    /**
     * This array represents the ingredients on the pizza in the following order:
     * [Arugula, Basil, Ham, Chicken, Pepperoni, Supreme Mix, Mushrooms]
     * 0 = No quantity, 1 = 1/4, 2 = 1/2.
     * Example: 0110200 = Pizza with 1/4 Basil, 1/4 Ham, and 1/2 Pepperoni.
     */
    int[] ingredients = new int[7];
    public void AddIngredient(Ingredient i, int quant)
    {
        int index = i.GetIngredient();
        ingredients[index] += quant;
    }

    public bool IsPizzaFull()
    {
        int sum = 0;
        for (int i = 0; i < ingredients.Length; i++)
            sum += ingredients[i];
        if (sum == 4) // Pizza is full.
            return true;
        // Pizza is not full.
        return false;
    }

    public int[] GetPizzaIngredients()
    {
        return ingredients;
    }
}
