using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// 
/// </summary>

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerController.isMoving)
        {
            Move(true);
            
        }
        else
        {
            Move(false);
        }
    }

    public void Move(bool isMoving)
    {
        _animator.SetBool("move",isMoving);
    }
}
