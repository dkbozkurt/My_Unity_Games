using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Player;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class HealthBarBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private PlayerAnimController _playerAnimController;
    private float _maxHealth = 100f;
    private float _currentHealth;
    private float _multiplierIndex = 0.05f;
    

    private void Start()
    {
        _currentHealth = 99f;
        _playerAnimController = player.GetComponent<PlayerAnimController>();
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z - (player.transform.localScale.z + 1f));
        
    }
    
    public void HealthBarUpdate(float healAmount)
    {
        _currentHealth += healAmount;

        if (healAmount > 0) PlayerSizeChanger(_multiplierIndex);
        else PlayerSizeChanger(-_multiplierIndex);
        
        

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth <= 0f)
        {
            _currentHealth = 0f;
            _playerAnimController.Die();
            Invoke("GameEnd",2f);
            
        }

            transform.GetChild(0).localScale = new Vector3(_currentHealth / _maxHealth,
            transform.GetChild(0).localScale.y,
            transform.GetChild(0).localScale.z);
    }

    private void PlayerSizeChanger(float value)
    {
        player.transform.localScale = new Vector3(player.transform.localScale.x + value, 
            player.transform.localScale.y + value,
        player.transform.localScale.z +  value);
    }

    private void GameEnd()
    {
        Time.timeScale = 0f;
    }
}
