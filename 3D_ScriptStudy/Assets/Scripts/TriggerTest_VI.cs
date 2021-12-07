//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest_VI : MonoBehaviour
{
    public MeshRenderer targetMeshRenderer;
    public Material activeMaterial;
    Material oldMaterial;

    private void OnTriggerEnter(Collider other)
    //Belirli bir collider alanına girdigi an bu function calisir.
    {
        oldMaterial = targetMeshRenderer.material;
        targetMeshRenderer.material = activeMaterial;
    }

    private void OnTriggerExit(Collider other)
    //Belirli bir collider alanından cıkıldıgı an bu func. calisir.
    {
        targetMeshRenderer.material = oldMaterial;
    }
}
