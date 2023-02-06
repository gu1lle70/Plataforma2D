using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    public GameObject Warrior;

    public float maxhealthEnemy = 100.0f;
    float currentHealth;
    public float esperarAnim;


    public Transform attackPoint;
    public LayerMask PlayerLayers;
    public float attackRange = 0.5f;
    public float damagePlayer = 20.0f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float attakTimer = 0f;



    void Start()
    {
        currentHealth = maxhealthEnemy;
        anim = GetComponent<Animator>();

        

    }


    public void TakeDamagePlayer(float damageEnemy)
    {
       
        GameManager.instance.life -= damageEnemy;

        anim.SetTrigger("Damaged");

        if (currentHealth <= 0)
        {

            Dead();

        }

    }

    private void Dead()
    {

        anim.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

    }
   
    private void Attack()
    {

        
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayers);
        if(hitPlayer.Length > 0)
        {
            anim.SetBool("Attack", true);
            Debug.Log("You hitted player");
            hitPlayer[0].transform.GetComponent<HorizontalMovment>().TakeDamageEnemy(damagePlayer);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    
}   

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);


    }

    void Update()
    {
        Vector3 direction = Warrior.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        else
        {

            transform.transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);

        }
        float distance = Mathf.Abs(Warrior.transform.position.x - transform.position.x);


        if(distance <= 2.0f)
        {
            attakTimer += Time.deltaTime;
            if(attakTimer > attackRate)
            {
             attakTimer = 0;
                Attack();
            }

        }
        else
        {
            attakTimer = 0;
            anim.SetBool("Attack", false);
        }
        /*
        if (distance <= 2.0f && Time.time >= nextAttackTime)

        {
            nextAttackTime = Time.time + 1f / attackRate;
            
            Attack();


        }
        else if (distance >= 2.0f)

        {
            nextAttackTime = Time.time + 1f / attackRate;
            anim.SetBool("Attack", false);
        }
       */
    }
        
}
