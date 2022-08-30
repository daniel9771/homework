using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerationmeter : MonoBehaviour
{
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.acceleration.x * speed;
        float y = -Input.acceleration.z * speed;
        transform.Translate(x, 0, y);

    }
}
