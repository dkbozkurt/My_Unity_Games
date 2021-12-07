using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private AudioClip jumpclip;

    public float jumpForce = 12f, rightforce = 0f;

    private Rigidbody2D myRigidBody;

    private bool canJump;

    private Button JumpBtn;


    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        JumpBtn = GameObject.Find("Jump Button").GetComponent<Button>();
        JumpBtn.onClick.AddListener(() => Jump());
    }

    public void Jump()
    {
        if (canJump)
        {
            canJump = false;
            if (transform.position.x < 0)
            {
                rightforce = 1f;

            }
            else
            {
                rightforce = 0;
            }

            myRigidBody.velocity = new Vector2(rightforce, jumpForce);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(myRigidBody.velocity.y) == 0)
        {
            canJump = true;
        }
       
    }
}
