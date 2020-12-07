using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public int health;
    public int damage = 0;
    public float radius;
    public Animator animator;
    public BoxCollider enemysHitbox;
    public bool larger = false;

    private int count = 0;
    private NavMeshAgent agent;
    private bool activated = false;
    private GameObject player;
    private Collider[] hitPlayer;
    private Collider[] hitPlayerConfirmation;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0) {
            Move();
            Attack();
        } else{
            if(count == 0) {
            Die();
            count++;
            }
        }
    }
    
    void Move() {

        if(!agent.hasPath) {
            animator.SetBool("IsMoving", true);
            agent.SetDestination(GetPoint.Instance.getRandomPoint (transform, radius));
        }
            if(activated) {
                agent.speed = 10;
                agent.ResetPath();
                agent.SetDestination(player.transform.position);
            }
    }

    void Attack() {

        hitPlayer = Physics.OverlapBox(enemysHitbox.transform.position, new Vector3(2, 2, 1), enemysHitbox.transform.rotation);

        if(larger) 
         hitPlayer = Physics.OverlapBox(enemysHitbox.transform.position, new Vector3((float)2.5, 2, (float)1.5), enemysHitbox.transform.rotation);

        foreach (Collider playerHit in hitPlayer)
            {
                if (playerHit.CompareTag("Player"))
                {
                    if(playerHit.GetComponent<PlayerControl>().canTakeDamage)
                    {
                        animator.SetTrigger("Attack");
                        AttackConfirming();
                    }
                }
            }
            animator.SetTrigger("Idle");
    }

    void AttackConfirming() {

        hitPlayerConfirmation = Physics.OverlapBox(enemysHitbox.transform.position, new Vector3((float)1, 2, (float)1), enemysHitbox.transform.rotation);

        if(larger) 
          hitPlayerConfirmation = Physics.OverlapBox(enemysHitbox.transform.position, new Vector3((float)0.8, 2, (float)1), enemysHitbox.transform.rotation);

        foreach (Collider playerHitConfirmation in hitPlayerConfirmation) 
        {   
            if (playerHitConfirmation.CompareTag("Player"))
            {
                player.GetComponent<PlayerControl>().TakeDamage(damage);
            }
        }
    }

    void Die()
    {
        if (health <= 0)
        {   animator.SetBool("IsMoving", false);
            animator.SetTrigger("Dead");
            player.GetComponent<PlayerControl>().numKilled += 1;
            // Debug.Log(player.GetComponent<PlayerControl>().numKilled);
            Destroy(this.gameObject, (float) 1.8);
        }
    }

    public void setActivation(bool result) {
        activated = result;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endif
}
