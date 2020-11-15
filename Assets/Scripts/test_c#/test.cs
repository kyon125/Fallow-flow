using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera cine;
    public CinemachineTrackedDolly dolly;
    public AudioSource ad;
    void Start()
    {
        dolly = cine.GetCinemachineComponent<CinemachineTrackedDolly>();
        go();
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    void go()
    {
        Tween t = DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, 1, 10).SetEase(Ease.Linear);
    }
}
