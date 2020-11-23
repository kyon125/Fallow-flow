using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Bpm , waitdes;
    public bool isGround;
    public playermove Status;
    public DesotybottomLine des;
    public GameObject deathPs;
    float timer ,beatime , uptime;
    bool isup =true;
    public AudioSource red1, red2;
    Rigidbody rb;
    int layerMask = 1 << 8;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        beatime = 1 / Bpm * 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        uptime += Time.deltaTime;
        if (Status == playermove.red2)
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
        
    }
    void ground()
    {
        
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
