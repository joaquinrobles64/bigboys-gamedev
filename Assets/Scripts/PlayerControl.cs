using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float turnspeed;
    private Vector2 input;
    private float angle;
    private Quaternion targetRotation;
    Transform cam;

    public Animator animator;
    public GameObject hitbox;
    public GameObject activator;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        hitbox.SetActive(false);
        // activator.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        // return if there's no directional input
        float horizontalMove = Mathf.Abs(input.x);
        float verticalMove = Mathf.Abs(input.y);
        if (horizontalMove < 1 && verticalMove < 1)
        {
            animator.SetBool("IsMoving", false);
            return;
        }
        Movement();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        // Collider[] activatedEnemies = Physics.OverlapBox(activator.transform.position, new Vector3(34, 1, 35), activator.transform.rotation);

        // foreach (Collider enemy in activatedEnemies)
        //     {
        //         if (enemy.CompareTag("Enemy"))
        //         {
        //             enemy.GetComponent<Enemy>().activated = true;
        //         }
        //     }
    }

    void Movement()
    {
        animator.SetBool("IsMoving", true);
        CalculateDirection();
        Rotate();
        Move();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        // hitbox active so it can interact with other objects
        hitbox.SetActive(true);

        // detect collision with objects
        Collider[] hitEnemies = Physics.OverlapBox(hitbox.transform.position, new Vector3(1, 2, 1), hitbox.transform.rotation);



        // damage detected enemies
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().health -= 1;
            }
        }

        // make hitbox inactive
        hitbox.SetActive(false);
        animator.SetTrigger("Idle");
    }
}
