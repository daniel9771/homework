using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TwinMoveImage : MonoBehaviour
{
    public bool inOrOut = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Space"))
        {
            transform.DOMove(new Vector3(5, 0, 0), 0.5f);
          
        }

    }
    IEnumerable MoveAway()
    {
        inOrOut = false;
        yield return new WaitForSeconds(1f);
    }
}
