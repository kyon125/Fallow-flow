using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : MonoBehaviour
{
    public GameObject player;
    public Vector3 start;
    public AudioSource audioSource;
    private float time ;
    public float start_time, EverycreatTime , musicTime;
    bool first = true;
    bool m_start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        musicPlay();
        creatplayer();
    }

    void creatplayer()
    {
        if (time >= start_time && first == true && m_start ==true)
        {
            Instantiate(player, start, Quaternion.identity);
            time = time - start_time;
            first = false;
        }
        else if (time >= EverycreatTime && first == false && m_start == true)
        {
            Instantiate(player, start, Quaternion.identity);
            time = time - EverycreatTime;
        }
    }
    void musicPlay()
    {
        if (m_start == false && time>=musicTime)
        {
            audioSource.Play();
            m_start = true;
            time = time - musicTime;
        }        
    }
}
