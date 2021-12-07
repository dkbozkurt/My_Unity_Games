// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private Transform target;

    private float smoothSpeed=0.125f;

    // Vector component info for the distance between player and camera
    private Vector3 offset = new Vector3(0,9,-14) ;
    #endregion

    // Used fixed update because we want a small delay on camera when it follows the player.
    private void FixedUpdate()
    {
        // Adding slight delay on camera.
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPosition;

        // If we want to use lookAt func tho.
        //transform.LookAt(target);
    }
}
