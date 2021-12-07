//Dogukan Kaan Bozkurt
//      github.com/dknbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player can scripti.
public class PlayerHealth_VI : MonoBehaviour
{
    private int MaxHealth=100;
    private int currentHealth;
    void Start()
    {
        currentHealth = MaxHealth;

    }
    public int GetHealth() { return currentHealth; }
    public void DeductHealth(int damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log("Player get damage! Current health:"+currentHealth);
        if (currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Debug.Log("Player Died!");
    }

    public void AddHealth(int value)
    {
        currentHealth = currentHealth + value;
        //Eger toplanan can max healthten buyukse max healthi gecmesin.
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
    
}
