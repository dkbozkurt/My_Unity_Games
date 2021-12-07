//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

//Zombielere can verme ve damage durumunda canini azaltma ve oldurme.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth_III : MonoBehaviour
{
    private int startHealth = 100;
    private int currentHealth;

    //Bu func. Zombie AI ye zombie canini gecirebilmek icin yazdik. cunku current health priv.
    public int GetHealth() { return currentHealth; }
    void Start()
    {
        //Zombie baslangic can atamasi yaptik.
        currentHealth = startHealth;
    }

    //Bu func. public olmaliki Shoot scriptinden erisilebilelim.
    public void Hit(int damage)
    {
        //Zombie damage aldiginda canini azalttik.
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            //TODO: Zombie death
            Debug.Log("Zombie is dead!");
        }
        //Shoot scripimin hasar verip vermedigini anlamak icin:
        Debug.Log("Zombie got Shooted! "+currentHealth);
    }
    
}
