using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Text healthText;
    public Image healthBar;
    private float UIHealth;
    private float UImaxHealth;
    void Start()
    {
        UIHealth = GameManager.instance.life;
        UIHealth = UImaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + UIHealth + "%";

        HealthBarFill();

    }

    void HealthBarFill()
    {
        healthBar.fillAmount = UIHealth / UImaxHealth;


    }


}
