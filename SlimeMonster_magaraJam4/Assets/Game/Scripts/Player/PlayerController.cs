using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Game.Scripts.Player;
using TMPro;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _characterController;

        [SerializeField] private float speed = 10f;
        [SerializeField] private float turnSmoothTime = 0.1f;

        private float turnSmoothVelocity;

        public bool isMoving = false;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"))
                .normalized;

            if (direction.magnitude >= 0.1f)
            {
                isMoving = true;
                Rotate(direction);
                _characterController.Move(direction * speed * Time.deltaTime);
                
            }
            else
            {
                isMoving = false;
            }
        }

        private void Rotate(Vector3 direction)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f,angle,0f);
        }
        
        
    }    
}

