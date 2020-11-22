using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class cinemachineShake : MonoBehaviour
{
    public static cinemachineShake cameraShake; 
    CinemachineVirtualCamera cine;
    private void Start()
    {
        cine = transform.GetComponent<CinemachineVirtualCamera>();
        cameraShake = this;
    }
    public void goShake(float shake,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shake;
        DOTween.To( () =>cinemachineBasicMultiChannelPerlin.m_AmplitudeGain , x=>cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = x, 0 , time);
    }    
}
