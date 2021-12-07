//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

//Ates etme ve hasar scripti.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_IV : MonoBehaviour
{
    //Disaridan bir camera aldik raycastte kullanilmak uzere. Public olmaliki playerimin silahini vereyim.
    public Camera camera;
    private int range;

    //Mermi ve sarjor ile ilgili variableler.
    public int defaultAmmo = 120;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;

    //Taramali icin cooldown suresi verdik bu sayede mermiler arasi zaman gecmesi gerekecek
    private float coolDown = 0.07f;
    float lastFireTime = 0;

    //Random titreme icin variable.
    int minAngle = -2;
    int maxAngle = 2;

    //Inspectorda public ogeleri kullanirken kullaniciya su sekilde bilgi verilebilir:
    [Header("Gun Damage On Hit")]
    public int damage;

    //Efektler vs icin gerekli variableler.
    public GameObject bloodPrefab;      //Kan
    public GameObject decalPrefab;        //Mermi izi

    //Silah ucundaki ates animasyonu icin.
    public ParticleSystem muzzleParticle;

    //Sarjor goruntusu icin obje
    public GameObject magObject;

    void Start()
    {
        //Baslangicta sarjordeki mermi sayisi ve sarjor icindeki sayi
        currentAmmo = defaultAmmo-magSize;
        currentMagAmmo = magSize;

    }

    void Update()
    {
        //Eger r tusuna basildiysa reload yap.
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        //Ates ediliyor mu diye kontrol.
        if (Input.GetMouseButton(0))
        {
            //Ates edilebilecek sartlar saglaniyorsa ates etsin.
            if (CanFire())
            {
                Fire();
            }
            
        }
        
    }
    
    //Sarjor yenileme func.
    private void Reload()
    {
        //mermi hic yokken veya sarjor doluyken sarjor degistirmesin.
        if (currentAmmo ==0 || currentMagAmmo == magSize)
        {
            return;
        }
        //Toplamda 30 dan az mermi kaldiysa isler farkli olacagindan bu if onun icin var.
        if(currentAmmo<magSize)
        {
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentAmmo=0;
        }
        else
        {
            //Bu satir sayesinde reload yaparken sarjorde kalan mermiler bosa gitmez.
            currentAmmo -= magSize - currentMagAmmo;

            currentMagAmmo = magSize;
        }
        //Silahimizin ustundeki obje bolumune verdigimiz objeyi(mag) instantiate edip yere düsürür her sarjor degistirdiginde.
        GameObject newMagObject =Instantiate(magObject);
        //Karakterimizin colliderine carptigi icin dusen sarjor hatali olusuyor o yuzden instantiate konumunu degistirdik.
        newMagObject.transform.position = magObject.transform.position;
        //Yere dusen sarjor fiziklerden etkilensin diye rigidbody ekledik.
        newMagObject.AddComponent<Rigidbody>();
    }

    private bool CanFire()
    {
        //Eger mermim varsa ve bekleme suresi gectiyse ates et.
        //Eger son ates etme suresinin uzerinden coolDown sure gecmediyse ates edemez. !!!
        if (currentMagAmmo > 0 && lastFireTime +coolDown< Time.time)
        {
            lastFireTime = Time.time+coolDown;       //son ates etme zamanini tekrardan suanki zaman + cool downa atadik.
            return true;
        }
        
        return false;
        

    }

    //Gercekte bir ates yapmak yerine, yani mermi olusturup firlatip carptirmak yerine raycast ile bunu daha kolay hallederiz. !!!
    private void Fire()
    {
        //her ates ettiginde silah ucundaki animasyonun alt partickleleriyle beraber oynat.
        muzzleParticle.Play(true);

        //Siah ateslendiginde sarjorden mermi azalt
        currentMagAmmo -= 1;
        Debug.Log(currentMagAmmo + " bullet remain!");

        RaycastHit hit;
        //Cameranin transformundan(konumundan), cameranin forwardina bir isik gonder. carpma bilgisini hite aktar ve menzilini belirle. !!!
        if (Physics.Raycast(camera.transform.position,camera.transform.forward, out hit,50))
        {
            //Carptigi objenin tagi zombi ise func. a gir.
            if (hit.transform.tag == "Zombie")
            {
                //Zombinin transformundan, ZombieHealth_III scriptini bul ve ona damage kadar hasar ver.
                hit.transform.GetComponent<ZombieHealth_III>().Hit(damage);

                //Eger carptigimiz obje zombie ise kan efektini calistiriyoruz.
                GenerateBloodEffect(hit);
            }
            else
            {
                //Eger carptigimiz obje zombie degil ise mermi izi efektini calistiriyoruz.
                GenerateHitEffect(hit);
            }
        }
        //Silahimiza min ve max tanimladigimiz acilar arasinda titreme vermek icin gereken satir. .
        transform.localEulerAngles = new Vector3(UnityEngine.Random.Range(minAngle,maxAngle), UnityEngine.Random.Range(minAngle, maxAngle), UnityEngine.Random.Range(minAngle, maxAngle));

    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        //Mermi izi prefabini, vurdugum noktada, vurdugum konumun default rotationunda instatiate ettik.
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);

        //!!! Vurdugumuz noktanın ilerisini(forwardini), o noktanin normaline(yuzeye dik) cevirme kodu kisaca A vektorunu B vektorune kadar cevir diyoruz. 
        // Kodda -1 olma sebebi materyalimizin backwardinin gorunur olmasi bir bakima goruntuyu cevirdik.
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward*-1, hit.normal);
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        //PREFAB DIRECT KULLANILAMAZ O YUZDEN ONCE INTANTIATE ETMELIYIZ.

        //Kan prefabini, vurdugum noktada, vurdugum objenin rotasyonuna gore instatiate ettik.
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
        //Ustteki satirdan sonra takip eden satirlara gerek yok.

        //bu prefabin transformunu pozisyonu, atesin carptigi noktadir.
        //bloodPrefab.transform.position = hit.point; 
        //Hit zombiye carptiginda bu prefabi aktif et.
        //bloodPrefab.SetActive(true);
        
    }
}
