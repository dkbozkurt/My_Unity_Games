using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// 
/// </summary>

public class PlayerAnimController : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _animator.SetInteger("size",0);
    }
    
    public void Size(int number)
    {
        _animator.SetInteger("size",number);

        StartCoroutine(Do(0.05f));
        IEnumerator Do(float t)
        {
            yield return new WaitForSeconds(t);
            _animator.SetInteger("size",0);
        }
        
    }

    public void Die()
    {
        _animator.SetBool("die",true);
        _playerController.enabled = false;
    }
}
