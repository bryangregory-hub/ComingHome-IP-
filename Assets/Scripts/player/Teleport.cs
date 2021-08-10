using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public GameObject transScreen;

    private void Start()
    {
        transScreen.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {//teleports player back to the main room
        if (gameObject.tag=="Untagged")
        {
            thePlayer.transform.position = teleportTarget.transform.position;
            StartCoroutine(Transition());
        }
        
    }
    private IEnumerator Transition()
    {
        transScreen.SetActive(true);
        yield return new WaitForSeconds(1);
        transScreen.SetActive(false);
    }
    void Update()
    {
        

    }

}
