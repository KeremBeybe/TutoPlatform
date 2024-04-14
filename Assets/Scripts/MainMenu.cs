using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas;
    AnimationScript[] animsc;
    public TMP_Text currentScore;
    public TMP_Text highScore;
    public static int CurrentScore
    {
        get { return PlayerPrefs.GetInt("CurrentScore_"); }
        set { PlayerPrefs.SetInt("CurrentScore_", value); }
    }
    private void Start()
    {
        if (currentScore != null && highScore!= null )
        {
            currentScore.text = "Score : " + CurrentScore.ToString();
            int Yüksekskor = PlayerPrefs.GetInt("HighScore");
            highScore.text = "HighScore : " + Yüksekskor.ToString();
        }
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            animsc = FindObjectsOfType<AnimationScript>();
            canvas.SetActive(true);
            foreach (AnimationScript item in animsc)
            {
                item.enabled = false;
            }
            Time.timeScale = 0;

        }
    }
    
    public void PlayApp()
    {
        int characterIndex =  PlayerPrefs.GetInt("CharacterIndex");
        Debug.Log("CharacterIndex : " + characterIndex);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        CurrentScore = 0;
        
    }

    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("Çýkýþ yapýldý");
    }

    public void BankaiGameDev()
    {
        SceneManager.LoadScene("Me");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameMenu()
    {
        animsc = FindObjectsOfType<AnimationScript>();
        canvas.SetActive(true);
        foreach (AnimationScript item in animsc)
        {
            item.enabled = false;
        }
        Time.timeScale = 0;
    }
    public void GoBackToGame()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        foreach (AnimationScript item in animsc)
        {
            item.enabled = true;
        }
    }

}
