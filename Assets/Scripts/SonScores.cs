using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SonScores : MonoBehaviour

{
    public TMP_Text CurrentScoretext;
    public TMP_Text HighScoretext;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public static int CurrentScore
    {
        get { return PlayerPrefs.GetInt("CurrentScore_"); }
        set { PlayerPrefs.SetInt("CurrentScore_", value); }
    }

    public void MükBirMetod()
    {
        CurrentScoretext.text = "Score : " + CurrentScore;
        HighScoretext.text = "High Score : ";
    }


}

