// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    // Not to destroy background sound when switching the scenes.
    void Awake()
    {        
        DontDestroyOnLoad(transform.gameObject);            
    }

}
