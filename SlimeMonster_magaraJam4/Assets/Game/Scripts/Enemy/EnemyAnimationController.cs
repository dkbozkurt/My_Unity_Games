using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<EnemyBehaviour>().isDead = true;
            KillAfterSec(0.5f);
        }
    }

    public void AttackAnim(bool status)
    {
        _animator.SetBool("attack",status);
    }

    public void MoveAnim(bool status)
    {
        _animator.SetBool("move",status);
    }

    private void KillAfterSec(float t)
    {
        StartCoroutine(Do());
        IEnumerator Do()
        {
            yield return new WaitForSeconds(t);
            Destroy(gameObject);
        }
        
    }

}
