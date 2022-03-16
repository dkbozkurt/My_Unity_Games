using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 
/// </summary>
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float stopDistance = 8f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float _timer = 0F;
    [SerializeField] private float attackCoolDown = 4f;
    private  bool attackAvailable = false;
    private string destinationTag = "Player";
    public bool isDead = false;
    
    private GameObject _goalGameObject;
    NavMeshAgent agent;

    private ShootBehaviour _shootBehaviour;
    private EnemyAnimationController _enemyAnimationController=null;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _goalGameObject = GameObject.FindGameObjectWithTag(destinationTag).gameObject;
        gameObject.transform.LookAt(_goalGameObject.transform);
        _shootBehaviour = GetComponent<ShootBehaviour>();
        
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
    }
    
    void Update()
    {
        EnemyWalkBehaviour();
        Attack();
        if (gameObject.transform.position.y <= -5F)
        { Destroy(gameObject); }

        if (!isDead)
        {
            gameObject.transform.LookAt(_goalGameObject.transform);
            _enemyAnimationController.MoveAnim(true);
        }
        else
        {
            _enemyAnimationController.MoveAnim(false);
        }
    }
    

    private void EnemyWalkBehaviour()
    {
        agent.stoppingDistance = stopDistance;
        agent.speed = speed;
        agent.destination = _goalGameObject.transform.position;
    }
    private void Attack()
    {
        if (!attackAvailable)
        {
            _enemyAnimationController.AttackAnim(false);
            _timer += Time.deltaTime;

            if (_timer >= attackCoolDown)
            {
                _timer = 0f;
                attackAvailable = true;
            }

        }
        if (attackAvailable)
        {
            _enemyAnimationController.AttackAnim(true);
            _shootBehaviour.Shoot(gameObject);
            attackAvailable = false;

        }
    }
    
}
