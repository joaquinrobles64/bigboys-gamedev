using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float radius;
    public Animator animator;
    private NavMeshAgent agent;
    private int count = 0;
    public bool activated = false;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0) {
            Move();
        } else{
            if(count == 0) {
            Die();
            count++;
            }
        }
    }

    // private void Start()
    // {
    //     agent = GetComponent<NavMeshAgent> ();
    // }

    void Move() {

        if(!agent.hasPath) {
            animator.SetBool("IsMoving", true);
            agent.SetDestination(GetPoint.Instance.getRandomPoint (transform, radius));
        }
        if (agent.velocity.magnitude <= 0 && agent.hasPath)
        {
            SolveStuck();
        }

    }

    IEnumerator SolveStuck() {
        Vector3 lastPosition = this.transform.position;
        // Debug.Log("working");
        while (true) {
            yield return new WaitForSeconds(3f);
 
            //Maybe we can also use agent.velocity.sqrMagnitude == 0f or similar
            if (!agent.pathPending && agent.hasPath && agent.remainingDistance > agent.stoppingDistance) {
                Vector3 currentPosition = this.transform.position;
                if (Vector3.Distance(currentPosition, lastPosition) < 1f) {
                    Vector3 destination = agent.destination;
                    agent.ResetPath();
                    agent.SetDestination(destination);
                    Debug.Log("Agent Is Stuck");
                }
                Debug.Log("Current Position " + currentPosition + " Last Position " + lastPosition);
                lastPosition = currentPosition;
            }
        }
    }

    void Die()
    {
        if (health <= 0)
        {   animator.SetBool("IsMoving", false);
            animator.SetTrigger("Dead");
            Destroy(this.gameObject, 2);
        }
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endif
}
