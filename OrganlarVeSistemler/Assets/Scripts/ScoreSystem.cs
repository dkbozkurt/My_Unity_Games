//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//GEFEASOFT

/* Game Over screen. Depends on the points that collected from the game.
 * Result will be shown depends on the score. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    //For TextMeshPro

public class ScoreSystem : MonoBehaviour
{ 
    //Score Text
    public TMP_Text scoreText; 
    
    private int player_score;
    private int numOfOrgans;

    //For GameOver Screen
    [SerializeField] private GameObject gameEndMenu;
    [SerializeField] private TMP_Text gemText;

    [SerializeField] private GameObject rotateButton;
    [SerializeField] private GameObject negRotateButton;

    [SerializeField] private AnimationManager animationManager;

    [SerializeField] private GameObject systemsTable;
    public int getScore() { return player_score; }
    public void setScore(int score) { 

        player_score += score;

        //Function block score to go below zero.
        if (player_score < 0)
        {
            player_score = 0;
        }
    }

    public int getnumOfOrgans() { return numOfOrgans; }
    public void setnumOfOrgans(int numoo) { numOfOrgans += numoo; }  

    private void Start()
    {
        numOfOrgans = 0;
        player_score = 0;
        scoreText.text = "SKOR : " + player_score;
    }

    //GameEndScreen will pop up when game is ended.
    public void GameEndScreen()
    {
        //WhiteBoard anim
        animationManager.whiteBoardZoom(true);
        animationManager.HumanBodyInOut(false);
        animationManager.DoctorInOut(false);

        systemsTable.SetActive(false);

        negRotateButton.SetActive(false);
        rotateButton.SetActive(false);


        gameEndMenu.SetActive(true);
        if (getScore() >= 1900)
        {
            gemText.text = "HARİKA!!!\n\nHiç hata yapmadan oyunu tamamladın. Organlarımızı ve sistemleri çok iyi tanıyorsun.\nSkorun: " + player_score;
        }
        else if (getScore() >= 1700)
        {
            gemText.text = "TEBRİKLER!!\n\nOrganlara ve sistemlere hakimsin. Gayet başarılısın.\nSkorun: " + player_score;
        }
        else if(getScore() >= 1300)
        {
            gemText.text = "GAYET İYİ\n\nOrganlar ve sistemleri yavaş yavaş çözüyorsun. Pratik yapmaya devam et!\nSkorun: " + player_score;
        }
        else if (getScore() >= 900)
        {
            gemText.text = "İDARE EDER\n\nOrganlar ve sistemlere daha sıkı çalışmalısın.\nSkorun: " + player_score;
        }
        else
        {
            gemText.text = "BAŞARISIZ OLDUN!\n\nTekrar oynayarak kendini geliştirmeyi dene.\nSkorun: " + player_score;
        }

    }

}
