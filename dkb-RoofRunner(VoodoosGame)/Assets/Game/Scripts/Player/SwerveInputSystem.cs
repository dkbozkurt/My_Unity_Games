using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    void Update()
    {
        InputControl();
    }

    private void InputControl()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;

        }
        else if (Input.GetMouseButton(0) || (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            // Debug.Log("movement:" + _moveFactorX);
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0) || (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            _moveFactorX = 0f;
        }

    }

}
