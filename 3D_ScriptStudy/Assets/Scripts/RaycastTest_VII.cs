//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Raycast kisica onumuzdeki objeye bir lazer tutup ondan bilgi almak icin kullanilir.
//Özellikle fps oyunlarinda mermi gibi kullanilabilir. Merbi icin bir raycast olusturulur ve oyuncuya degiyorsa -10 birim can azaltilir.

public class RaycastTest_VII : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            makeRayCast();
        }
    }

    private void makeRayCast()
    {
        RaycastHit hit;
        int range = 10;     //Ray menzili.

        Debug.DrawRay(transform.position, transform.forward * range, Color.cyan);
        //Bu kod ray cizmemize olanak tanir.

        if(Physics.Raycast(transform.position,transform.forward,out hit, range))
        {
            Debug.Log("Hit another object! " + hit.transform.name);
        }
    }
}
