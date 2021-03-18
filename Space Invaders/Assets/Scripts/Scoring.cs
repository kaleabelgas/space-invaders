using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static Scoring scoringInstance;
    public playerController plcontroller;

    public int score = 0;
    public Text textScore;
    public Text healthScore;
    public float secondsPerHealth = 10;
    public float secondsPerScore = 1;
    public float healthAdded = 10;

    private float addScoreOne = 0;
    private float addHealthOne = 0;

    private void Start()
    {
        scoringInstance = this;
    }

    private void Update()
    {
        AddScoreFromTime();
        AddHealthFromTime();
    }

    public void updateHealth()
    {
        healthScore.text = "Health: " + plcontroller.playerHealth.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        textScore.text = "Score: " + score.ToString();
        //Debug.Log(score);
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
            plcontroller.playerHealth += healthAdded;

            updateHealth();
            addHealthOne = 0;
        }
    }
}
