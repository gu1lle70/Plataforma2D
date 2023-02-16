using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovment : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;

    public float speed = 0;
    private float Horizontal;
    public float dashForce = 270;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public float damageEnemy = 20.0f;
   
    public float maxHealth = 100f;


    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");
        if (!PauseMenu.instance.isPaused)
        {
            if (Horizontal > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
               
            }
            if (Horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        
        anim.SetBool("Running", Horizontal != 0.0f);

            if (Input.GetKeyDown(KeyCode.F))
            {

                Dash();

                Debug.Log("DASHED");

            }
            if (Time.time >= nextAttackTime)

             {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                Debug.Log("Attacking left click");
                nextAttackTime = Time.time + 1f / attackRate;

            }

            if (Input.GetMouseButtonDown(1))
                Debug.Log("Pressed right click.");
        }
       }
    }

    
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
        transform.position += new Vector3(Horizontal * speed * Time.fixedDeltaTime, 0, 0);

    }
    private void Dash()
    {
        if (Horizontal > 0)
        {
            rb.AddForce(Vector2.right * dashForce);
            anim.SetTrigger("Dash");

        }
        if (Horizontal < 0)
        {
            rb.AddForce(Vector2.left * dashForce);
            anim.SetTrigger("Dash");
        }


    }
    void Attack()
    {

        anim.SetTrigger("Attack");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitEnemies)
        {

            Debug.Log("You hitted enemy");
            enemy.transform.GetComponent<EnemyScript>().TakeDamagePlayer(damageEnemy);

        }


    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);


    }
    public void TakeDamageEnemy(float damagePlayer)
    {

        GameManager.instance.life -= damagePlayer;
        Debug.Log("Has recibido damage");
        anim.SetTrigger("Damaged");
            
        if (GameManager.instance.life <= 0)
        {

            Dead();

        }
        

    }

    private void Dead()
    {

        anim.SetBool("isDead", true);
        rb.gravityScale = 0.0f;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
  
        

    }




}
