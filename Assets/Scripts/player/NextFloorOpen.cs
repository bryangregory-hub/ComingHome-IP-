using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextFloorOpen : MonoBehaviour
{
    public GameObject keycard;
    public GameObject teleporter;
    public GameObject alert;
    // Start is called before the first frame update
    void Start()
    {
        alert.gameObject.SetActive(false);
        teleporter.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "card")
        {
            print("hi");
            alert.gameObject.SetActive(true);
            keycard.gameObject.SetActive(false);
            teleporter.gameObject.SetActive(true);
        }
    }

}
