//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest_V : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    //Bir collision bu objenin icine girdigi zaman.
    {
        Debug.Log("Main Obj:" +this.gameObject.name + " hitted by:" + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    //Collision bu objenin carpisma alanindan ciktigi zaman.
    {
        
    }

    private void OnCollisionStay(Collision collision)
    //Objenin icine giren collision hala icerisinde kaldigi/carpistigi sure boyunca.
    {
        Debug.Log(this.gameObject.name + " still in touch with:" + collision.gameObject.name);
    }
}
