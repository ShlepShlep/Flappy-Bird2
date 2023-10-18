using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();

        var highScore = PlayerPrefs.GetInt("highScore");

        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScoreText.text = highScore.ToString();
    }
}
