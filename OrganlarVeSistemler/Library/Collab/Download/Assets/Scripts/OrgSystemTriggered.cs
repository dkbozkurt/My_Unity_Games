//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//GEFEASOFT

/* Main code of the game, Checking if the organ's 
 * collider is same as the systems.Depends on the 
 * situation, behave as a head of the other scripts.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrgSystemTriggered : MonoBehaviour
{   
    // To check how many system is the organ touching. there should be only 1 system that organ should collide to get point
    public static int numberofTouchedSystem; 
    //when you placed the organ to the right placethis  variable changed as +1, to sync if check in onTriggerStay this variable created.
    public static int numberofPlacedOrgans; 
        
    [SerializeField] private Transform tpTarget;

    //Scripts are assigned to variables
    [SerializeField] private ScoreSystem scoreSys;
    [SerializeField] private CorrectOrganName cOrgName;
    [SerializeField] private SoundHandler sh;   
    [SerializeField]private ScoreAnimControl ac;

    private bool mouseUpped=false;

    private void Start()
    {
        //initialization of static variables.
        numberofTouchedSystem = 0;
        numberofPlacedOrgans = 0;
    }

    //Check the mouse down and up to set mouseUpped bool correctly.
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            mouseUpped = true;
        }
        else if (Input.GetMouseButtonDown(0)) mouseUpped = false;
        //Debug.Log(numberofTouchedSystem);
    }

    private void OnTriggerEnter(Collider other)
    {
        //increase # of organs touched to the system
        OrgSystemTriggered.numberofTouchedSystem++;
    }

    private void OnTriggerExit(Collider other)
    {
        //decrease # of organs touched to the system
        OrgSystemTriggered.numberofTouchedSystem--;
    }

    //When an organ entered an system's area
    public void OnTriggerStay(Collider organ)
    {
        ac.Check(0);
        
        //if(mouseUpped) Debug.Log("triggered and mouse upped");
        //if organ release into the correct organ system 
        if (this.gameObject.tag == organ.gameObject.tag && mouseUpped && numberofTouchedSystem == numberofPlacedOrgans+1) 
        {
            Destroy(organ.gameObject);
            
            //Plays the correct auido.
            sh.PlayCorrect();
            //Debug.Log("Organ: " + this.gameObject.name + "\n Organ system: " + organ.gameObject.name + "\n It is Correct!");

            //Sets the score and display it on the scoresys.
            scoreSys.setScore(100);
            scoreSys.scoreText.text = "SKOR: " + scoreSys.getScore();

            //For animation play in the scoreboard
            ac.Check(1);
            
            //Counts the total organs that collected by organ systems.
            scoreSys.setnumOfOrgans(1);
           
            //Display if the organ name in the organ system if organ is correct
            cOrgName.DisplayCorrectName(organ.gameObject,this.gameObject.tag);

            //Checks if total number of organs end.
            if (scoreSys.getnumOfOrgans()==19)    
            {
                scoreSys.GameEndScreen();
            }

            //to stay synced with if checks
            numberofPlacedOrgans++;

        }
        else if (this.gameObject.tag != organ.gameObject.tag && mouseUpped && numberofTouchedSystem == numberofPlacedOrgans+1)
        {
            
            //Debug.Log("Organ: " + this.gameObject.name + "\n Organ system: " + organ.gameObject.name + "\n It is Wrong!");

            //Plays the wrong audio
            sh.PlayWrong();

            //Sets the score and display it on the scoresys.
            scoreSys.setScore(-50);
            scoreSys.scoreText.text = "SKOR: " + scoreSys.getScore();

            //Animation stops when anser is wrong
            ac.Check(2);
            
            //Line for respawn the organ at the middle of the scene 
            organ.transform.position = tpTarget.transform.position;

            //We can use simply as following too.
            //organ.transform.position = new Vector3(0, 2.5f, -3);
        }
        else if(mouseUpped && numberofTouchedSystem >  numberofPlacedOrgans+1 )
            organ.transform.position = tpTarget.transform.position;
    } 
    
}
