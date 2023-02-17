using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public GameObject key;
    void Start()
    {
        
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
            GameManager.instance.key = true;
            Destroy(gameObject);

        }
    }
}
