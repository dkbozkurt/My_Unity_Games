using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SliderPipeBehaviour : MonoBehaviour
{
    private int _numberOfPipes;
    [SerializeField] private CinemachineVirtualCamera vcm;

    private void Start()
    {
        ChangeSliderPipeLenght();
    }

    public void ChangeSliderPipeLenght()
    {
        _numberOfPipes = 0;
        foreach (Transform child in transform.parent.GetChild(2))
        {
            _numberOfPipes++;
        }

        transform.localScale = new Vector3(transform.localScale.x,
            0.15f + (_numberOfPipes*0.1f),
            transform.localScale.z);
        ChangeFieldOfView();

    }

    private void ChangeFieldOfView()
    {
        var remain = 0;
        if (_numberOfPipes > 25)
        {
            remain = _numberOfPipes % 25;    
        }
        
        
        if (remain >0)
        {
            remain = remain / 4;
            vcm.m_Lens.FieldOfView = 60 +remain*5;
        }
        else
        {
            vcm.m_Lens.FieldOfView = 60;
        }
    }
}
