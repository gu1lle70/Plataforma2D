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
        if(GameManager.instance.life == 3) { 

        healthHeart.enabled = true;
        healthHeart1.enabled = true;
        healthHeart2.enabled = true;
        }
        if (GameManager.instance.life == 2)
        {

            healthHeart.enabled = true;
            healthHeart1.enabled = true;
            healthHeart2.enabled = false;
        }
        if (GameManager.instance.life == 1)
        {

            healthHeart.enabled = true;
            healthHeart1.enabled = false;
            healthHeart2.enabled = false;
        }
        if (GameManager.instance.life == 0)
        {

            healthHeart.enabled = false;
            healthHeart1.enabled = false;
            healthHeart2.enabled = false;
        }


    }


}
