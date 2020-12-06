using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationCowboy : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.W)){
            anim.SetTrigger("Run");   
        }

        if (Input.GetKeyDown(KeyCode.A)){
            anim.SetTrigger("Run");   
        }

        if (Input.GetKeyDown(KeyCode.S)){
            anim.SetTrigger("Run");   
        }

        if (Input.GetKeyDown(KeyCode.D)){
            anim.SetTrigger("Run");   
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("Idle");
        }
    }
}