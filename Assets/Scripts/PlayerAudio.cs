using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

public AudioClip doorSound;
public AudioSource audioDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Room") && !other.gameObject.GetComponent<RoomTriggers>().entered) {
             audioDoor.PlayOneShot(doorSound);
             other.gameObject.GetComponent<RoomTriggers>().entered = true;
             Debug.Log("This working");
        }
    }
}
