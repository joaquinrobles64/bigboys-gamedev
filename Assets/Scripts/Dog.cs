using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour
{
    public Vector3 og = new Vector3(0, 0, 0);

    void Start() {
        og = this.transform.position;
        transform.position = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
           SceneManager.LoadScene("Victory");
        }
    }
}
