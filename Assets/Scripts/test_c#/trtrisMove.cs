using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class trtrisMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float pos , time;
    public bool final;    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        if(final == false)
        transform.DOMoveY(pos, time).SetEase(Ease.Linear);
        else if (final == true)
        transform.DOMoveX(pos, time).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
