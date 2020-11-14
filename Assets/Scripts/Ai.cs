using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{

    private NavMeshAgent agent;
    public Animator animator;

    // public int room;
    public float radius;

     // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.hasPath) {
            animator.SetBool("IsMoving", true);
            agent.SetDestination(GetPoint.Instance.getRandomPoint (transform, radius));
        }
        if (agent.velocity.magnitude <= 0 && agent.hasPath)
        {
            // Debug.Log("yes");
            SolveStuck();
        }

        // if (agent.horizontalMove < 1 && agent.verticalMove < 1)
        // {
        //     animator.SetBool("IsMoving", false);
        //     return;
        // }
    }

    // void Attack() {
    //     animator.SetTrigger("Attack");
    // }

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

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
