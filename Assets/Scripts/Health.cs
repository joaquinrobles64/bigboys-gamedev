using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 5;
    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable() 
    {
        currentHealth = health;
    }

    public void ModifyHealth(int amount) 
    {
        currentHealth += amount;
        float currentHealthPct = ((float)currentHealth / (float)health);
        OnHealthPctChanged(currentHealthPct);
    }

    private void Update()
    {
        if(GetComponent<PlayerControl>().health != currentHealth) {
            int num1 = GetComponent<PlayerControl>().health;
            ModifyHealth(num1 - currentHealth);
        }

    }
}
