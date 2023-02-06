using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Image healthBar1;
    public Image healthBar2;
    public Image healthBar3;
    public Image healthBar4;
    public Image ImgMedio;

    void Start()
    {


    }

   
    void Update()
    {

        IEnumerator ImageMedio()
        {
            healthBar.enabled = false;
            healthBar1.enabled = true;
            yield return new WaitForSeconds((float)0.2);
            ImgMedio.enabled = true;
            yield return new WaitForSeconds((float)0.2);
            ImgMedio.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = false;
            healthBar4.enabled = false;

        }
            if (GameManager.instance.life == 100)
        {
            healthBar.enabled = true;
            healthBar1.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = false;
            healthBar4.enabled = false;


        }
        if (GameManager.instance.life == 80)
        {
            StartCoroutine(ImageMedio());

        }
        if (GameManager.instance.life == 60)
        {
            healthBar.enabled = false;
            healthBar1.enabled = false;
            healthBar2.enabled = true;
            healthBar3.enabled = false;
            healthBar4.enabled = false;

        }
        if (GameManager.instance.life == 40)
        {
            healthBar.enabled = false;
            healthBar1.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = true;
            healthBar4.enabled = false;

        }
        if (GameManager.instance.life == 20)
        {
            healthBar.enabled = false;
            healthBar1.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = false;
            healthBar4.enabled = true;

        }
        if (GameManager.instance.life == 0)
        {
            healthBar.enabled = false;
            healthBar1.enabled = false;
            healthBar2.enabled = false;
            healthBar3.enabled = false;
            healthBar4.enabled = false;

        }






    }


}
