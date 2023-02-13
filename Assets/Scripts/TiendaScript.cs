using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaScript : MonoBehaviour
{
    public GameObject tiendaMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        tiendaMenu.SetActive(false);

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
            
            tiendaMenu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("saliste");
        if (other.tag == "Player")
        {
            
            tiendaMenu.SetActive(false);
        }
    }
}
