using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class simpletmove : MonoBehaviour
{
    // Start is called before the first frame update\
    public float Maxf ,start , end, speed;
    public CinemachineVirtualCamera cine;
    public CinemachineTrackedDolly dolly;
    float F_cine;
    void Start()
    {
        dolly = cine.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        cam_move();
    }
    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.z > start)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.z < end)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
    void cam_move()
    {
        dolly.m_PathPosition = 2 * (transform.position.z - start) / Maxf;
    }
    private void FixedUpdate()
    {
        
    }
}
