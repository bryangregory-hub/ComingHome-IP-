/******************************************************************************
Author: Bryan Gregory

Name of Class: SamplePlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input it also work with raycasting to identify targets.

Date Created: 09/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    /// 
    [Header("Chara Variables")]


    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float interactionDistance;

    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    [SerializeField]
    private Camera playerCamera;

    private string currentState;

    private string nextState;

    [SerializeField]
    Chaser genericChaser;


    InteractableObject stateCheck;
    public GameObject enemy;
    public GameObject robot;
    [Header("Chara stats")]
    public float playerHealth;
    public Text pHealth;
    public GameObject health_pack;
    
    public  float plus_health;
    public float enemy_hit;
    public Image lo_indi;
    public Transform des;
    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
        //center the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        stateCheck = GetComponent<InteractableObject>();


        lo_indi = lo_indi.GetComponent<Image>();


    }
    

    // Update is called once per frame
    void Update()
    {
         des = des.transform;
        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
        InteractionRaycast();
        Ui();

        //_ph = enemy.GetComponent<PatrolAI>()._pHealth;
        if (playerHealth <= 50)
        {
            
            lo_indi.gameObject.SetActive(true);

        }
        else if (playerHealth >= 51)
        {
            lo_indi.gameObject.SetActive(false);
        }
        if (playerHealth<=0)
        {
            SceneManager.LoadScene("DeathMenu");
        }
    }
    /// <summary>
    /// this is to check if player is interacting with interactible items
    /// </summary>
    private void InteractionRaycast()
    {
        Debug.DrawLine(playerCamera.transform.position,
                    playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);

        int layermask = 1 << LayerMask.NameToLayer("Interactable");
        int layermask2 = 1 << LayerMask.NameToLayer("Notes");

        RaycastHit hitinfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,
            out hitinfo, interactionDistance, layermask))
        {
            // if my ray hits something, if statement is true
            // do stuff here
            if (Input.GetKeyDown(KeyCode.E))
            {

                hitinfo.transform.GetComponent<InteractableObject>().Interact();


            }



        }
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,
            out hitinfo, interactionDistance, layermask2))
        {
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                hitinfo.transform.GetComponent<InteractableObject>().Story();
                hitinfo.transform.GetComponent<InteractableObject>()._hovr = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                hitinfo.transform.GetComponent<InteractableObject>().Story();
                hitinfo.transform.GetComponent<InteractableObject>()._hovr = false;
            }
        }
        


    }

    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    private IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                nextState = "Moving";
            }
            yield return null;
        }
    }

    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (!CheckMovement())
            {
                nextState = "Idle";
            }
            yield return null;
        }
    }

    private void CheckRotation()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    private bool CheckMovement()
    {
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = xMovement + zMovement;

        if (movementVector.sqrMagnitude > 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;

            transform.position = newPos;
            return true;
        }
        else
        {
            return false;
        }

    }
    /// <summary>
    /// checks if player is hit by bullet or in door
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        CollisionFunction(collision);
        if (collision.gameObject.tag=="Bullet")
        {
            playerHealth -= 10;
        }
        if (collision.gameObject.tag=="door 1")
        {
            print("door lock");
        }
        
    }
    /// <summary>
    /// this is to test collision
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void CollisionFunction(Collision collision)
    {
        //Debug.Log("hi");
    }
    /// <summary>
    /// this helps use is inside program and if true center the mouse 
    /// </summary>

    void OnApplicationFocus(bool focus)
    {
        if (focus == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    /// <summary>
    /// when the players gets attack by the ai monster
    /// </summary>
    /// 
    public void got_hit()
    {
        print("geting hit");
        playerHealth -= enemy_hit;
    }
    /// <summary>
    /// updates ui for the health
    /// </summary>
    void Ui()
    {
        
        pHealth.text = "Health: " + playerHealth;
    }

    /// <summary>
    /// if player interact with the health kit 
    /// </summary>
    public void heal()
    {
        print("hi");
        playerHealth += plus_health;
    }

}

