using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int score = 50;
    public Text textScore;
    public Text healthScore;
    public playerController playercontroller;
    public float secondsPerHealth = 10;
    public float secondsPerScore = 1;
    public float healthAdded = 10;

    private float addScoreOne = 0;
    private float addHealthOne = 0;


    private void Update()
    {
        AddScoreFromTime();
        AddHealthFromTime();
    }

    public void updateHealth()
    {
        healthScore.text = "Health: " + playercontroller.playerHealth.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        textScore.text = "Score: " + score.ToString();
        Debug.Log(score);
    }

    private void AddScoreFromTime()
    {
        addScoreOne += Time.deltaTime;
        if (addScoreOne >= secondsPerScore)
        {
            AddScore(1);
            addScoreOne = 0;
        }
    }

    private void AddHealthFromTime()
    {
        addHealthOne += Time.deltaTime;
        if(addHealthOne >= secondsPerHealth)
        {
            Debug.Log("add!");
            playercontroller.playerHealth += healthAdded;

            updateHealth();
            addHealthOne = 0;
        }
    }
}
