using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreCounter : MonoBehaviour
{

    public static HighScoreCounter counterInstance;

    public Text highScore;
    //public Text highScoreMenu;

    private void Update()
    {
        UpdateHighScore();
    }


    // Start is called before the first frame update
    void Start()
    {
        counterInstance = this;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        //highScoreMenu.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void UpdateHighScore()
    {
        if (Scoring.scoringInstance.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Scoring.scoringInstance.score);
            highScore.text = "High Score: " + Scoring.scoringInstance.score.ToString();
        }
    }

}