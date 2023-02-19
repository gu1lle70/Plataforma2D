using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaScript : MonoBehaviour
{
    public GameObject tiendaMenu;
    public GameObject win;
    public GameObject locker;
    public GameObject tienda;

    // Start is called before the first frame update
    void Start()
    {
        tiendaMenu.SetActive(false);
        win.SetActive(false);
        tienda.SetActive(false);
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
        if(other.tag == "Player" && GameManager.instance.key == true)
        {
            Time.timeScale = 0.0f;
            tiendaMenu.SetActive(false);
            win.SetActive(true);
            locker.SetActive(false);
            tienda.SetActive(true);
            
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
