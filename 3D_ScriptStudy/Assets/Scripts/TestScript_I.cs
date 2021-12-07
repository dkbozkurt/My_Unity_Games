//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript_I : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake executed!");
    }

    // Start is called before the first frame update
    void Start()        
    {
        Debug.Log("Start executed!");       //Console da bu mesaji bastirir.
        
    }

    //Obje baslangicta yada deactive den active konuma geçerse bu calisir.
    private void OnEnable()     
    {
        Debug.Log("On Enable executed!");
    }

    // Update is called once per frame
    void Update()       
    {
        Debug.Log("Update executed!");
    }

    //Her frameden sonra calisir fakat updateden hemen sonra calisir.
    private void LateUpdate()       
    {
        Debug.Log("Late Update executed!");
    }

    //Belirli araliklar ile calisan update mesela 0.15sn. Fiziksel islemler icin kullanilan update cesidi.
    private void FixedUpdate()
    {
        Debug.Log("Fixed Update executed!");
    }

    //Obje bitiste yada active den deactive konuma geçerse bu calisir.
    private void OnDisable()
    {
        Debug.Log("On Disable executed!");
    }
}
