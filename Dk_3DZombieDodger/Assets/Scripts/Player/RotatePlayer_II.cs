//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

// Mousemiz ile birlike cameranin(oyuncunun) donmesi icin gereken script.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer_II : MonoBehaviour
{
    private float sensitivity = 4;
    //Note:farkli bir eksene farkli sensivity degeri verilebilirdi.

    private float rotateY=0;
    private float rotateX=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayerBody();
    }

    private void RotatePlayerBody()
    {
        //Mousenin eksenini al, bu degeri rotasyon verisine ekle.
        //+= e dikkat!, -1 olma sebebi, unityde y mouse hareketinin defaultu ters olmasi.
        rotateY += sensitivity * Input.GetAxis("Mouse Y")*-1;       //degeri ters geliyor defaultta.
        rotateX += sensitivity * Input.GetAxis("Mouse X");

        //Bu kodun yaptigi sey rotateX i belirlenen aralikta tutmaya yarar.
        rotateY = Mathf.Clamp(rotateY, -80, 80);

        //Su anki transformumun rotasyonunu mousedan aldigi verilerle birlestir ve bu hale getir.
        //Kisaca yaptigi is editordeki rotation bolumune sayi eklemek bu sayede donmesini saglamak.
        transform.eulerAngles = new Vector3(rotateY, rotateX,0);
    }
}
