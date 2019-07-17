using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private static Text scoreText;
    private static float score;

    private static Text ballsLeftText;
    private static float ballsLeft;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        score = 0;
        AddScore(score);

        ballsLeftText = GameObject.FindGameObjectWithTag("BallLeftText").GetComponent<Text>();
        ballsLeft = ConfigurationUtils.BallsPerGame;
        RemoveBall(0);
    }

    void Update()
    {
        
    }

    public static void AddScore(float point)
    {
        score += point;
        scoreText.text = "Score: " +  score.ToString();
    }

    public static void RemoveBall(float ballNum)
    {
        ballsLeft -= ballNum;


        if (ballsLeftText) {
            ballsLeftText.text = "Balls Left: " + ballsLeft.ToString();
        }
        
    }
}
