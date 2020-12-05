using System;
using UnityEngine;

public class CollectiblesScript : MonoBehaviour
{
    private GameObject player;
    private string currentPowerUp;
    public bool canUse = true;

    public event Action<string> OnCollected = delegate { };

    private void OnEnable() 
    {
        player = GameObject.FindWithTag("Player");
    }

    public void ChangeHud(string powerUp) 
    {
        OnCollected(powerUp);
        canUse = false;
    }

    private void Update()
    {
        if(player.GetComponent<PlayerControl>().currentPowerUp != "") {
          string powerUp = player.GetComponent<PlayerControl>().currentPowerUp;
          ChangeHud(powerUp);
        }
    }
}
