// Dogukan Kaan Bozkurt
// github.com/dkbozkurt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    #region Variables
    
    // Agent's navmesh
    private NavMeshAgent agent;

    // Number of destination points
    private int dotNumber;

    // Destination point's location information in an array
    [SerializeField] private GameObject[] destinationPoints;

    // pathFollow functions referance variables
    private Vector3 walkPoint;
    private bool walkPointSet;

    // End Menu
    [SerializeField] private GameObject endMenu;

    // Queue Components 
    [SerializeField] private Transform playerTr;
    private bool oppHead;

    #endregion

    #region Scipts
    [SerializeField] private AnimationManager animMan;
    [SerializeField] private QueuePvsOpp orderScript;
    #endregion

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        // Focused checkpoints information attempt as a walk point.
        dotNumber = 0;
        walkPoint = destinationPoints[dotNumber].transform.position;
        walkPointSet = true;

        // End menu component
        endMenu.SetActive(false);

        // Opponents starts behind of the player
        oppHead = false;

    }

    private void Update()
    {
        // Opponents need to follow a path
        pathFollow();

        // If opponent falls restart the game
        if (this.transform.position.y < -15)
        {
            // +10 for y axis (falling effect)
            this.transform.position = new Vector3(Random.Range(-13, 13), 10, Random.Range(-7, 5));

            // Reseting the character's rotation.
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        }

        // Jump animation cancellation
        if (this.transform.position.y > 0.1f)
            animMan.jumpAnim(true);
        else
            animMan.jumpAnim(false);
                
        // Order detection section
        orderCheck();

    }

    private void pathFollow()
    {
        if (!walkPointSet)
        {
            // If checkpoint number achived stop the opponent.
            if(dotNumber == 8)
            {
                animMan.runAnim(false);
                animMan.jumpAnim(false);

            }
            // If not search for next destination point
            else
                SearchWalkPoint();
        }
        // If we have a walkpoint and didnt arrive there, move opponent to the point
        else if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            animMan.runAnim(true);
        }

        // Distance between the opponent and the destination point
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached and we are ready to look for a new destination point from the array.
        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }       
        
    }

    // Destination point founder
    private void SearchWalkPoint()
    {
        dotNumber++;
        walkPoint = new Vector3(Random.Range(destinationPoints[dotNumber].transform.position.x - 10,destinationPoints[dotNumber].transform.position.x + 10),
            destinationPoints[dotNumber].transform.position.y, destinationPoints[dotNumber].transform.position.z);
        walkPointSet = true;
        
    }

    // Calculate the queue in the game [depends on locations of player and opponent]
    private void orderCheck()
    {
        if (!oppHead && this.transform.position.z < playerTr.position.z)
        {
            orderScript.orderChangeAnim(false);
        }
        else if(!oppHead && this.transform.position.z > playerTr.position.z)
        {
            ChangeState();
            orderScript.orderChangeAnim(true);
        }    
        else if (oppHead && this.transform.position.z < playerTr.position.z)
        {
            ChangeState();
            orderScript.orderChangeAnim(true);
        }
        else if (oppHead && this.transform.position.z > playerTr.position.z)
        {
            orderScript.orderChangeAnim(false);
        }            

    }

    // Player's order number will be determined in this function depends on the Opponents heading situation
    private void ChangeState()
    {
        if (!oppHead)
        {
            oppHead = true;
            orderScript.setOrder(1);
        }
        else
        {
            oppHead = false;
            orderScript.setOrder(-1);
        }
            
    }

    // If opponent hits and obstacle restart the opponents location
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OBSTACLE")
        {
            this.transform.position = new Vector3(Random.Range(-13, 13), 10, Random.Range(-7, 5));
            /*
            dotNumber = 0;
            walkPoint = destinationPoints[dotNumber].transform.position;
            walkPointSet = true;
            */
        }
    }

    // Opponent wins the game
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "endLine2")
        {
            Debug.Log("You lose!");
            Time.timeScale = 0f;
            endMenu.SetActive(true);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        
        // For rotating platforms - We are making our player as a child object of the platform
        if (collision.gameObject.tag == "RotatingPlatform") //collision.gameObject.name.Equals ("denemerotating")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        // When the player exits the obstacle, we remove it from the child object position.
        if (collision.gameObject.tag == "RotatingPlatform")
        {
            this.transform.parent = null;
        }
    }

}
