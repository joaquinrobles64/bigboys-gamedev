using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleHud : MonoBehaviour
{

    private GameObject player;
    private GameObject collectibles;
    public Image SpeedImage;
    public Image DamageImage;
    public Image HeartImage;
    // public String currentPowerUp;
    private float activeTime;

    private void Awake() 
    {
        player = GameObject.FindWithTag("Player");
        collectibles = GameObject.FindWithTag("Collectible");
        collectibles.GetComponent<CollectiblesScript>().OnCollected += HandleIconChange;
        SpeedImage.fillAmount = 0;
        DamageImage.fillAmount = 0;
        HeartImage.fillAmount = 0;
    }
    
    private void HandleIconChange(string icon)
    {

        player.GetComponent<PlayerControl>().currentPowerUp = "";
        activeTime = 10f;

        switch(icon) {
            case "Speed":
            SpeedImage.fillAmount = 100;
            break;

            case "Damage":
            DamageImage.fillAmount = 100;
            break;

            case "Heart":
            HeartImage.fillAmount = 100;
            activeTime = 3f;
            break;
        }

        StartCoroutine(ChangeIcon());

    }

    private IEnumerator ChangeIcon()
    {
        yield return new WaitForSeconds(activeTime);
        SpeedImage.fillAmount = 0;
        DamageImage.fillAmount = 0;
        HeartImage.fillAmount = 0;
        collectibles.GetComponent<CollectiblesScript>().canUse = true;
    }

    private void LateUpdate() 
    { 

    }
}
