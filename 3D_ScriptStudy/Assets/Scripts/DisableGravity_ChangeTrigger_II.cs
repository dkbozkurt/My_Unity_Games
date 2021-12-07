//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGravity_ChangeTrigger_II : MonoBehaviour
{
    Rigidbody rigidbody;
    Collider collider;      //Box collider, colliederden türedigi icin kalitimdan oturu onun tipine cevirebiliyoruz.

    public bool _Gravity=true;       //Kullanici tarafindan unity uzerinde belirlenecek aktif&pasif hali variablesi.
    public bool _isTrigger=false;     

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();      //Bu scriptin ekli oldugu objenin ustundeki rigitbodyi getir.
        rigidbody.useGravity = _Gravity;       //Gravity ayarini degistirmek icin kullanilir.

        collider = GetComponent<Collider>();        //Bu scriptin ekli oldugu objenin ustundeki collideri getir.
        collider.isTrigger = _isTrigger;        //Objenin diger objelerle etkilesime gecip gecmemesi ayari.
    }

    void Update()
    {
        
    }
}
