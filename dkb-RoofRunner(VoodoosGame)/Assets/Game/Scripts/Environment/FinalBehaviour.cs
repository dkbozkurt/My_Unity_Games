using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    private bool _isRestartable;
    [SerializeField] private CinemachineVirtualCamera vcam;


    private void Update()
    {
        if (_isRestartable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<SwerveMovement>().enabled = false;
            other.transform.GetChild(2).gameObject.SetActive(false);
            other.transform.GetChild(0).gameObject.GetComponent<PlayerModelAnimBehaviour>().DanceAnim();
            other.transform.LookAt(Vector3.back);
            var transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset.z = +8.223f;
            endScreen.SetActive(true);
            _isRestartable = true;
            
        }
    }
    
    
}
