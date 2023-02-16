using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonedaScript : MonoBehaviour
{
    public GameObject moneda;

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
            GameManager.instance.moneda =+ 1;
            Destroy(gameObject);
            
        }
    }
}
