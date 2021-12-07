// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//IceCreamDEMO

/* Items and states that buttons will control when they are activated.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    
    #region Scripts
    [SerializeField] private AnimationController animControl;
    [SerializeField] private IceCreamFilling iceCreamF;
    [SerializeField] private ScoreCalculator scoreSystem;
    [SerializeField] private ProgressBar progressB;
    #endregion

    #region Cream's color swap
    [SerializeField] private Renderer cream;
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    #endregion

    #region Variables
    private bool pointerDown;
    private string currentState;
    private int sceneNum;
    #endregion

    #region Buttons and Scenes
    [SerializeField] private GameObject gameEndScene;
    [SerializeField] private GameObject gameEndSceneButton;

    [SerializeField] private GameObject gameStartScene;

    [SerializeField] private GameObject redButton;
    [SerializeField] private GameObject greenButton;

    [SerializeField] private GameObject progressBar;
    [SerializeField] private GameObject progressBarMask;

    [SerializeField] private GameObject guest1;
    [SerializeField] private GameObject guest2;

    public TMP_Text scoreText;
    #endregion

    void Start()
    {
        pointerDown = false;
        currentState = null;

        gameEndScene.SetActive(false);
        gameStartScene.SetActive(true);
        redButton.SetActive(false);
        greenButton.SetActive(false);

        progressBar.SetActive(false);
        guest1.SetActive(false);
        guest2.SetActive(false);

        sceneNum = 0;

    }
       
    void FixedUpdate()
    {
        
        if (iceCreamF.getCurrentLayer() == 50)
        {
            EndScreen();
        }
        else if (pointerDown && currentState == "red")
        {
            iceCreamF.Fill(red,0);
        }
        else if (pointerDown && currentState == "green")
        {
            iceCreamF.Fill(green,1);
        }
        
    }
    
    public void DefaultState()
    {
        pointerDown = false;
        animControl.StopFlow();
    }

    public void RedB()
    {
        pointerDown = true;

        currentState = "red";
        animControl.StartFlow();
        cream.material.color = red.color;
        
    }

    public void GreenB()
    {
        pointerDown = true;

        currentState = "green";
        animControl.StartFlow();
        cream.material.color = green.color;
       
    }
    
    // Scenes;
    public void PlayGame()
    {
        gameStartScene.SetActive(false);
        redButton.SetActive(true);
        greenButton.SetActive(true);

        progressBar.SetActive(true);
        guest1.SetActive(true);

        iceCreamF.setCurrentLayer(0);
        iceCreamF.groundTruthScene(1);
        sceneNum++;
    }

    public void Play2ndGame()
    {
        gameEndScene.SetActive(false);
        progressBarMask.SetActive(false);
        progressBar.SetActive(true);
        guest2.SetActive(true);
        sceneNum++;
        
    }

    public void EndScreen()
    {
        animControl.StopFlow();
        gameEndScene.SetActive(true);

        progressBar.SetActive(false);
        guest1.SetActive(false);
        guest2.SetActive(false);

        scoreText.text = "% " + scoreSystem.getCorrects();

        progressB.setCurrent(0);
        pointerDown = false;
        iceCreamF.ResCream();
        iceCreamF.setCurrentLayer(0);
        iceCreamF.groundTruthScene(2);   
        scoreSystem.ResCorrects();

        if (sceneNum == 2)
        {
            gameEndSceneButton.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 
}
