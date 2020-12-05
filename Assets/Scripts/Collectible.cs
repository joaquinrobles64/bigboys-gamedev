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
        if (other.CompareTag("Player") && GetComponentInParent<CollectiblesScript>().canUse)
        {
                int rand = Random.Range(1, 4);
                Debug.Log(rand);

            switch(rand) 
            {
                case 1:
                  player.GetComponent<PlayerControl>().currentPowerUp = "Heart";
                  if(player.GetComponent<PlayerControl>().health < 5)
                     player.GetComponent<PlayerControl>().health = 5;
                  else
                     player.GetComponent<PlayerControl>().health += 2;
                     Destroy(this.gameObject, 3);
                break;

                case 2:
                  player.GetComponent<PlayerControl>().currentPowerUp = "Speed";
                  StartCoroutine(powerUpTimerSpeed());
                break;

                case 3:
                  player.GetComponent<PlayerControl>().currentPowerUp = "Damage";
                  StartCoroutine(powerUpTimerDamage());
                break; 
            }
            
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 11);
        }
    }

    private IEnumerator powerUpTimerSpeed() 
    {
         player.GetComponent<PlayerControl>().speed = 20;
        yield return new WaitForSeconds(powerUpTime);
         player.GetComponent<PlayerControl>().speed = 15;
    }

    private IEnumerator powerUpTimerDamage() 
    {
        player.GetComponent<PlayerControl>().damage = 5;
        yield return new WaitForSeconds(powerUpTime);
        player.GetComponent<PlayerControl>().damage = 2;
    }
}
