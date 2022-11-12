using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Pizza expectedPizza;
    [SerializeField] PizzaSlot currentPizza;
    void Start()
    {
       expectedPizza = gameObject.AddComponent<Pizza>();
    }

    private void GeneratePizza(){
        Ingredient first = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0,6));
        Ingredient second = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0,6));
        Ingredient third = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0,6));
        expectedPizza.AddIngredient(first, 1);
        expectedPizza.AddIngredient(second, 1);
        expectedPizza.AddIngredient(third, 2);
    }
}
