using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Text highScoreTextView = null;
    [SerializeField] Button reset = null;
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTextView.text = highScore.ToString();
        if(highScore == 0){
            reset.interactable = false;
        }
    }

    public void ResetScores(){
        PlayerPrefs.SetInt("HighScore", 0);
        highScoreTextView.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Quit(){
        Application.Quit();
    }
}
