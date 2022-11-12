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
    [SerializeField] PizzaSlot currPizza;
    [SerializeField] Text currentScoreView = null;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Text orderList = null;
    void Start()
    {
        PlayerPrefs.SetInt("curScore", 0);
        expectedPizza = gameObject.AddComponent<Pizza>();
        first = gameObject.AddComponent<Ingredient>();
        second = gameObject.AddComponent<Ingredient>();
        third = gameObject.AddComponent<Ingredient>();
        GeneratePizza();
    }

    private void GeneratePizza()
    {
        first.Setup(Random.Range(0,6));
        second.Setup(Random.Range(0,6));
        third.Setup(Random.Range(0,6));
        expectedPizza.resetPizza();
        expectedPizza.AddIngredient(first, 1);
        expectedPizza.AddIngredient(second, 1);
        expectedPizza.AddIngredient(third, 2);
        UpdateIngredientList();
    }

    private void UpdateIngredientList()
    {
        string[] quantities = { null, "1/4", "1/2", "3/4" };
        int[] temp = expectedPizza.GetPizza();
        string[] ingList = { "arugula", "Basil", "Ham", "Chicken", "Pepperoni", "Supreme Mix", "Mushrooms" };
        string actualList = "";
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] > 0)
                actualList += string.Format("{0} {1}\n", quantities[temp[i]], ingList[i]);
        }
        orderList.text = actualList;
    }
    void Update(){
        currentScoreView.text = currentScore.ToString();
    }
    public void Finished(){
        bool equal = true;
        int[] temp = currPizza.pizza.GetPizza();
        int[] temp2 = expectedPizza.GetPizza();
        for(int i = 0; i<temp.Length; i++){
            if(temp[i] != temp2[i]){
                equal = false;
                break;
            }
        }
        if (equal)
        {
            Debug.Log("Got it!");
            currentScore++;
            if (wrongOrders > 0)
                wrongOrders = 0;
            if (currentScore == 5)
            {
                winScreen.SetActive(true);
            }
            GeneratePizza();
        }
        else
        {
            Debug.Log("*donald trump voice* Wrong");
            currentScore = 0;
            wrongOrders++;
            if (wrongOrders == 3)
            {
                loseScreen.SetActive(true);
                //update high score
            }
            GeneratePizza();
        }
    }
}