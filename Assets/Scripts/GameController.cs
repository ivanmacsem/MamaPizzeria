using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private Pizza expectedPizza;
    [SerializeField] Pizza currentPizza;
    [SerializeField] Text currentScoreView = null;
    void Start()
    {
        PlayerPrefs.SetInt("curScore", 0);
        currentScoreView = gameObject.AddComponent<Text>();
        currentScoreView.text = "0";
        expectedPizza = gameObject.AddComponent<Pizza>();
        GeneratePizza();
        Console.WriteLine("game controller started");
    }

    private void GeneratePizza()
    {
        Ingredient first = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0,6));
        Ingredient second = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0,6));
        Ingredient third = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0,6));
        expectedPizza.AddIngredient(first, 1);
        expectedPizza.AddIngredient(second, 1);
        expectedPizza.AddIngredient(third, 2);
    }

    // Refer to the code list in Ingredient.cs for more details.
    public void AddToCurrentPizza(int ingredient)
    {
        //currentPizza.AddIngredient(1);
        PlayerPrefs.SetInt("curScore", ingredient);
        Console.WriteLine("add ingredient to current pizza");
        currentScoreView.text = ingredient.ToString();
    }
}
