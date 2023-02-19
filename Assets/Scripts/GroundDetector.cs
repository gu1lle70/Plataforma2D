using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;
    [SerializeField]
    private float groundDistance = 1.5f;
    public List<Vector3> rays;
    public LayerMask groundMask;
    public float jumpForce = 3000;
    private Rigidbody2D rb;
    public Animator anim;
    public GameObject platform;
    public GameObject platform2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for (int i = 0; i < rays.Count; i++)
        {
            Debug.DrawRay(transform.position + rays[i], transform.up * -1 * groundDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + rays[i], transform.up * -1, groundDistance, groundMask);
            if (hit.collider != null)
            {
                count++;
                Debug.DrawRay(transform.position + rays[i], transform.up * -1 * hit.distance, Color.green);

                if (hit.transform.tag == "PlataformaMovil")
                {
                    this.transform.parent = platform.transform;
                    Debug.Log("Entraste platform");
                }
                if (hit.transform.tag == "PlataformaMovil2")
                {
                    this.transform.parent = platform2.transform;
                    Debug.Log("Entraste platform");
                }
                else
                {
                    transform.parent = null;
                }
            }
            
        }
        if (count > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
           
            transform.parent = null;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            Jump();
            Debug.Log("JUMP");

        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && grounded)
        {

            Agacharse();

            Debug.Log("Agachao");

        }
    }
    private void Jump()
    {

        anim.SetTrigger("Jump");
        rb.AddForce(Vector2.up * jumpForce);


    }
    private void Agacharse()
    {

        anim.SetTrigger("crouch");

    }

}
