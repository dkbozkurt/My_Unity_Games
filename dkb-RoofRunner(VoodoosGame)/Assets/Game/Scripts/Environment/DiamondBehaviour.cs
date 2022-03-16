using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DiamondBehaviour : MonoBehaviour
{
    private float _initialYValue;
    [SerializeField] private GameObject diamondSprite;
    private DiamondCollector _diamondCollector;

    private void Start()
    {
        _diamondCollector = GameObject.Find("DiamondCollector").GetComponent<DiamondCollector>();
        _initialYValue = transform.position.y;
        RotateDiamond();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "SlidePipe")
        {
            Collect();
        }
    }

    private void RotateDiamond()
    {
        transform.DORotate(new Vector3(0, -360, 0), 5f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    private void Collect()
    {
        _diamondCollector.IncreaseDiamonds();
        gameObject.SetActive(false);
        
    }
}
