//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Cleaner : MonoBehaviour
{
    public static bool obs_check = false;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag=="ObsCleaner")   //When the object is triggered with the Obstacle, it makes passive the obs.
        {
            gameObject.SetActive(false);
            obs_check = true;
        }
  
    }
}
