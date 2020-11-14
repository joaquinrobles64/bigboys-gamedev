using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public bool activated = false;

    // Update is called once per frame
    void Update()
    {
        Move();
        Die();
    }

    void Move() {

        // if(activated) {




        // }
        
        // else{

        // }
    }

    void Die()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
