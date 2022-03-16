using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerModelAnimBehaviour : MonoBehaviour
{
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void HangAnimation(bool status)
    {
        _animator.SetBool("hang",status);
        if (status)
        {
            transform.DOLocalMoveY(-0.172f, 0.5f);
        }
        else
        {
            transform.DOLocalMoveY(0.078f, 0.5f);
        }
    }

    public void DieAnimation()
    {
        _animator.SetBool("die",true);
    }

    public void DanceAnim()
    {
        _animator.SetBool("gameEnd",true);
    }
     
}
