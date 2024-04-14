using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float respawnDelay = 3f;
    private bool isGameEnding = false;
    private int score;
    public TMP_Text scoreText;
    public TMP_Text winText;
    public TMP_Text CurrentScoretext;
    public TMP_Text enY�ksekSkortext;
    public GameObject WinnerUI;

    public GameObject[] characters;

    public static int CurrentScore 
    {
        get { return PlayerPrefs.GetInt("CurrentScore_"); }
        set { PlayerPrefs.SetInt("CurrentScore_", value); }
    }
    public void LevelUp()
    {
        // En y�ksek skoru belirle

        int enY�ksekSkor = PlayerPrefs.GetInt("HighScore", score);
        int sahneSkor = PlayerPrefs.GetInt("sahneskor", score);

        // �nceki b�l�mlerde kaydedilen skorlar� topla
        CurrentScore += sahneSkor;
        
        // En y�ksek skoru belirle
        if (CurrentScore > enY�ksekSkor)
        {
            enY�ksekSkor = CurrentScore;
            PlayerPrefs.SetInt("HighScore", enY�ksekSkor);
            PlayerPrefs.Save();
        }

        WinnerUI.SetActive(true);
        winText.text = "Well Done! Score: " + score;
        CurrentScoretext.text = "Score : " + CurrentScore;
        enY�ksekSkortext.text = "High Score : " + enY�ksekSkor;
        Invoke("NextLevel", 2f);
    }

    void Start()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");

        characters[characterIndex].SetActive(true);

        // playerController = FindObjectOfType<PlayerController>();

        foreach (GameObject item in characters)
        {
            if (item.activeSelf==true)
            {
                playerController = item.GetComponent<PlayerController>();
                Camera camera= FindObjectOfType<Camera>();
                camera.GetComponent<CameraController>().playerTransform = item.transform;
                break;
            }
        }
    }
    public void RespawnPlayer()
    {
        if (isGameEnding == false)
        {
            isGameEnding = true;
            StartCoroutine("RespawnCoroutine");
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameEnding = false;
    }
    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = "Score : " + score.ToString();
        PlayerPrefs.SetInt("currentscore", score);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
