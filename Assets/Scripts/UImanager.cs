using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI Moneda;
    public GameObject key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moneda.text = GameManager.instance.moneda.ToString();
        if (GameManager.instance.key == true)
        {
            key.SetActive(true);

        }
        else
        {
            key.SetActive(false);
        }
    }
}
