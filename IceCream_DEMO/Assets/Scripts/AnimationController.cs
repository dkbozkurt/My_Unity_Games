// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//IceCreamDEMO

/* Animation control script of the flowing cream.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetBool("Flow", false);
    }
    public void StartFlow()
    {
        animator.SetBool("Flow", true);
    }

    public void StopFlow()
    {
        animator.SetBool("Flow", false);
    }
    

}
