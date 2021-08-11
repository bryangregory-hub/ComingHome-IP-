/******************************************************************************
Author: Elyas Chua-Aziz
Name of Class: PatrolAI.cs
Description of Class: Controls the behaviour of the patrolling AI.
Date Created: 17/07/21
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PatrolAI : MonoBehaviour
{
    // Have an Idle and a Patrolling state
    // In Idle state, it will stand still for a few seconds, before changing to Patrolling
    // In Patrolling state, it will move towards a defined checkpoint.
    // After it reaches the checkpoint, go back to Idle state.

    /// <summary>
    /// This stores the current state that the AI is in
    /// </summary>
    /// 
    [Header("Enemy stats")]
    public string currentState;

    /// <summary>
    /// This stores the next state that the AI should transition to
    /// </summary>
    public string nextState;

    /// <summary>
    /// The time that the AI will idle for before patrolling
    /// </summary>
    [SerializeField]
    private float idleTime;

    /// <summary>
    /// The NavMeshAgent component attached to the gameobject
    /// </summary>
    private NavMeshAgent agentComponent;

    /// <summary>
    /// The array holding the checkpoints
    /// </summary>
    [SerializeField]
    private Transform[] checkpoints;

    /// <summary>
    /// Used as the index to access from the checkpoints array
    /// </summary>
    private int currentCheckpoint;

    /// <summary>
    /// The current player that is being seen by the AI
    /// </summary>
    private Transform playerToChase;
    /// <summary>
    ///  This is to check if this is a patrol or a child ai
    /// </summary>
    [SerializeField]
    public int enemyDmg;
    
    public Text following;

    Animator animator;

    public float e_slow;
    [Header("Player")]
    public SamplePlayer player;
    public float _pHealth;
    [Header("Robot")]
    public  bool Child;

    private bool isColide = true;

    private void Awake()
    {
        // Get the attached NavMeshAgent and store it in agentComponent
        agentComponent = GetComponent<NavMeshAgent>();

        /// <summary>
        ///  helps identify if the obj is a child and set speed to 3

    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the starting state as Idle
        nextState = "Idle";
        animator = GetComponent<Animator>();

        _pHealth = player.GetComponent<SamplePlayer>().playerHealth;
        if (Child == true)
        {
            GetComponent<NavMeshAgent>().speed = 3f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the AI should change to a new state
        if (nextState != currentState)
        {
            // Stop the current running coroutine first before starting a new one.
            StopCoroutine(currentState);
            currentState = nextState;
            StartCoroutine(currentState);
        }
        if (Child == true)
        {
            
            following.text = "-Get the robot out with you robot is currently " + (currentState);

        }
        if (animator.GetBool("IsAttack"))
        {
            GetComponent<NavMeshAgent>().speed = 0;
        }
        else if (animator.GetBool("IsRunning"))
        {
            GetComponent<NavMeshAgent>().speed = 4;
        }
    }


    /// <summary>
    /// Used to tell the AI that it sees a player
    /// </summary>
    /// <param name="seenPlayer">The player that was seen</param>
    public void SeePlayer(Transform seenPlayer)
    {
        // Store the seen player and change the state of the AI
        playerToChase = seenPlayer;
        nextState = "Following";
        if (Child == true)
        {
            animator.SetBool("IsAlone", true);
        }


    }

    /// <summary>
    /// Used to tell the AI that it lost the player
    /// </summary>
    public void LostPlayer()
    {
        // Set the seen player to null
        playerToChase = null;
        if (Child == true)
        {
            animator.SetBool("IsAlone", false);
        }
    }

    /// <summary>
    /// The behaviour of the AI when in the Idle state
    /// </summary>
    /// <returns></returns>
    IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            // This while loop will contain the Idle behaviour

            // The AI will wait for a few seconds before continuing.
            yield return new WaitForSeconds(idleTime);
            if (Child == false)
            {
                nextState = "Patrolling";
            }
            // Change to Patrolling state.

        }
    }

    /// <summary>
    /// The behaviour of the AI when in the Patrolling state
    /// </summary>
    /// <returns></returns>
    IEnumerator Patrolling()
    {

        // Set the checkpoint that this AI should move towards
        agentComponent.SetDestination(checkpoints[currentCheckpoint].position);
        bool hasReached = false;

        while (currentState == "Patrolling")
        {
            // This while loop will contain the Patrolling behaviour

            yield return null;
            if (!hasReached)
            {
                // If agent has not reached destination, do the following code
                // Check that the agent is at an acceptable stopping distance from the destination
                if (agentComponent.remainingDistance <= agentComponent.stoppingDistance)
                {
                    // We want to make sure this only happens once.
                    hasReached = true;
                    // Change back to Idle state.
                    nextState = "Idle";
                    // Increase the index to retrieve from the checkpoints array
                    ++currentCheckpoint;

                    // A check so that the index does not exceed the length of the checkpoints array
                    if (currentCheckpoint >= checkpoints.Length)
                    {
                        currentCheckpoint = 0;
                    }
                }
            }
        }
    }

    /// <summary>
    /// The behaviour of the AI when in the ChasingPlayer state
    /// </summary>
    /// <returns></returns>
    IEnumerator Following()
    {

        while (currentState == "Following")
        {
            // This while loop will contain the ChasingPlayer behaviour


            yield return null;

            // If there is a player to chase, keep chasing the player
            if (playerToChase != null)
            {
                agentComponent.SetDestination(playerToChase.position);
            }
            // If not, move back to the Idle state
            else
            {
                nextState = "Idle";

            }

        }


    }
    private IEnumerator _Atk()
    {


        yield return new WaitForSeconds(1.7f);

        player.got_hit();
        yield return new WaitForSeconds(0.9f);
        isColide = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Child == true && collision.gameObject.tag == "Player")
        {
            animator.SetBool("IsAlone", false);
            
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (Child == true&& collision.gameObject.tag=="Player")
        {
            animator.SetBool("IsAlone", true);

            gameObject.GetComponent<NavMeshAgent>().speed = 3;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GetComponent<NavMeshAgent>().speed = 0;
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsScream", false);
            animator.SetBool("IsAttack", true);
            animator.SetBool("Idle", false);

            if (isColide == true)
            {
                player.enemy_hit = 25;
                isColide = false;
                StartCoroutine("_Atk");

            }


        }

    }

    private void OnTriggerExit(Collider other)
    {

        GetComponent<NavMeshAgent>().speed = 4;
        animator.SetBool("IsRunning", true);
        animator.SetBool("IsScream", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("Idle", false);
        if (other.gameObject.tag == "Player")
        {

            isColide = false;

            player.enemy_hit = 0;


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="exit"&&Child ==true)
        {
            print("robot home");
        }
    }


    public void slow()
    {
        print("eslow");
    }




}


