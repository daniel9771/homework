using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    Gyroscope my_gyro;
    Quaternion orig_rotation;
    // Start is called before the first frame update
    void Start()
    {
        my_gyro = Input.gyro;
        my_gyro.enabled = true;
        Debug.Log(my_gyro.enabled);
        orig_rotation = my_gyro.attitude;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = my_gyro.attitude * orig_rotation;
    }
}
