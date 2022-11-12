using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    // 0 - Arugula
    // 1 - Basil
    // 2 - Ham
    // 3 - Chicken
    // 4 - Pepperoni
    // 5 - Supreme Mix
    // 6 - Mushrooms
    public int ingCode;

    public Ingredient Setup(int code){
        ingCode = code;
        return this;
    }

    public void SetIngredient(int code){
        ingCode = code;
    }
    public int getIngredient(){
        return ingCode;
    }
}
