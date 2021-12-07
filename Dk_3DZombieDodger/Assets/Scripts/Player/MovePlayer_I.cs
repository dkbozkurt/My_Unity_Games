//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

//Karakter w,a,s,d ile hareket ettirilmesi ile ilgili script.

//Karakterin baktigi yon ile w,a,s,d kordinatlarinin entegre edilmesi.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer_I : MonoBehaviour
{
    private int speed = 10;
    const float gravity = 9.8f;

    CharacterController characterController;
    Vector3 moveVector;
    void Start()
    {
        //Buradaki func playerin charcont eristik.
        characterController = GetComponent<CharacterController>();      
    }


    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        //Bir vektor tanımladık. Ve bunun x,z sini girdiyi klavyeden verip hız ve smooth gecis icin ayarladik.
        //Buradaki Time.deltaTime : iki frame arında gecen sureyi verir ve smooth bir hareket elde etmemizi sagladi.
        moveVector = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,Input.GetAxis("Vertical") * speed * Time.deltaTime);

        //Normalde karakterimizi hep dunyanin x ve y eksenlerinde yurut diyorduk yuzunun nereye baktigiyla ilgilenmiyorduk.
        //Fakat alt satirdaki kod ile kafasinin baktigi yonde yani global rotation degil local rotation da yurutebiliriz.
        moveVector = transform.TransformDirection(moveVector);

        //Assagidaki if func ile karakterimizin ucmasini engelledik.
        //Eger karakter yere temas etmiyorsa:
        if (!characterController.isGrounded)
        {
            //Zamana bagli olarak yercekimini buna hafif hafif uygula taki zemine gelene kadar.
            moveVector.y -= Time.deltaTime * gravity;
        }

        //Olusturdugumuz vectori move func ile x,y,z eksenlerinde w,a,s,d ile hareket ettilmesini sagladik.
        characterController.Move(moveVector);
        //Eger karakterimin yercekiminden etkilenmesini de istiyorsak ustteki func alttaki gibi yazilabilir fakat bu durumda ZIPLAMA YAPILAMAZ!!!
        //characterController.SimpleMove(moveVector);

    }
}
