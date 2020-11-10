using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
