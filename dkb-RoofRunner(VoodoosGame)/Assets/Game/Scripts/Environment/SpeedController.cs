using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SlidePipe")
        {
            if (other.transform.parent.TryGetComponent(out SwerveMovement swerveMovement))
            {
                //other.gameObject.GetComponent<SliderPipeBehaviour>().ChangeSliderPipeLenght();
                if (gameObject.tag == "EndLine")
                {
                    swerveMovement.ForwardSpeedChange(15f,true);
                    other.transform.parent.GetChild(0).GetComponent<PlayerModelAnimBehaviour>().HangAnimation(true);
                }
                    
                else if (gameObject.tag == "StartLine")
                {
                    swerveMovement.ForwardSpeedChange(5f,false);
                    other.transform.parent.GetChild(0).GetComponent<PlayerModelAnimBehaviour>().HangAnimation(false);
                }
                    
            }
        }
    }
}
