using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engeller : MonoBehaviour
{
    private float speed = -3f;

    private Rigidbody2D myRigidBody;


    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(speed, 0f);
    }
}
