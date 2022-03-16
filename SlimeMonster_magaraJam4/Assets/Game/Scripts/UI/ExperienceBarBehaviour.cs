using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class ExperienceBarBehaviour : MonoBehaviour
{

    [SerializeField] private PlayerUpgradeBehaviour _playerUpgradeBehaviour;
    private Image expBar;
    
    private float _maxFillAmount = 100f;

    private void Start()
    {
        expBar =transform.GetChild(1).gameObject.GetComponent<Image>();
    }

    public void UpdateFillAmount(float increaseAmount)
    {
        if (_playerUpgradeBehaviour._isCollectable)
        {
            expBar.fillAmount = increaseAmount / _maxFillAmount;
            
            if (expBar.fillAmount >= 1f)
            {
                expBar.fillAmount = 1f;
                _playerUpgradeBehaviour._isCollectable = false;
                WaitForTime(5f);
            }
        }

    }

    private void WaitForTime(float t)
    {
        StartCoroutine(Do());
        IEnumerator Do()
        {
            yield return new WaitForSeconds(t);
            expBar.fillAmount = 0f;
            _playerUpgradeBehaviour._isCollectable = true;
            _playerUpgradeBehaviour.UpgradeModel(0);
        }
    }
    
}
