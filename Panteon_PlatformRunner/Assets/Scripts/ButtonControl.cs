// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    #region Variables and objects

    private bool pauseButtonPressed;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    #endregion
    private void Awake()
    {
        pauseButtonPressed = false;
    }

    // To make sure buttons are on
    void Start()
    {
        playButton.SetActive(true);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResume();
        }
    }

    #region Scenes and UI menus
    public void PlaySingle()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void PlayMulti()
    {
        SceneManager.LoadScene("Game 3");
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

        // When we click menu, music shouldnt open second time so we destroy.
        GameObject bcksound = GameObject.FindGameObjectWithTag("bcksound");
        Destroy(bcksound);
    }
    public void PauseResume()
    {
        if (!pauseButtonPressed)
        {
            
            pauseButtonPressed = true;
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

        }
        else if (pauseButtonPressed)
        {
            
            pauseButtonPressed = false;
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

    }
    #endregion


}
