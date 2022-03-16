using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject gameStartScreen;
    
    private void Start()
    {
        GameStart();
    }

    private void GameStart()
    {
        inGamePanel.SetActive(false);
        gameStartScreen.SetActive(true);
        
        Time.timeScale = 0;
    }

    public void PlayButtonPressed()
    {
        inGamePanel.SetActive(true);
        gameStartScreen.SetActive(false);
        
        Time.timeScale = 1;
        
    }
}
