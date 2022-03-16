using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{

    [SerializeField] private GameObject childParticle;
    private GameObject _instantiatedObject;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pipe")
        {
            _instantiatedObject = Instantiate(childParticle, other.contacts[0].point, Quaternion.LookRotation(Vector3.back));
        }
        
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Pipe")
        {
            Destroy(_instantiatedObject,0.5f);
        }
    }
}
