//Dogukan Kaan Bozkurt
//github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject endMenu;

    [SerializeField] private Animator scoreIncrease;
    #endregion

    #region Scripts
    [SerializeField] private SoundHandler soundH;
    #endregion

    void Start()
    {
        scoreText.text = "  0 %";
        endMenu.SetActive(false);
        scoreIncrease.SetBool("increase", false);
    }

    public void ChangeScore(int dyedCube)
    {
        scoreText.text = "  " + dyedCube.ToString()+ " %";
        scoreIncrease.SetBool("increase",true);
        soundH.PlayIncrease();
    }

    public void endTheGame()
    {
        endMenu.SetActive(true);
        soundH.PlayEndGame();
    }

    private void LateUpdate()
    {
        scoreIncrease.SetBool("increase", false);
    }
}
