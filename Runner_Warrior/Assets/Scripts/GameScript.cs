using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject PausePanel;

    public Button restartGameButton;

    public Text scoreText, pauseText;

    public int score;

    void Start()
    {
        scoreText.text = score + "M";
        StartCoroutine(ScoreOlustur());

    }

    IEnumerator ScoreOlustur()
    {
        yield return new WaitForSeconds(0.6f);
        score++;
        scoreText.text = score + "M";
        StartCoroutine(ScoreOlustur());
    }


    public void PlayerDiedEndGame()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {
            int highscore = PlayerPrefs.GetInt("Score");
            if (highscore < score)
            {
                PlayerPrefs.SetInt("Score", score);
            }
        }

        pauseText.text = "Game Over";
        PausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0f;
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScreen");
    }


    public void PauseButton()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    
}