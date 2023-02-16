using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI Moneda;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moneda.text = GameManager.instance.moneda.ToString();
    }
}
