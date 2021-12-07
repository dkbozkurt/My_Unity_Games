// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//IceCreamDEMO

/* Score calculation due to groundTruth and input.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private IceCreamFilling iceCreamF;

    private int corrects;

    void Start()
    {
        corrects = 0;
    }

    public void ResCorrects()
    {
        corrects = 0;
    }
    public void setCorrects()
    {
        corrects++;
    }

    public int getCorrects() { return corrects *2; }

}
