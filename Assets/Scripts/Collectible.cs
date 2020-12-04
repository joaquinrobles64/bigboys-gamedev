using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject player;
    private float powerUpTime = 10f;
    
    private void Awake() 
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                int rand = Random.Range(1, 4);
                Debug.Log("rand");

            switch(rand) 
            {
                case 1:
                 if(player.GetComponent<PlayerControl>().health < 5)
                    player.GetComponent<PlayerControl>().health = 5;
                 else
                    player.GetComponent<PlayerControl>().health += 2;
                break;

                case 2:
                  player.GetComponent<PlayerControl>().speed = 25;
                  StartCoroutine(powerUpTimer());
                  player.GetComponent<PlayerControl>().speed = 10;
                break;

                case 3:
                  player.GetComponent<PlayerControl>().damage = 2;
                  StartCoroutine(powerUpTimer());
                  player.GetComponent<PlayerControl>().damage = 1;
                break; 
            }

            Destroy(this.gameObject);
        }
    }

    private IEnumerator powerUpTimer() 
    {
        yield return new WaitForSeconds(powerUpTime);
    }
}
