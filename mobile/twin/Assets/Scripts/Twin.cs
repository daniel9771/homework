using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twin : MonoBehaviour
{
    public bool canUse = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canUse)
        {
            canUse = false;
        StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        transform.Translate(0.1f, 0.1f, 0.1f);
    yield return new WaitForSeconds(.1f);
        canUse = true;
    }

    
}
