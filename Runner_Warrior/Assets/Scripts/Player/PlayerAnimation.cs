using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();        
    }


    void OnCollisionEnter2D(Collision2D hedef)
    {
        if (hedef.gameObject.tag == "Engel")
        {
            anim.Play("idle");
        }
    }

    void OnCollisionExit2D(Collision2D hedef)
    {
        if (hedef.gameObject.tag == "Engel")
        {
            anim.Play("run");
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
