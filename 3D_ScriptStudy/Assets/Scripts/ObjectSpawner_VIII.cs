//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_VIII : MonoBehaviour
{
    public GameObject boxObject;
    List<GameObject> boxes = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(2))    //Middle click.
        {
            Spawn();
        }
        else if (Input.GetKeyDown("r"))
        {
            DestroyObject();
        }
    }

    private void Spawn()
    {
        Vector3 randPosition = new Vector3(UnityEngine.Random.Range(-25, 25), UnityEngine.Random.Range(2,10), UnityEngine.Random.Range(-25,25));   
        //parantez icerisindeki x y z nin rasgele belirlenen konumunda bir pozisyon ver. Pozisyon olusturduk.

        GameObject box = Instantiate(boxObject,randPosition,Quaternion.identity);        //Objemi gidip o random pozisyonda default rotation da olustur.
        boxes.Add(box);         //Olusturulan objeyi listte tutuyoruz.
    }

    private void DestroyObject()
    {
        Destroy(boxes[boxes.Count - 1]);        //Olusturulan son box i yok et.
        boxes.RemoveAt(boxes.Count-1);        //Silinen son elemanin indexini bu sayede sildik ve range kuculdu.
    }

}
