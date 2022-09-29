using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 Mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Mouse_position.z = transform.position.z;
        offset = Mouse_position - transform.position;

    }
    private void OnMouseDrag()
    {
        Vector3 new_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        new_position.z = transform.position.z;
        transform.position = new_position - offset;    
    }
    
}
