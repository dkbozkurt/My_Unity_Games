using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlusturma : MonoBehaviour
{
    [SerializeField]

    private GameObject[] engeller;

    private List<GameObject>EngellerListesi= new List<GameObject>();

    private void Awake()
    {
        EngelleriOlustur();
    }

    void Start()
    {
        StartCoroutine(RasgeleEngelOlustur());
    }

    public void EngelleriOlustur()
    {
        int sayi = 0;
        Vector3 lokasyon = new Vector3(transform.position.x, transform.position.y, -2);
        for(int i = 0; i < engeller.Length*3; i++)
        {
            GameObject obje = Instantiate(engeller[sayi], lokasyon, Quaternion.identity) as GameObject;
            EngellerListesi.Add(obje);
            EngellerListesi[i].SetActive(false);
            sayi++;
            if (sayi == engeller.Length)
            {
                sayi = 0;
            }

        

        }
    }


    public void Karistir() {
        for (int i = 0; i < EngellerListesi.Count; i++)
        {
            GameObject temp = EngellerListesi[i];
            int rasgele = Random.Range(i, EngellerListesi.Count);
            EngellerListesi[i] = EngellerListesi[rasgele];
            EngellerListesi[rasgele] = temp;
        }

        

        
    }


    IEnumerator RasgeleEngelOlustur()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));
        int sayi = Random.Range(0, EngellerListesi.Count);

        while (true)
        {
            if (!EngellerListesi[sayi].activeInHierarchy)
            {
                EngellerListesi[sayi].SetActive(true);
                EngellerListesi[sayi].transform.position= new Vector3(transform.position.x, transform.position.y, -2);
                break;
            }
            else
            {
                sayi = Random.Range(0, EngellerListesi.Count);
            }
        }

        StartCoroutine(RasgeleEngelOlustur());

    }


    void Update()
    {
        
    }
}
