using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class S1_Basic : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("音樂")]
    public AudioSource ad;
    [Header("計時")]
    bool action = false;
    float time;
    public float s_time;
    [Header("往前")]
    public float F;
    public float F_time;
    [Header("往前加速")]
    public float F2;
    public float F2_time;
    [Header("橫移速度")]
    public float speed;
    [Header("剛體")]
    public playStatus Status;
    public GameObject camerafallow;
    public bool isground;
    public Rigidbody rb;
    public float jump_speed;
    public float g;
    [Header("相機")]
    public CinemachineTrackedDolly dolly;
    public CinemachineVirtualCamera cine;

    void Start()
    {
        dolly = cine.GetCinemachineComponent<CinemachineTrackedDolly>();
        Status = playStatus.third;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        start_Game();
        if (Status == playStatus.two)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Status == playStatus.two)
        {
            if (isground == true)
            {
                rb.AddForce(Vector3.up * jump_speed);
            }
        }
    }
    private void FixedUpdate()
    {        
        v_move();        
        if (isground == false && Status == playStatus.two)
        {
            rb.AddForce(new Vector3(0, -g, 0));
        }
    }
    void start_Game()
    {
        if (time >= s_time && action == false )
        {
            ad.Play();
            go_foword();
            action = true;
            time = 0;           
        }        
    }
    void v_move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 0f, 0.1f);


            Invoke("restore", 1.0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 2.0f, 0.1f);

            Invoke("restore", 1.0f);
        }        
    }
    public void go_foword()
    {
        transform.DOKill();
        print("0");
        transform.DOBlendableMoveBy(new Vector3(F, 0, 0), F_time).SetEase(Ease.Linear);
        camerafallow.transform.DOBlendableMoveBy(new Vector3(F, 0, 0), F_time).SetEase(Ease.Linear);
    }
    public void go_foword2()
    {
        print("1");
        transform.DOKill();
        transform.DOBlendableMoveBy(new Vector3(F2, 0, 0), F2_time).SetEase(Ease.Linear);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("s1"):
                {
                    transform.DOKill();
                    transform.DOBlendableMoveBy(new Vector3(F, 0, 0), F_time).SetEase(Ease.Linear);
                    break;
                }
            case ("s2"):
                {
                    transform.DOKill();
                    transform.DOBlendableMoveBy(new Vector3(F2, 0, 0), F2_time).SetEase(Ease.Linear);
                    break;
                }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "road")
        {
            isground = true;
        }                    
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "road")
        {
            isground = false;
        }        
    }
    private void restore()
    {
        DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 1, 1.2f);
    }
    public enum playStatus
    {
        third,
        two
    }
}


