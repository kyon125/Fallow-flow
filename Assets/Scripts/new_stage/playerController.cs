using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Bpm , waitdes;
    public bool isGround;
    public playermove Status;
    public DesotybottomLine des;
    float timer ,beatime;
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
        if (Status == playermove.red2)
        {
            red2_control();
            if (timer >= beatime)
            {
                red2gravity();
                timer = timer - beatime;
            }
        }
        else if (Status == playermove.red2crash)
        {
            StartCoroutine(waitDestory());
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
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1))
            {
                transform.DOBlendableLocalMoveBy(Vector3.up, 0.1f).SetEase(Ease.OutQuad);
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }            
        }
    }
    void red2gravity()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1, layerMask) == false) 
        {
            transform.DOBlendableLocalMoveBy(Vector3.down, 0.1f).SetEase(Ease.OutQuad);
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
    IEnumerator waitDestory()
    {
        yield return new WaitForSeconds(waitdes);
        des.destoryline();
    }
    public enum playermove
    {
        red1,
        red2,
        red2jump,
        red2crash,
        inpass
    }
}
