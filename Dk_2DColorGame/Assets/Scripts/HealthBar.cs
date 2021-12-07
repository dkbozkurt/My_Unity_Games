//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //
    public static int totalHealth = 3;
    public Text healthBarMsg;
    //
    public GameObject endPanel;
    //
    public static int mscore = 0;   //  //Max score of the game stores here.
    
    void Update()
    {
        healthBarMsg.text = "Health : " + totalHealth.ToString();

        if (totalHealth == 0)
        {
            //by using SetActive, we can adjust if the object will be active or passive at that moment.
            endPanel.SetActive(true);
            //timeScale helps to adjust game speed. 0 is freeze, 1 is normal.
            Time.timeScale = 0; //We stop the game when we dont have any health left.

        }
    }
}
