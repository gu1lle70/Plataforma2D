using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject player;
    public GameObject DeadScreen;

    // Start is called before the first frame update
    void Start()
    {
        DeadScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entraste dead");
        if (other.tag == "Player")
        {

            DeadScreen.SetActive(true);
            Destroy(player);
        }
    }
}
