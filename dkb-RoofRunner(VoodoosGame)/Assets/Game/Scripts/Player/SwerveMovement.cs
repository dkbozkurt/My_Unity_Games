using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SwerveInputSystem))]
public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    
    
    #region Swerve along x-axis

    private float swerveAmount;
    [SerializeField] private float swerveSpeed = 1f;
    [SerializeField] private float maxSwerveAmount = 1f;

    #endregion

    #region Movement in the y-axis

    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private GameObject slidingParticle;
    
    public float ForwardSpeed { get => _forwardSpeed; set => _forwardSpeed = value; }

    #endregion
    
    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
        slidingParticle.SetActive(false);
    }
    
    private void Update()
    {
        MoveOnX();
        MoveOnY();
    }
    
    private void MoveOnX()
    {
        swerveAmount = Time.deltaTime* swerveSpeed* _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount,-maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount,0,0);
    }

    private void MoveOnY()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z + ForwardSpeed * Time.deltaTime);
    }

    public void ForwardSpeedChange(float boostValue,bool isSliding)
    {

        DOTween.To(() => ForwardSpeed, x => ForwardSpeed = x, boostValue, 1f);
        slidingParticle.SetActive(isSliding);
    }
    
}
