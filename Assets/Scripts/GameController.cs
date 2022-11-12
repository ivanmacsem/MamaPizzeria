using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private Pizza expectedPizza;
    private Ingredient first = null;
    private Ingredient second = null;
    private Ingredient third = null;
    private int currentScore = 0, wrongOrders = 0;
    [SerializeField] Pizza currentPizza;
    [SerializeField] Text currentScoreView = null;
    void Start()
    {
        GeneratePizza();
    }

    private void Update()
    {
        // TODO: Implement timer
    }

    private void GeneratePizza()
    {
        expectedPizza = gameObject.AddComponent<Pizza>();
        first = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0, 6));
        second = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0, 6));
        third = gameObject.AddComponent<Ingredient>().Setup(Random.Range(0, 6));
        expectedPizza.AddIngredient(first, 1);
        expectedPizza.AddIngredient(second, 1);
        expectedPizza.AddIngredient(third, 2);
    }

    // TODO: Scrap this.
    public void AddToCurrentPizza(int ingredient)
    {
        // TODO: Change this.
        Ingredient newIng = gameObject.AddComponent<Ingredient>().Setup(ingredient);
        currentPizza.AddIngredient(newIng, 1);
        Debug.Log("add ingredient to current pizza");
    }

    public void Finished()
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
            if (currentScore == 25)
            {
                // TODO: Implement "You are now CEO" screen before making this work.
                PlayerPrefs.SetInt("HighScore", currentScore);
            }
        }
        else // The pizzas are not equal.
        {
            wrongOrders++;

            int prevScore = PlayerPrefs.GetInt("HighScore");
            if (prevScore < currentScore)
                PlayerPrefs.SetInt("HighScore", currentScore);
            currentScore = 0;

            if (wrongOrders == 3)
            {
                // TODO: Implement "You're fired" screen before making this work.

            }
            currentScoreView.text = currentScore.ToString();
        }
        // Generate next pizza.
        Destroy(expectedPizza);
        GeneratePizza();
    }
}