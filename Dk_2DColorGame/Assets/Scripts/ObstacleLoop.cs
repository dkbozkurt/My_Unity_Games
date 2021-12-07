//Dogukan Kaan Bozkurt
//Dk_2DColorGame

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLoop : MonoBehaviour
{
    public float speed = -3f;
    private Rigidbody2D myRigidBody;
 
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
     void Start()
    {
        
    }
    void Update()
    {
        myRigidBody.velocity = new Vector2(speed, 0f);
       
        
    }
}
