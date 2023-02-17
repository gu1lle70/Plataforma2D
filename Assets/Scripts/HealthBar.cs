using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthHeart;
    public Image healthHeart1;
    public Image healthHeart2;

    void Start()
    {


    }

   
    void Update()
    {
        
        healthHeart.enabled = false;
        healthHeart1.enabled = false;
        healthHeart2.enabled = false;
    }


}
