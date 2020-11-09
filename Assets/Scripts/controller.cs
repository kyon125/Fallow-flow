using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 s_pos, e_pos;
    player_status status;

    public GameObject player ;
    public AudioSource drum;
    private Animator ani;
    private score sc;

    public float updown, front , jumpspeed, c_timer;
    void Start()
    {
        status = player.GetComponent<playercontroller>().status;
        ani = player.GetComponent<Animator>();
        sc = player.GetComponent<score>();
    }

    // Update is called once per frame
    void Update()
    {
        c_timer += Time.deltaTime;
        if (c_timer < 0.05)
        {
            sc.s_click = true;
        }
        else
        {
            sc.s_click = false;
        }

        touch();
    }

    public void touch()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case (TouchPhase.Began):
                    {
                        s_pos = touch.position;                        
                        break;
                    }
                case (TouchPhase.Ended):
                    {
                        e_pos = touch.position;
                        judge_status();
                        break;
                    }
            }
        }
    }

    public void judge_status()
    {
        float val_x , val_y;
        val_x = e_pos.x - s_pos.x;
        val_y = e_pos.y - s_pos.y;
        if (Mathf.Abs(val_y) > updown)
        {
            //上滑
            if (val_y > 0)
            {
                print("上:" + val_y);
                ani.SetBool("up", true);
            }
            //下滑
            else if (val_y < 0)
            {
                print("下:" + val_y);
                ani.SetBool("down", true);
            }
        }
        else if (Mathf.Abs(val_x) > front)
        {
            print("往前:" + val_x);
            ani.SetBool("infront", true);
        }
        else if (Mathf.Abs(val_y) < updown && Mathf.Abs(val_x) < front)
        {
            if (s_pos.x >= 484)
            {
                print("單點_右");
            }
            else if (s_pos.x < 484)
            {
                print("單點_左");
            }
            single_click();
        }
    }

    public void jump()
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpspeed);
    }
    public void single_click()
    {
        c_timer = 0;
        drum.Play();
    }
    enum click_time
    {
        prefect,
        good, 
        bad, 
        miss
    }
}
