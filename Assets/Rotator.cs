using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
