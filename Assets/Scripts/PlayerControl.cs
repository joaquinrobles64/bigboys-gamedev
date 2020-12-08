// using System.String;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public int health;
    public float speed;
    public float turnspeed;
    public bool canTakeDamage = true;
    public int damage = 1;
    public string currentPowerUp = "";
    public int numKilled = 0;

    private bool dead = false;
    private float damageTimeout = 2f;
    private float angle;
    public float bulletSpeed = 10;
    public GameObject bullet;
    private Vector2 input;
    private Quaternion targetRotation;
    Transform cam;

    public Animator animator;
    public GameObject hitbox;
    public GameObject activator;
    private GameObject dog;

    public AudioClip hitMarker;
    public AudioClip oof;
    public AudioClip death;
    public AudioSource audioSwitcher; 

    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        hitbox.SetActive(false);
        activator.SetActive(true);
        dog = GameObject.FindWithTag("Dog");
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        GetInput();
        if(health >= 1){
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

        if(numKilled >= 34) {
            dog.transform.position = dog.GetComponent<Dog>().og;
        }
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
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
        Collider[] activatedEnemies = Physics.OverlapBox(activator.transform.position, new Vector3(10, 1, 15), activator.transform.rotation);

        foreach (Collider enemy in activatedEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<Enemy>().setActivation(true);
                }
            }
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
        hitbox.SetActive(true);

        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.transform.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

        // detect collision with objects
        Collider[] hitEnemies = Physics.OverlapBox(hitbox.transform.position, new Vector3((float)0.5, 1, 8), hitbox.transform.rotation);

        // damage detected enemies
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                audioSwitcher.PlayOneShot(hitMarker);
                enemy.GetComponent<Enemy>().health -= damage;
            }
        }

        // make hitbox inactive
        hitbox.SetActive(false);
        animator.SetTrigger("Idle");
        Destroy(bulletClone, .5f);
    }

    public void TakeDamage(int enemyDamage) 
    {
        audioSwitcher.PlayOneShot(oof);
        health -= enemyDamage;
        StartCoroutine(damageTimer());
    }
    
    private IEnumerator damageTimer() 
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }

    // private IEnumerator flashPlayer()
    // {
    //     GetComponent(MeshRenderer).enabled = false;
    // }

    void Die()
    {
        if (health <= 0 && !dead)
        {   
            animator.SetBool("IsMoving", false);
            animator.SetTrigger("Dead");
            audioSwitcher.PlayOneShot(death);
            dead = true;

            StartCoroutine(DieTimer());
        }
    }

    private IEnumerator DieTimer()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");

        Destroy(this.gameObject, 2);
    }
}
