using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    // 0 - Arugula quantity
    // 1 - Basil quantity
    // 2 - Ham quantity
    // 3 - Chicken quantity
    // 4 - Pepperoni quantity
    // 5 - Supreme Mix quantity
    // 6 - Mushrooms quantity

    //1 = 1/4
    //2 = 1/2
    private int[] pizza = new int[7];
    public void AddIngredient(Ingredient i, int quant){
        int index = i.getIngredient();
        pizza[index] += quant;
    }

    public int[] GetPizza(){
        return pizza;
    }
}
