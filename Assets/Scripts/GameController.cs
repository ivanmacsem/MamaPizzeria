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
        if (equal) // The pizzas are equal.
        {
            Debug.Log("Got it!");
            currentScore++;
            if (wrongOrders > 0)
                wrongOrders = 0;
            if (currentScore == 25)
            {
                // TODO: Implement "You are now CEO" screen before making this work.
            }
            GeneratePizza();
        }
        else // The pizzas are not equal.
        {
            Debug.Log("*donald trump voice* Wrong");
            currentScore = 0;
            wrongOrders++;
            if (wrongOrders == 3)
            {
                // TODO: Implement "You're fired" screen before making this work.
                //update high score
            }
            GeneratePizza();
        }
    }
}