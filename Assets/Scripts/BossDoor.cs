using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    private GameObject player;
    public AudioClip doorSound;
    public AudioSource audioDoor;
    private bool notYet = true;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(player.GetComponent<PlayerControl>().numKilled >= 27 && notYet)
        {

            audioDoor.PlayOneShot(doorSound);
            notYet = true;

            for(int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).gameObject.CompareTag("Door"))
                {   
                    transform.GetChild(i).gameObject.transform.position = new Vector3(0, 0, 0);
                    notYet = false;
                }
            }
        }
    }
}
