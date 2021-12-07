//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial_IV : MonoBehaviour
{
    MeshRenderer myMeshRenderer;

    public Material mymaterial;
    Material oldmaterial;
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        oldmaterial = myMeshRenderer.material;        //Orjinal materyalini bu sayede saklıyoruz.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        //Eger E tusuna basilirsa materyale assagidakini uygular.
        //GetKey -> Basili tutuldugu surece.
        //GetKeyDown -> Basildigi anda demek.
        //GetKeyUp -> Elimizi cektigimiz zaman.
        {   
            myMeshRenderer.material = mymaterial;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        //Eger kullanici elini E tusundan cektiyse.
        {
            myMeshRenderer.material = oldmaterial;      //Kullanici elini tustan cektiyse eski materyalini update ettik.
        }
        if (Input.GetMouseButtonDown(0))
        //Kullanici sol mouse buttonuna basarsa.
        {
            Instantiate(gameObject);        //Sahnede ayni objeden bir tane daha üretir.
        }
        if (Input.GetButton("Run"))
        //Eger run tusuna basildiysa.
        {
            Debug.Log("Run");
        }
    }
}
