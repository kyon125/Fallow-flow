﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

public class playerControllerS2 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("音樂")]
    public AudioSource red1, red2 ,s_dead;
    [Header("計時")]
    float timer, beatime, uptime;
    public float Bpm, waitdes, sm_time1, sm_time2;
    [Header("往前")]
    public float F;
    public float F_time;
    [Header("橫移")]
    public Animator ani;
    public float pos;
    public GameObject mark;
    [Header("剛體")]
    public bool isGround;
    Vector3 scale;
    bool isup = true;
    Rigidbody rb;
    [Header("材質")]
    public Material m_normal;
    public Material m_red;
    SkinnedMeshRenderer render;
    [Header("相機")]
    public Camera main;
    public CinemachineTrackedDolly dolly;
    public CinemachineVirtualCamera cine;
    [Header("類別")]
    public List<GameObject> one;
    public List<GameObject> secand;
    public GameObject redObj, greenObj;
    public playermove Status;
    public int colornum;
    public gameColor color;
    public Playecolor playecolor;
    public GameObject learn;

    [Header("能量")]
    public EnergyBar energyBar;
    public int maxEnergy = 72;
    public int resetEnergy = 0;

    [Header("分數")]
    public float maxScore = 100000;
    public GameObject endg;

    // 外部參數
    private int currentEnergy;
    private bool start_Timer2;
    private bool isEnergyMove;
    private bool plusSwitch2;
    private float currentScore;
    private bool endGame;


    int layerMask = 1 << 8;
    public DesotybottomLine des;
    public GameObject deathPs;
    int dead;
    void Start()
    {
        // 能量
        //currentEnergy = resetEnergy;
        //energyBar.SetMaxEnergy(maxEnergy);
        //energyBar.SetResetEnergy(resetEnergy);

        // 載入全域變數
        currentEnergy = energyCollect.currentEnergy;
        start_Timer2 = energyCollect.start_Timer2;
        isEnergyMove = energyCollect.isEnergyMove;
        plusSwitch2 = DesotybottomLine.plusSwitch2;
        currentScore = endContral.currentScore;
        endGame = endContral.endGame;

        // 分數
        currentScore = 0;

        dolly = cine.GetCinemachineComponent<CinemachineTrackedDolly>();
        render = transform.GetComponent<SkinnedMeshRenderer>();
        scale = transform.localScale;
        rb = transform.GetComponent<Rigidbody>();
        beatime = 1 / Bpm * 60;
        if (Status == playermove.red1)
        {
            StartCoroutine(r1Musicplay(sm_time1));
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
            if (color == gameColor.red)
            {
                redObj.SetActive(true);
                greenObj.SetActive(false);
            }
            else if (color == gameColor.green)
            {
                redObj.SetActive(false);
                greenObj.SetActive(true);
            }
        }
        else if (Status == playermove.red2crash)
        {
            StartCoroutine(waitDestory());
        }
        else if (Status == playermove.death)
        {

        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.F12))
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }

    }
    void ground()
    {

    }
    void red_control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && pos < 2)
        {
            //transform.DOBlendableMoveBy(new Vector3( 4,0 ,0), 0.1f);
            //pos++;
            //DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 0f, 0.1f);
            //ani.SetBool("Right", true);
            //ani.SetBool("Left", false);
            //ani.SetBool("End", false);
            //Invoke("restore", 0.5f);
            StartCoroutine(goright());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && pos > -2)
        {
            StartCoroutine(goleft());
        }
        thirdConcolor();
    }
    void red2_control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Ray ray = new Ray(transform.position, Vector3.right);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4, layerMask) == false)
            {
                transform.DOBlendableLocalMoveBy(4 * Vector3.right, 0.1f).SetEase(Ease.OutQuad);
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Ray ray = new Ray(transform.position, Vector3.left);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4, layerMask) == false)
            {
                transform.DOBlendableLocalMoveBy(4 * Vector3.left, 0.1f).SetEase(Ease.OutQuad);
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Ray ray = new Ray(transform.position, Vector3.back);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4))
            {
                uptime = 0;
                transform.DOBlendableLocalMoveBy(4 * Vector3.forward, 0.1f).SetEase(Ease.OutQuad);
                
                isup = true;
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
            }
        }
        conColor();
    }
    void red2gravity()
    {
        Ray ray = new Ray(transform.position, Vector3.back);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4, layerMask) == false && uptime >= beatime)
        {
            transform.DOBlendableLocalMoveBy(4 * Vector3.back, 0.1f).SetEase(Ease.OutQuad);
            uptime = 0;
            print(uptime);
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        if (Physics.Raycast(ray, out hit, 4, layerMask))
        {
            uptime = 0;
        }
    }
    void thirdConcolor()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playecolor = Playecolor.red;
            render.material = m_red;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            playecolor = Playecolor.green;
            render.material = m_normal;
        }
    }
    void conColor()
    {
        if (Input.GetKeyDown(KeyCode.Z) && colornum > 0)
        {
            colornum--;
        }
        else if (Input.GetKeyDown(KeyCode.C) && colornum < 1)
        {
            colornum++;
        }
        if (colornum == 0)
        {
            color = gameColor.green; 
        }
        else if (colornum == 1)
        {
            color = gameColor.red;
        }
    }
    public void go_foword()
    {
        transform.DOKill();
        transform.DOBlendableMoveBy(new Vector3(0, 0, F), F_time).SetEase(Ease.Linear);
        red1.Play();

    }
    public void trunMoveend()
    {
        ani.SetBool("Right", false);
        ani.SetBool("Left", false);
    }
    public void Moveend()
    {
        ani.SetBool("End", true);
    }
    private void restore()
    {
        DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 1, 1.2f);
    }
    public void forDeath()
    {
        StartCoroutine(waitDeath());
    }
    public void forDeaththird()
    {
        StartCoroutine(waitDeaththird());
    }
    public void goTored2()
    {
        StartCoroutine(changered2(5));
    }
    IEnumerator changered2(float time)
    {
        DOTween.To(() => red1.volume, x => red1.volume = x, 0, 3f);
        yield return new WaitForSeconds(time);
        red1.Stop();
        main.orthographic = true;
        for (int i = 0; i < secand.Count; i++)
        {
            secand[i].SetActive(true);
        }
        for (int i = 0; i < one.Count; i++)
        {
            one[i].SetActive(false);
        }
    }
    IEnumerator r1Musicplay(float time)
    {
        learn.transform.DOScaleX(1, 0.3f);      
        
        yield return new WaitForSeconds(time);
        learn.transform.DOScaleX(0, 0.3f);
        go_foword();
    }
    IEnumerator waitDestory()
    {
        yield return new WaitForSeconds(waitdes);
        plusSwitch2 = true;
        DesotybottomLine.plusSwitch2 = plusSwitch2;
        des.destoryline();
        yield return new WaitForSeconds(7);
        start_Timer2 = true;
        energyCollect.start_Timer2 = start_Timer2;
        yield return new WaitForSeconds(3);
        isEnergyMove = true;
        energyCollect.isEnergyMove = isEnergyMove;
        yield return new WaitForSeconds(2);
        endGame = true;
        endContral.endGame = endGame;
        yield return new WaitForSeconds(1);
        endg.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("mainmenu");
    }
    IEnumerator waitDeath()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
        transform.GetComponent<BoxCollider>().enabled = false;
        red2.Stop();
        s_dead.Play();
        Instantiate(deathPs, transform);
        endGame = true;
        endContral.endGame = endGame;
        yield return new WaitForSeconds(1);
        endg.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("End");
    }
    IEnumerator waitDeaththird()
    {
        transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.DOKill();
        transform.GetComponent<Rigidbody>().isKinematic = true;
        red1.Stop();
        s_dead.Play();
        Instantiate(deathPs, new Vector3(transform.position.x ,transform.position.y , transform.position.z) ,Quaternion.identity);
        endGame = true;
        endContral.endGame = endGame;
        yield return new WaitForSeconds(1);
        endg.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("End");
    }
    IEnumerator goleft()
    {
        transform.DOBlendableMoveBy(new Vector3(-4, 0, 0), 0.1f);
        pos--;
        ani.SetBool("Right", false);
        ani.SetBool("Left", true);
        yield return new WaitForSeconds(0.15f);
        //DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 2.0f, 0.5f);
        ani.SetBool("End", false);
        //Invoke("restore", 0.5f);
    }
    IEnumerator goright()
    {
        transform.DOBlendableMoveBy(new Vector3(4, 0, 0), 0.1f);
        pos++;
        //DOTween.To(() => dolly.m_PathPosition, x => dolly.m_PathPosition = x, dolly.m_PathPosition = 0f, 0.1f);
        ani.SetBool("Right", true);
        ani.SetBool("Left", false);
        yield return new WaitForSeconds(0.15f);
        ani.SetBool("End", false);
        //Invoke("restore", 0.5f);
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
    public enum gameColor
    {
        red,
        green
    }
    public enum Playecolor
    {
        red,
        green
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "energy")
        {
            if (currentScore < maxScore)
            {
                currentScore += 35000 / 72;
                endContral.currentScore = currentScore;
            }

            if (currentEnergy < maxEnergy)
            {
                currentEnergy = currentEnergy + 1;
                energyCollect.currentEnergy = currentEnergy;
            }
        }
    }
}
