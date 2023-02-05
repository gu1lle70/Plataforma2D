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
    public float jumpForce = 0;
    private float Horizontal;


    public List<Vector3> rays;
    public LayerMask groundMask;
    public float GroundDistance = 5f;
    public bool Grounded;

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
        maxHealth = GameManager.instance.life;

    }

    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");
        if (!PauseMenu.instance.isPaused)
        {
            if (Horizontal > 0)
            {
                sr.flipX = false;
            }
            if (Horizontal < 0)
            {
                sr.flipX = true;
            }
        }
        anim.SetBool("Running", Horizontal != 0.0f);


        int count = 0;
        for (int i = 0; i < rays.Count; i++)
        {
            Debug.DrawRay(transform.position + rays[i], transform.up * -1 * GroundDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + rays[i], transform.up * -1, GroundDistance, groundMask);
            if (hit.collider != null)
            {
                count++;
                Debug.DrawRay(transform.position + rays[i], transform.up * -1 * hit.distance, Color.green);
                if (hit.transform.tag == "PlataformaMovil")
                {
                    transform.parent = hit.transform;
                }
                else
                {
                    transform.parent = null;
                }
            }
        }
        if (count > 0)
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
            transform.parent = null;
        }
        if (!PauseMenu.instance.isPaused) { 
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {

            Jump();
            Debug.Log("JUMP");

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

    private void Jump()
    {

        rb.AddForce(Vector2.up * jumpForce);

    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
        transform.position += new Vector3(Horizontal * speed * Time.fixedDeltaTime, 0, 0);

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
