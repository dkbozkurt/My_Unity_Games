using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class DiamondCollector : MonoBehaviour
{
    private int _collectedDiamonds=0;
    public int CollectedDiamonds { get => _collectedDiamonds; set => _collectedDiamonds = value; }

    public void IncreaseDiamonds()
    {
        CollectedDiamonds++;
        transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = CollectedDiamonds.ToString();
        
    }

}
