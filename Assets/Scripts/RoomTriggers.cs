using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggers : MonoBehaviour
{

    private Vector3[] positionsForObjects = new Vector3[7];
    private GameObject[] doors = new GameObject[10];
    private int numChildren;
    private int alienCount = 0;
    public bool entered = false;
    private bool finished = false;

    public AudioClip doorSound;
    public AudioSource audioDoor;

    // Start is called before the first frame update
    void Start()
    {
        int doorsCount = 0;
        numChildren = transform.childCount;

        for(int i = 0; i < numChildren; i++)
        {
            if(transform.GetChild(i).gameObject.CompareTag("Door"))
            {   
                doors[doorsCount] = transform.GetChild(i).gameObject;
                doorsCount++;
            }
        }


        for(int i = 0; i < doors.Length; i++)
        {
            if(doors[i] != null)
            {

                positionsForObjects[i] = doors[i].transform.position;
                doors[i].transform.position = new Vector3(0, 0, 0);
            }
        }

        alienCount = numChildren - doorsCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !entered)
        {
            audioDoor.PlayOneShot(doorSound);
            entered = true;

            for(int i = 0; i < doors.Length; i++)
            {
                if(doors[i] != null)
                    doors[i].transform.position = positionsForObjects[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == numChildren - alienCount && !finished)
        {
            audioDoor.PlayOneShot(doorSound);
            finished = true;
            
            for(int i = 0; i < doors.Length; i++)
            {
                if(doors[i] != null)
                    doors[i].transform.position = new Vector3(0, 0, 0);
            }
        }
    }
}
