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
    public void StartGame()
    {
        gameStarted = true;
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }


}
