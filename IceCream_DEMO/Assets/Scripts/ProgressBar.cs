// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt
//IceCreamDEMO

/* ProgressBar animation
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    #region Variables
    private int min;
    private int max;
    private int current;
    #endregion
    public Image mask;

    private void Start()
    {
        min = 0;
        max = 50;
        current = 0;
    }
    public void setCurrent(int x) { current = x; }
    public void increaseCurrent()
    {
        
        current++;
    }
    public void GetCurrentFill()
    {
        float currentOffset = current - min;
        float maxOffset = max - min;
        float fillAmount = currentOffset / maxOffset;
        mask.fillAmount = fillAmount;
    }
}
