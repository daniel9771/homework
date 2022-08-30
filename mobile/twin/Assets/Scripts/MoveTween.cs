using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTween : MonoBehaviour
{
    [SerializeField] Material cubeMat;
    
    private void Start()
    {
        //transform.DOMove(new Vector3(5, 5, 5), 5);
        //transform.DOScale(new Vector3(5, 5, 5), 10);
        //cubeMat.DOFade(0, 5);
    }
    private void Update()
    {
        
    }

}
