using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts.Player
{
    public class PlayerUpgradeBehaviour : MonoBehaviour
    {
        #region ModePercentages

        private float _firePercentage=0f;
        private float _icePercentage=0;
        private float _stonePercentage=0;

        [SerializeField] private ExperienceBarBehaviour expBarFire;
        [SerializeField] private ExperienceBarBehaviour expBarIce;
        [SerializeField] private ExperienceBarBehaviour expBarStone;

        private float percentageMultiplier= 20f;
        
        #endregion

        [SerializeField] private HealthBarBehaviour healthBarBehaviour;
        private float inputAmount = 20f;
        [HideInInspector] public bool _isCollectable= true;
        private PlayerAnimController _playerAnimController;

        private void Start()
        {
            _playerAnimController = GetComponent<PlayerAnimController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckEnemyType(other.gameObject);
            
        }

        private void CheckEnemyType(GameObject enemy)
        {
            switch (enemy.tag)
            {
                case "Fire":
                    _playerAnimController.Size(+1);
                    Fire();
                    healthBarBehaviour.HealthBarUpdate(inputAmount);
                    break;
                
                case "Ice":
                    _playerAnimController.Size(+1);
                    Ice();
                    healthBarBehaviour.HealthBarUpdate(inputAmount);
                    break;
                
                case "Stone":
                    _playerAnimController.Size(+1);
                    Stone();
                    healthBarBehaviour.HealthBarUpdate(inputAmount);
                    break;
                
                case "Shoot":
                    _playerAnimController.Size(-1);
                    healthBarBehaviour.HealthBarUpdate(-inputAmount);
                    Destroy(enemy);
                    break;
                
            }
            
        }

        

        private void Fire()
        {
            if (_isCollectable)
            {
                _firePercentage += percentageMultiplier;
                expBarFire.UpdateFillAmount(_firePercentage);
                if (_firePercentage >= 100f)
                {
                    _firePercentage = 0f;
                    UpgradeModel(1) ;
                }
            }
            
        }

        private void Ice()
        {
            if (_isCollectable)
            {
                _icePercentage += percentageMultiplier;
                expBarIce.UpdateFillAmount(_icePercentage);
                if (_icePercentage >= 100f)
                {
                    _icePercentage = 0f;
                    UpgradeModel(2) ;
                }
            }
            
        }

        private void Stone()
        {
            if (_isCollectable)
            {
                _stonePercentage += percentageMultiplier;
                expBarStone.UpdateFillAmount(_stonePercentage);
                if (_stonePercentage >= 100f)
                {
                    _stonePercentage = 0f;
                    UpgradeModel(3) ;
                }
            }
        }
        
        public void UpgradeModel(int modelIndex)
        {
            foreach (Transform model in transform.GetChild(0))
            {
                model.gameObject.SetActive(false);
            }
            transform.GetChild(0).GetChild(modelIndex).gameObject.SetActive(true);
            
            // Update Particle play
            transform.GetChild(1).gameObject.SetActive(true);
            Wait(0.75f);

        }

        private void Wait(float t)
        {
            StartCoroutine(Do());
            
            IEnumerator Do()
            {
                yield return new WaitForSeconds(t);
                transform.GetChild(1).gameObject.SetActive(false);
                
            }
                
        }
        
        
        
    }
}