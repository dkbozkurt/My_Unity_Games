//Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//GEFEASOFT

/* Bringing and displaying random organ with its animation
 * (sprites) at a certain point in the scene.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;   //Import to access ui components.
using System.Linq;  //For unique random list.
using TMPro;

public class RandomOrgan : MonoBehaviour
{
    //Organs
    [SerializeField] private GameObject brain;
    [SerializeField] private GameObject kidneys;
    [SerializeField] private GameObject stomack;
    [SerializeField] private GameObject intestines;
    [SerializeField] private GameObject reproductiveOrg;
    [SerializeField] private GameObject gallBladder;
    [SerializeField] private GameObject liver;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject lungs;
    [SerializeField] private GameObject urinaryBladder;

    //Organ Slots
    [SerializeField] private GameObject brainSlot;
    [SerializeField] private GameObject kidneysSlot;
    [SerializeField] private GameObject stomackSlot;
    [SerializeField] private GameObject intestinesSlot;
    [SerializeField] private GameObject reproductiveOrgSlot;
    [SerializeField] private GameObject gallBladderSlot;
    [SerializeField] private GameObject liverSlot;
    [SerializeField] private GameObject heartSlot;
    [SerializeField] private GameObject lungsSlot;
    [SerializeField] private GameObject urinaryBladderSlot;

    [SerializeField] private ScoreSystem scoreSys;

    [SerializeField] private GameObject textObj;    // Displaying name of the organ at the same time
    private TMP_Text textObject;

    //If the organ was not placed in its area bool will be false.
    public bool placedOrgan = false;
    private int totalOrganNum = 10;
    private int orgNumber = 0;

    // Organs and slots list
    private List<int> listOrgans = new List<int>();
    
    //For "Hint System"
    private int dispOrgCode=0;
    private GameObject hintSlot;

    void Start()
    {
        textObject = textObj.GetComponent<TMP_Text>();
        //Generating random numbers at the beginning.
        GenerateRandomOrgCode();
        OrganSelect(listOrgans[orgNumber]);
        
    }

    //If organ placed into a slot, next organ will pop up.
    private void Update()
    {
        if (placedOrgan && orgNumber<totalOrganNum)
        { 
            OrganSelect(listOrgans[orgNumber]);
        }
        //At the end of the game close the popWindow screen.
        if (scoreSys.getnumOfOrgans() == 10)
        {
            this.gameObject.SetActive(false);
            textObj.SetActive(false);
        }
    }

    // To Hint system
    public GameObject getSlotBox() { return hintSlot; }
    public int getOrgNumber() { return orgNumber; }

    //Function will select the random organ.
    public void OrganSelect(int orgCode)
    {
        
        // i(organ) number increased in the list and setting are reseted.
        setRayTrue();
        placedOrgan = false;
        orgNumber++;

        // To transfer code of the organ to hint system.
        dispOrgCode = orgCode;

        switch (orgCode)
        {
            case 1:
                brain.SetActive(true);
                textObject.text = "Beyin";
                hintSlot = brainSlot;
                break;

            case 2:
                kidneys.SetActive(true);
                textObject.text = "Böbrekler";
                intestinesSlot.GetComponent<Image>().raycastTarget = false;
                liverSlot.GetComponent<Image>().raycastTarget = false;
                stomackSlot.GetComponent<Image>().raycastTarget = false;
                gallBladderSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = kidneysSlot;
                break;

            case 3:
                stomack.SetActive(true);
                textObject.text = "Mide";
                intestinesSlot.GetComponent<Image>().raycastTarget = false;
                lungsSlot.GetComponent<Image>().raycastTarget = false;
                heartSlot.GetComponent<Image>().raycastTarget = false;
                liverSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = stomackSlot;
                break;

            case 4:
                intestines.SetActive(true);
                textObject.text = "Baðýrsaklar";
                reproductiveOrgSlot.GetComponent<Image>().raycastTarget = false;
                urinaryBladderSlot.GetComponent<Image>().raycastTarget = false;
                kidneysSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = intestinesSlot;
                break;
            case 5:
                reproductiveOrg.SetActive(true);
                textObject.text = "Yumurtalýk";
                urinaryBladderSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = reproductiveOrgSlot;
                break;
            case 6:
                gallBladder.SetActive(true);
                textObject.text = "Safra Kesesi";
                liverSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = gallBladderSlot;
                break;

            case 7:
                liver.SetActive(true);
                textObject.text = "Karaciðer";
                lungsSlot.GetComponent<Image>().raycastTarget = false;
                stomackSlot.GetComponent<Image>().raycastTarget = false;
                heartSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = liverSlot;
                break;

            case 8:
                heart.SetActive(true);
                textObject.text = "Kalp";
                lungsSlot.GetComponent<Image>().raycastTarget = false;
                hintSlot = heartSlot;
                break;

            case 9:
                lungs.SetActive(true);
                textObject.text = "Akciðerler";
                hintSlot = lungsSlot;
                break;

            case 10:
                urinaryBladder.SetActive(true);
                textObject.text = "Mesane";
                hintSlot = urinaryBladderSlot;
                break;

            default:
                
                break;
            
        }
    }
    
    //Random organ code will generate and define inside a list from the function.
    private void GenerateRandomOrgCode()
    {
        //Adding the list or generating the list
        for (int i = 1; i < totalOrganNum+1; i++)
        {
            listOrgans.Add(i);
        }
        //shuffing or randomization
        listOrgans = listOrgans.OrderBy(tvz => System.Guid.NewGuid()).ToList();
    }

    //Function allows raycast after than each organ matched with its slot.
    private void setRayTrue()
    {
        brainSlot.GetComponent<Image>().raycastTarget = true;
        kidneysSlot.GetComponent<Image>().raycastTarget = true;
        stomackSlot.GetComponent<Image>().raycastTarget = true;
        intestinesSlot.GetComponent<Image>().raycastTarget = true;
        reproductiveOrgSlot.GetComponent<Image>().raycastTarget = true;
        gallBladderSlot.GetComponent<Image>().raycastTarget = true;
        liverSlot.GetComponent<Image>().raycastTarget = true;
        heartSlot.GetComponent<Image>().raycastTarget = true;
        lungsSlot.GetComponent<Image>().raycastTarget = true;
        urinaryBladderSlot.GetComponent<Image>().raycastTarget = true;
    }     
}