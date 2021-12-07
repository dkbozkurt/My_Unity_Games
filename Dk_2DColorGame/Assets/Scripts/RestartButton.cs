//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //We should import for scene management.

public class RestartButton : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Restart the game.
        HealthBar.totalHealth = 3;
        Time.timeScale = 1;
        HealthBar.mscore = 0;   //
    }

    public void mainMenu()      //For turning back to main menu.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}