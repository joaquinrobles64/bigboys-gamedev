using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Image HealthBarImage;
    public float updateSpeedSeconds = 0.5f;
    private GameObject player;

    private void Awake() 
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Health>().OnHealthPctChanged += HandleHealthChanged;
        Debug.Log("It worked");
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = HealthBarImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSeconds) 
        {
            elapsed += Time.deltaTime;
            HealthBarImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        HealthBarImage.fillAmount = pct;

    }

    private void LateUpdate() 
    { 

    }
}
