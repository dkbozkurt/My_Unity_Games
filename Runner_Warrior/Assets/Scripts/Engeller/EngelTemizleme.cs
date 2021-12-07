using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelTemizleme : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hedef)
    {
        if(hedef.tag == "EngelTemizleyici")
        {
            gameObject.SetActive(false);
        }
    }
    
        
    }