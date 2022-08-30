using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinch : MonoBehaviour
{
    float originalDistance;
    float currentdistance;
    Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                originalDistance = Vector2.Distance(Input.GetTouch(1).position, Input.GetTouch(0).position);
                originalScale = transform.localScale;
            }
            else
            {
                currentdistance = Vector2.Distance(Input.GetTouch(1).position, Input.GetTouch(0).position);
                transform.localScale = originalScale * (currentdistance / originalDistance);
            }
        }
    }
}
