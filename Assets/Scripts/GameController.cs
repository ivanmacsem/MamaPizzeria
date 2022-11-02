using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private Pizza expectedPizza;
    private int currentScore = 0, wrongOrders = 0;
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
        //currentScoreView.text = ingredient.ToString();

        // Maybe move this to separate method?
        if (currentPizza.IsPizzaFull())
        {
            // Compare the two pizzas.
            int[] temp = currentPizza.GetPizzaIngredients();
            int[] temp2 = expectedPizza.GetPizzaIngredients();
            if (temp.Equals(temp2)) // The pizzas are equal.
            {
                currentScore++;
                currentScoreView.text = currentScore.ToString();
                if (wrongOrders > 0)
                    wrongOrders = 0;
            }
            else // The pizzas are not equal.
            {
                currentScore = 0;
                wrongOrders++;
                if (wrongOrders == 3)
                {
                    // TODO: Implement "You're fired" screen before making this work.
                }
                currentScoreView.text = currentScore.ToString();
            }
        }
    }
}
