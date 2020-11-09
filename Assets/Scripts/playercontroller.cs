using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("地面判定")]
    public Transform player;
    public bool isground = false;
    private float raylong = 0.6f;
    private Rigidbody rb;

    [Header("墜落判定")]
    public bool isfallen;
    private Vector3 f_pos;

    [Header("粒子控制")]
    public ParticleSystem ps;

    public float speed;
    public player_status status;
    private Animator ani;
    score sc;

    private void Awake()
    {
        sc = GetComponent<score>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Application.targetFrameRate = 50;
        status = player_status.normal;        
    }

    // Update is called once per frame
    void Update()
    {
        status_choose();
        // isfallen
        fallen();

        con_particle();

        f_pos = transform.position;
    }
    private void FixedUpdate()
    {
        //isground
        Debug.DrawRay(player.position, Vector3.down * raylong, Color.red);
        Debug.DrawRay(transform.position, Vector3.up * 20, Color.green);

        if (Physics.Raycast(player.position, Vector3.down, raylong, 1 << 8) == true)
        {
            isground = true;
        }
        else
        {
            isground = false;
        }
        
    }
    public void end_ani()
    {
        ani.SetBool("infront", false);
        ani.SetBool("up", false);
        ani.SetBool("down", false);
        ani.SetBool("hitroad", false);
    }
    private void status_choose()
    {
        if (ani.GetBool("infront") == true)
        {
            status = player_status.fronting;
        }
        else if (ani.GetBool("down") == true)
        {
            status = player_status.downing;
        }
        else if (ani.GetBool("up") == true)
        {
            status = player_status.uping;
        }
        else
        {
            status = player_status.normal;
        }
    }
    void fallen()
    {
        if (f_pos.y - transform.position.y > 0 && isground == false)
        {
            isfallen = true;
            ani.SetBool("down", true);
        }
    }
    void con_particle()
    {
        ParticleSystem.MainModule ma = ps.main;
        if (sc.combo > 5 && sc.combo<= 15)
        {           
            ma.startColor = Color.red;
        }
        else if (sc.combo >15  && sc.combo <= 30)
        {
            ma.startColor = Color.green;
        }
        else if (sc.combo > 30 && sc.combo <= 40)
        {
            ma.startColor = Color.blue;
        }
        else if (sc.combo > 50)
        {
            ma.startColor = Color.grey;
        }
        //if (isground == true)
        //{
        //    onground.gameObject.SetActive(true);
        //    print("1");
        //}

        //else if (isground == false)
        //{
        //    onground.gameObject.SetActive(false);
        //    print("2");
        //}            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "F_ob")
        {
            if (status == player_status.fronting)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                print("hit");
                Time.timeScale = 0f;
            }
        }
        else
        {
            
        }

        //結束墜落
        if (collision.gameObject.tag == "road" && isfallen == true)
        {
            isfallen = false;
            ani.SetBool("hitroad", true);
        }
    }
}
public enum player_status
{
    normal,
    uping,
    downing,
    fronting
}
