//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mermi izi silme kodu.
//[Baska objeleri silme icinde kullanabiliriz.] !!!

public class DeleteObj_VIII : MonoBehaviour
{
    //Kac sn sonra izler oyundan silinsin

    private float time=3;
    void Start()
    {
        //time kadar sure sonra uzerine attigim objeyi siler.
        Destroy(gameObject, time);
    }

    void Update()
    {
        
    }
}
