using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPlatform : MonoBehaviour
{
    public GameObject waitPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        waitPlatform.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entraste");
        if (other.tag == "Player")
        {

            waitPlatform.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("saliste");
        if (other.tag == "Player")
        {

            waitPlatform.SetActive(false);
        }
    }
}
