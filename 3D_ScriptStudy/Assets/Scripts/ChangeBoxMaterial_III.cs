//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bir objenin materyalini degistirmek icin gereken script.
public class ChangeBoxMaterial_III : MonoBehaviour
{
    public Material mymaterial;
    void Start()
    {
        //Tek tek objelere yapilmak istenirse;

        /*
        GameObject yellowCube = GameObject.Find("Yellow Cube");
        GameObject greenCube = GameObject.Find("Green Cube");
        //Sahnedeki bir objenin ismini .Find ile bulup onu bir variableye atamak. !!!

        yellowCube.GetComponent<MeshRenderer>().material = mymaterial;
        greenCube.GetComponent<MeshRenderer>().material = mymaterial;
        //cubelerin inspectorundaki meshrenderererdaki materyale erisip onu kendi materyalimize esitledik
        */

        //Tag ile yapilmak istenirse;

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        //Tagi Box olan tum objeleri bulup boxes adindaki bir arrayin icine attik.
        for (int i =0; i < boxes.Length; i++)
        {
            boxes[i].GetComponent<MeshRenderer>().material = mymaterial;
        }

    }

}
