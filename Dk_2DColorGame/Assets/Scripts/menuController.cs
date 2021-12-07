//Dogukan Kaan Bozkurt 
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
     
    public void quitGame()
    {
        Debug.Log("QUIT !");
        Application.Quit();
    }
}
