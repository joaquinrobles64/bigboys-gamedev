using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Movement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        transform.Translate(xAxis * speed * Time.deltaTime, 0f, zAxis * speed * Time.deltaTime);
    }

    void Attack()
    {
        
    }
}
