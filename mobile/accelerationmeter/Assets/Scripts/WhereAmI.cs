using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class WhereAmI : MonoBehaviour
{

    public Text info;
    public float alt;
    public float lat;
    public float lon;

    void Update()
    {
        alt = Input.location.lastData.altitude;
        lat = Input.location.lastData.latitude;
        lon = Input.location.lastData.longitude;
        info.text = "altitude = " + alt + "latitude = " + lat + "longitude = " + lon;


    }
   
}
