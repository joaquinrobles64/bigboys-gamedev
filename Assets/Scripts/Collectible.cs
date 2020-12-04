using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private Random rng = new Random();

public class Collectible : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < 10; i++)
        {
            rng.Next(1, 4));
        }

        switch(rng) {
            case 1:
            break;
            case 2:
            break;
            case 3: 
        }

        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
