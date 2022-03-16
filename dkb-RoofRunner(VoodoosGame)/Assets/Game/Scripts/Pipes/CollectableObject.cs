using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PipeDirection
{
    Null,Right,Left
}

public class CollectableObject : MonoBehaviour
{
    
    private bool _isCollected;
    private int _index;
    private PipeDirection _pipeSide;
    public bool IsCollected { get => _isCollected; set => _isCollected = value; }
    public int Index { get => _index; set => _index = value; }
    
    public PipeDirection PipeSide { get => _pipeSide; set => _pipeSide = value; }

    public void LocateCollectableObject(int positionMultiplier)
    {
        if (transform.parent != null)
        {
            transform.localPosition = new Vector3(transform.localScale.y * positionMultiplier * (2*Index+1), 0f, 0f);
        }
        
    }
    
}
