using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public string currentState;

    public string nextState;

    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            nextState = "Active";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            nextState = "Idle";
        }

        if (nextState != currentState)
        {
            SwitchState();
        }
    }

    void SwitchState()
    {
        currentState = nextState;

        StartCoroutine(currentState);
    }

    IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            Debug.Log("Currently in Idle State");
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(1.5f);
        while (currentState == "Active")
        {
            Debug.Log("Currently in Active State");
            yield return new WaitForEndOfFrame();
        }
    }
}
