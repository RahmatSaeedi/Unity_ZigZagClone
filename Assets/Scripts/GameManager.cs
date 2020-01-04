using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score = 0;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = GetHighScore().ToString();
        
    }
    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadGenerator>().StartBuilding();
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Highscore");
    }

}
