//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;        //For TextMesh Pro. (we can use: using UnityEngine.UI; for Normal Unity UI Text)
using UnityEngine.UI;

public class Ball_Movement : MonoBehaviour
{

    public Rigidbody2D ball;        //main ball
    public float jump_pow;

    ///Color variables
    public Color DarkBlueColor, BlueColor, RedColor, PinkColor;
    public string currentColor;
    //
    public SpriteRenderer ballArtist;
    //
    public Transform colorSwapper;      //We can call ColorSwapper.position if ColoSwapper is Transform type.
    public Transform loseCatch;         //If the ball fades away from the camera view, it will work.
    //
    public Text scoreBoard;         //The variable holds "Score :" info. on the screen
    public int score;
    //
    public Text endMessage;     //working together with endPanel and health variables.
    //
    public AudioSource jumpVoice;
    //
    public GameObject lvlGenerator;
    public GameObject lvlGenerator2;
    public GameObject lvlGenerator3;
    public GameObject lvlGenerator4;

    //
    private int j = 0;
    void Start()
    {
        RandomColor();      //Initial randomcolor assigment.
        lvlGenerator3.SetActive(false);
        lvlGenerator4.SetActive(false);
    }
    void Update()
    {

        scoreBoard.text = "Score : " + score;       //Writing the score value on a variable for the screen.

        if(Input.GetKeyDown (KeyCode.Mouse0))        //Action key from the user.
        {
            ball.velocity = Vector2.up * jump_pow;      //Jump formula of the ball.
            jumpVoice.Play();
        }

        endMessage.text = "Game Over ! \n Highest Score : "+HealthBar.mscore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D touch)
    {
        if(touch.tag != currentColor && touch.tag != "SwapColor" )
        {
            if (HealthBar.mscore < score)   
            {
                HealthBar.mscore = score;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Resets the game when the ball hits an obstacle.
            HealthBar.totalHealth--;
        
        }

        if(touch.tag == "SwapColor")
        {
            //When ColorSwapCircle triggered, out score will be increasing.
            score++;
            //We can use below function to relocation variables location by adding a value to it's y-position.
            colorSwapper.position = new Vector3(colorSwapper.position.x, colorSwapper.position.y + 8, colorSwapper.position.z);
            loseCatch.position = new Vector3(loseCatch.position.x, loseCatch.position.y + 8, loseCatch.position.z);//
            //Destroy(touch.gameObject);      //Touched object will be destroyed.
            RandomColor();
            generatorControl();
        }

    }
    void RandomColor()      //Random color function.
    {
        int randomnum = Random.Range(0, 4);
       
        switch(randomnum)
        {
            case 0:
                currentColor = "DarkBlue";
                ballArtist.color = DarkBlueColor;
                break;

            case 1:
                currentColor = "Red";
                ballArtist.color = RedColor;
                break;

            case 2:
                currentColor = "Blue";
                ballArtist.color = BlueColor;
                break;

            case 3:
                currentColor = "Pink";
                ballArtist.color = PinkColor;
                break;
        }
    }

    void generatorControl()
    {
        j++;
        switch (j)
        {
            case 1:
                lvlGenerator.SetActive(false);
                lvlGenerator3.SetActive(true);
                break;

            case 2:
                lvlGenerator2.SetActive(false);
                lvlGenerator4.SetActive(true);
                break;

            case 3:
                lvlGenerator3.SetActive(false);
                break;

            case 4:   
                lvlGenerator4.SetActive(false);
                break;
        }
    }
}
