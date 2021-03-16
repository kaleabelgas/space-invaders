using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private int score = 0;
    public Text textScore;
    public Text healthScore;
    public playerController playercontroller;


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
}
