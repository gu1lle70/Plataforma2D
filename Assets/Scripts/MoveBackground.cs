using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float lenght;
    private float StartPos;
    private GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {

        cam = GameObject.Find("Main Camera");
        StartPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(StartPos + distance, transform.position.y, transform.position.z);


    }
}
