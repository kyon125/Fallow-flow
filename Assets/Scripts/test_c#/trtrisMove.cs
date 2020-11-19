using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class trtrisMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float pos , time;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        transform.DOMoveY(pos, time).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
