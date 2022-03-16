using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform _buttonStartTextTransform;
    private bool _canShrink = false;

    private void Start()
    {
        _buttonStartTextTransform = transform.GetChild(0).GetChild(0);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        player.GetComponent<SwerveMovement>().enabled = false;
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        player.GetComponent<SwerveMovement>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        if(transform.GetChild(0).gameObject.activeSelf)
            ScaleText();        
    }

    private void ScaleText()
    {
        if(!_canShrink)
        {
            _buttonStartTextTransform.localScale =
                _buttonStartTextTransform.localScale + new Vector3(0.2f, 0.2f, 0.2f) * Time.unscaledDeltaTime;
            if (_buttonStartTextTransform.localScale.x >= 1f) _canShrink = true;
        }
        else if (_canShrink)
        {
            _buttonStartTextTransform.localScale =
                _buttonStartTextTransform.localScale - (new Vector3(0.2f, 0.2f, 0.2f) * Time.unscaledDeltaTime);
            if (_buttonStartTextTransform.localScale.x <= 0.7f) _canShrink = false;
        }

    }
}
