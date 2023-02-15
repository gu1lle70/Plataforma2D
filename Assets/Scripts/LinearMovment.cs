using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovment : MonoBehaviour
{
    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;
    public GameObject Player;
    private Transform rbody;
    private bool isOnPlatform;
    private Transform platformRBody;
    private Vector3 lastPlatFormPosition;

    void Awake()
    {
        rbody = GetComponent<Transform>();
    }

    void Start()
    {

    }
    void Update()
    {
        Vector3 dir = points[nextPoint].position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (distance < 0.1f)
        {


            nextPoint++;
            if (nextPoint >= points.Count)
            {

                nextPoint = 0;

            }


        }

    }
}

  