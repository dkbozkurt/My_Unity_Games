using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAnimController : MonoBehaviour
{
    private void Update()
    {
        if (transform.GetChild(0).GetComponent<ObstacleBehaviour>().deactivateAnims)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}
