using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("音樂")]
    public AudioSource red1, red2;
    [Header("計時")]
    float timer, beatime, uptime;
    public float Bpm, waitdes;
    [Header("往前")]
    public float F;
    public float F_time;
    [Header("橫移速度")]
    public float pos;
    [Header("剛體")]
    public bool isGround;
    bool isup = true;
    Rigidbody rb;
    [Header("相機")]
    public CinemachineTrackedDolly dolly;
    public CinemachineVirtualCamera cine;
    [Header("類別")]
    public playermove Status;

    int layerMask = 1 << 8;
    public DesotybottomLine des;
    public GameObject deathPs;
    int dead;
    void Start()
    {
        dolly = cine.GetCinemachineComponent<CinemachineTrackedDolly>();
        rb = transform.GetComponent<Rigidbody>();
        beatime = 1 / Bpm * 60;
        if (Status == playermove.red1)
        {
            go_foword();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        uptime += Time.deltaTime;
        if (Status == playermove.red1)
        {
            red_control();
        }
        else if (Status == playermove.red2)
        {
            red2_control();
            red2gravity();
            if (timer >= beatime)
            {
                timer = timer - beatime;
            }
        }
        else if (Status == playermove.red2crash)
        {
            StartCoroutine(waitDestory());
        }
        else if (Status == playermove.death)
        {

        }

    }
    private void FixedUpdate()
    {
        if (Status == playermove.red1)
        {
            //rb.AddForce(Vector3.forward *  10);
            
        }        
    }
    void ground()
    {
        
    }
    void red_control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && pos < 2)
        {
            transform.DOBlendableMoveBy(new Vector3( 4,0 ,0), 0.1f);
            pos++;
            DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 0f, 0.1f);
            Invoke("restore", 0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && pos > -2) 
        {
            transform.DOBlendableMoveBy(new Vector3( - 4, 0, 0) , 0.1f);
            pos--;
            DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 2.0f, 0.1f);
            Invoke("restore", 0.5f);
        }
    }
    void red2_control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Ray ray = new Ray(transform.position, Vector3.right );
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1 , layerMask) == false)
            {
                transform.DOBlendableLocalMoveBy(Vector3.right, 0.1f).SetEase(Ease.OutQuad);
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Ray ray = new Ray(transform.position, Vector3.left);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1 , layerMask) == false)
            {
                transform.DOBlendableLocalMoveBy(Vector3.left, 0.1f).SetEase(Ease.OutQuad);
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }            
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Ray ray = new Ray(transform.position, Vector3.back);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1))
            {
                transform.DOBlendableLocalMoveBy(Vector3.forward, 0.1f).SetEase(Ease.OutQuad);
                uptime = 0;
                isup = true;                
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }            
        }
    }
    void red2gravity()
    {
        Ray ray = new Ray(transform.position, Vector3.back);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1, layerMask) == false && uptime >= beatime)
        {
            transform.DOBlendableLocalMoveBy(Vector3.back, 0.1f).SetEase(Ease.OutQuad);
            uptime = 0;
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        if (Physics.Raycast(ray, out hit, 1, layerMask))
        {
            uptime = 0;
        }     
    }
    public void go_foword()
    {
        transform.DOKill();
        transform.DOBlendableMoveBy(new Vector3(0, 0, F), F_time).SetEase(Ease.Linear);
    }
    private void restore()
    {
        DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 1, 1.2f);
    }
    public void forDeath()
    {
        StartCoroutine(waitDeath());
    }
    IEnumerator waitDestory()
    {
        yield return new WaitForSeconds(waitdes);
        des.destoryline();
    }
    IEnumerator waitDeath()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<BoxCollider>().enabled = false;
        red2.Stop();
        Instantiate(deathPs, transform);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("End");
    }
    public enum playermove
    {
        red1,
        red2,
        red2jump,
        red2crash,
        death,
        inpass
    }
}
