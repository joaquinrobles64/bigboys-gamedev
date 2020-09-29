using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        print("PlayerMovement Start()");
        _speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, _speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
