using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{

    private NavMeshAgent agent;

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
            agent.SetDestination(GetPoint.Instance.getRandomPoint (transform, radius));
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
