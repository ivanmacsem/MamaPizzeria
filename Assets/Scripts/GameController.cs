using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private Pizza expectedPizza;
    public bool gameOver = false;
    private bool timeUp = false;
    private int seconds = 0;
    private float timer = 0.0f;
    private bool checking = false;
    private Ingredient first = null;
    private Ingredient second = null;
    private Ingredient third = null;
    private int currentScore = 0, wrongOrders = 0;
    [SerializeField] PizzaSlot currPizza;
    [SerializeField] Text currentScoreView = null;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Image curClock;
    [SerializeField] Sprite[] clock = new Sprite[13];
    [SerializeField] Text orderList = null;
    [SerializeField] Text qList = null;
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
        string[] ingList = { "Arugula", "Basil", "Ham", "Chicken", "Pepperoni", "Supreme Mix", "Mushrooms" };
        string actualList = "";
        string quantityList = "";
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] > 0){
                actualList += string.Format("{0}\n", ingList[i]);
                quantityList += string.Format("{0}\n", quantities[temp[i]]);
            }
        }
        orderList.text = actualList;
        qList.text = quantityList;
    }
    void Update(){
        currentScoreView.text = currentScore.ToString();
        timer += Time.deltaTime;
        if(!gameOver && !checking){
            seconds = ((int)(timer % 60));
            curClock.sprite = clock[seconds];
        }
        if(seconds == 12){
            if(!timeUp){
                Finished();
                timeUp = true;
            }
        }
        else{
            timeUp = false;
        }
    }
    public void Finished(){
        StartCoroutine(Finish(1f));
    }
    public IEnumerator Finish(float pauseDuration){
        checking = true;
        yield return new WaitForSeconds(pauseDuration);
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
            currentScore++;
            if (wrongOrders > 0)
                wrongOrders = 0;
            if (currentScore == 5)
            {
                winScreen.SetActive(true);
                gameOver = true;
            }
        }
        else
        {
            currentScore = 0;
            wrongOrders++;
            if (wrongOrders == 3)
            {
                loseScreen.SetActive(true);
                gameOver = true;
                //update high score
            }
        }
        if(!gameOver){
            timer = 0;
            GeneratePizza();
            checking = false;
        }
    }
}