//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ballPosition;

    void Update()
    {
        if (ballPosition.position.y > transform.position.y)      //If ball's location greater than camera's location on y-axis.
        {
            transform.position = new Vector3(transform.position.x, ballPosition.position.y, transform.position.z);

        }
        
    }
}
