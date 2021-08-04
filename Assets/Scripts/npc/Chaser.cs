using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    NavMeshAgent agentComponent;
    [SerializeField]
    Transform thingToChase;

    public Color tintcolor;
    private void Awake()
    {

        agentComponent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Raycast1();


    }
    public void Raycast1()
    {
        Vector3 origin = transform.position;
        Vector3 dirction = transform.forward;

        float maxDistance = 5f;
        Debug.DrawRay(origin, dirction * maxDistance, Color.blue);
        Ray ray = new Ray(origin, dirction);

        bool result = Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance);
        if (result)
        {
            //if player is in front of the raycast chase aft;
            if (thingToChase != null)
            {
                //ai movement to a target
                transform.LookAt(thingToChase);
               //transform.rotation = Quaternion.RotateTowards(transform.rotation,thingToChase.rotation,50f);
               agentComponent.SetDestination(thingToChase.position);
               //agentComponent.SetDestination(thingToChase.forward);
            }
            raycastHit.collider.GetComponent<Renderer>().material.color = tintcolor;
        }

    }

    
}
