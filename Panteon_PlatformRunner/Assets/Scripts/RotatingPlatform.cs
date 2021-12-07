// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private float speed = -50f;

    private void FixedUpdate()
    {
        // Blue Rotating Obstacle
        if(this.gameObject.name.Equals("RotatingPlatform1"))
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
        // Yellow Rotating Obstacle
        else if (this.gameObject.name.Equals ("RotatingPlatform2") ) 
        {
            transform.Rotate(0f, 0f, speed * Time.deltaTime);
        }
        // Purple Rotating Obstacle
        else if (this.gameObject.name.Equals ("RotatingPlatform3"))
        {
            transform.Rotate(0f, 0f, 2* speed * Time.deltaTime);
        }
    }
}