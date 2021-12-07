// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    #region Variables
    private Rigidbody otherRB;

    // Game objects and speed values are just example. (if we want to use scripts instead of animations)

    // [SerializeField] private GameObject hObs;
    // ...
    // [SerializeField] private GameObject rotatorObs;
    // ...
    //[SerializeField] private GameObject halfDonutObs;
    // ...
    // private float horizontalObstacleSpeed = 50f;
    // private float halfDonatSpeed = 50f;
    // private float rotatorSpeed = 50f;

    #endregion

    #region Scripts
    [SerializeField] private SoundHandler soundH;
    #endregion

    // NOTE: I used animations for "horizontal obstacles", "Rotator and sticks" and "half donut obstacles".
    // If we want to use scripts instead of animations for obstacles, we can adjust the following functions and activate in the update function.
    void Update()
    {
        // (Need to be edited depends on the obs) (I prefered to use animations instead)
        #region Example Functions for Obstacles 
        // Horizontal Obstacle
        // transform.position += (velocity * Time.deltaTime);
        // ...

        // Rotator and Sticks
        // rotatorObs.transform.Rotate(0f, rotatorSpeed * Time.deltaTime, 0f);
        // ...

        // Half Donut Obstacle
        // halfDonutObs.transform.Rotate(halfDonatSpeed * Time.deltaTime, 0f, 0f);
        // ...
        #endregion

    }

    private void OnTriggerEnter(Collider player)
    {
        
        //Debug.Log("You got hit by an obstacle!");
        otherRB = player.attachedRigidbody;

        // Player Die sound
        if (player.tag=="Player")
            soundH.PlayDie();

        // Spawns the player from the beginning platform, randomly.
        otherRB.position = new Vector3(Random.Range(-13, 13), 10, Random.Range(-7, 5));
        
    }
}
