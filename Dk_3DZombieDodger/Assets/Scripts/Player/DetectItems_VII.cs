//Dogukan Kaan Bozkurt
//      github.com/dknbozkurt

//Playerin yerde duran ogeleri toplamasi icin script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItems_VII : MonoBehaviour
{
    //Playere can eklemek icin playerhealth scriptini import ettik.
    PlayerHealth_VI playerHeath;
    void Start()
    {
        //Playerhealthe erisim icin.
        playerHeath = GetComponent<PlayerHealth_VI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Eger carptigim objenin tagi uyusuyorsa bunlari yap.
        if (other.CompareTag("HealthItem"))
        {
            playerHeath.AddHealth(10);
            //Yerden toplanan elmanin yok olmasi icin gerekli kod. (Is triggered secili olmali)
            other.gameObject.SetActive(false);

            Debug.Log("Current Health increased! Current health:" + playerHeath.GetHealth());
        }
    }
}
