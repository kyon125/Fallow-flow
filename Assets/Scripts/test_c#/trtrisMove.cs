using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class trtrisMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float pos , time , shake;
    public bool final;    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        if (final == false)
        {
            transform.DOMoveY(pos, time).SetEase(Ease.Linear);
            StartCoroutine(wait(time));
        }

        else if (final == true)
        {
            transform.DOMoveX(pos, time).SetEase(Ease.Linear);
            StartCoroutine(wait(time));
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        cinemachineShake.cameraShake.goShake(shake, 0.5f);
    }
}
