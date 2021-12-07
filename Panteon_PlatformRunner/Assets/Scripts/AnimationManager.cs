// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    #region Variables
    private Animator animator;
    
    #endregion

    void Start()
    {
        
        animator = GetComponent<Animator>();

        animator.SetBool("jump", false);
        animator.SetBool("run", false);

    }

    public void runAnim(bool runCheck)
    {
        animator.SetBool("run", runCheck);
    }
    public void jumpAnim(bool jumpCheck)
    {
        animator.SetBool("jump", jumpCheck);
    }

       
}
