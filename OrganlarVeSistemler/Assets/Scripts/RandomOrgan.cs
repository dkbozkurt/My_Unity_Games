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

    //If the organ was not placed in its area bool will be false.
    public bool placedOrgan = false;
    private int totalOrganNum = 10;
    private int orgNumber = 0;
    private List<int> listOrgans = new List<int>();

    void Start()
    {
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
        }
    }

    //Function will select the random organ.
    public void OrganSelect(int orgCode)
    {
        setRayTrue();
        placedOrgan = false;
        orgNumber++;

        switch (orgCode)
        {
            case 1:
                brain.SetActive(true);
                
                break;

            case 2:
                kidneys.SetActive(true);
                intestinesSlot.GetComponent<Image>().raycastTarget = false;
                liverSlot.GetComponent<Image>().raycastTarget = false;
                stomackSlot.GetComponent<Image>().raycastTarget = false;
                gallBladderSlot.GetComponent<Image>().raycastTarget = false;
                break;

            case 3:
                stomack.SetActive(true);
                intestinesSlot.GetComponent<Image>().raycastTarget = false;
                lungsSlot.GetComponent<Image>().raycastTarget = false;
                heartSlot.GetComponent<Image>().raycastTarget = false;
                liverSlot.GetComponent<Image>().raycastTarget = false;

                break;
            case 4:
                intestines.SetActive(true);
                reproductiveOrgSlot.GetComponent<Image>().raycastTarget = false;
                urinaryBladderSlot.GetComponent<Image>().raycastTarget = false;

                break;
            case 5:
                reproductiveOrg.SetActive(true);
                urinaryBladderSlot.GetComponent<Image>().raycastTarget = false;

                break;
            case 6:
                gallBladder.SetActive(true);
                liverSlot.GetComponent<Image>().raycastTarget = false;

                break;

            case 7:
                liver.SetActive(true);
                lungsSlot.GetComponent<Image>().raycastTarget = false;

                break;
            case 8:
                heart.SetActive(true);
                lungsSlot.GetComponent<Image>().raycastTarget = false;

                break;
            case 9:
                lungs.SetActive(true);

                break;
            case 10:
                urinaryBladder.SetActive(true);

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