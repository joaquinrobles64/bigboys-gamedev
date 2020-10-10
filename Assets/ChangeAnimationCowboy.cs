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
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.J))
            anim.SetTrigger("Run");   

        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetTrigger("Idle");
        }
    }
}