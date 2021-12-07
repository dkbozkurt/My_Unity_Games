//Dogukan Kaan Bozkurt
//github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    #region Variables

    // Basic player variables
    private float moveSpeed=7;
    private Rigidbody playerRB;
    private Transform playerTr;


    // Jumping
    private bool touch;
    private float jumpVelocity = 7;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;

    // Turning n direction
    private float turnSmoothTime = 0.1f;
    private float turnSmoothV;

    // Particle Systems
    [SerializeField]private ParticleSystem dustEffect;
    [SerializeField]private ParticleSystem jumpEffect;

    // End Scene for vs10
    [SerializeField] private GameObject endMenu;
    #endregion

    #region Scripts
    [SerializeField] private AnimationManager animMan;
    [SerializeField] private SoundHandler soundH;
        
    #endregion

    void Start()
    {
        // Connection between player and ground
        touch = false;

        // Player's components information
        playerRB = GetComponent<Rigidbody>();
        playerTr = GetComponent<Transform>();

        // End menu ll be closed at the begginning.
        endMenu.SetActive(false);

    }

    void Update()
    {
        // Default key settings for player's movement
        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        
        // Jump settings
        #region Jump

        // Jump
        if (Input.GetButtonDown("Jump") && touch)
        {
            playerRB.velocity = Vector3.up * jumpVelocity;

            // Jump animation function
            animMan.jumpAnim(true);

            // Jump audio will be played
            soundH.PlayJump();            
        }
        // End the jump
        else if (!Input.GetButtonDown("Jump") && touch)
        {
            animMan.jumpAnim(false);
        }
                
        // Better jumping: depends on holding space bar
        if(playerRB.velocity.y<0)
        {
            playerRB.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y >0 && !Input.GetButton("Jump"))
        {
            playerRB.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        #endregion

        // Run and IDLE animations control unit
        // Particle system will be played in this section
        #region IDLE & Run & Particle System

        // If character on the ground,moving and jump button pressed
        if (playerRB.velocity.magnitude > 0.5f && Input.GetButtonDown("Jump") && touch)
        {
            animMan.jumpAnim(true);
            animMan.runAnim(false);
            soundH.PlayJump();

            // Jump Effect will be played at the begginnig of jumping
            JumpEffect();
        }
        // Character moving and on the ground
        else if (playerRB.velocity.magnitude > 0.5f && touch)
        {
            animMan.runAnim(true);

            // Dust particles will play if player touches the ground and runs
            CreateDust();
        }
        // Character is stoped.
        else if(playerRB.velocity.magnitude < 0.5f)
        {
            animMan.runAnim(false);            
        }

        #endregion

        // Direction (Looking way)
        #region Player direction

        // Vectoral information of the character
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // If characters direction force increased, character will look at that side.
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothV, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        #endregion

        // Player fall - restart
        if (playerTr.position.y < -15)
        {
            // +10 for y axis (falling effect)
            playerTr.position = new Vector3(Random.Range(-13,13), 10, Random.Range(-7,5));

            // Reseting the character's rotation.
            playerTr.rotation = new Quaternion(0f, 0f, 0f,0f);

            // Die sound
            soundH.PlayDie();
                        
        }
    }

    // If player touching the ground, he can jump
    // Note: I have changed oncollisionenter to oncollisionstay because of some bugs occured, that blocks jumping.
    #region Touch Check
   
    private void OnCollisionStay(Collision collision)
    {
        touch = true;

        // For rotating platforms - We are making our player as a child object of the platform
        if (collision.gameObject.tag == "RotatingPlatform") //collision.gameObject.name.Equals ("denemerotating")
        {
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        touch = false;

        // When the player exits the obstacle, we remove it from the child object position.
        if (collision.gameObject.tag =="RotatingPlatform")
        {
            this.transform.parent = null;
        }
    }
    #endregion

    #region Particle Funcs.
    void CreateDust()
    {
        dustEffect.Play();        
    }

    void JumpEffect()
    {
        jumpEffect.Play();
    }

    #endregion

    // Game ends if the player reaches to end platform
    private void OnCollisionEnter(Collision collision)
    {
        // When player reaches the last platform 2nd game will be loaded.
        if (collision.gameObject.tag == "endLine")
        {
            Debug.Log("Win!!!");
            
            SceneManager.LoadScene("Game2");

            soundH.PlayEndGame();
        }

        // If the player wons the game [for 1vs10]
        if (collision.gameObject.tag == "endLine2")
        {
            Debug.Log("Win!!!");

            endMenu.SetActive(true);
            Time.timeScale = 0f;

            soundH.PlayEndGame();
        }
    }
}
