using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cinemachine;

public class playerControllerS3 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("音樂")]
    public AudioSource red1, red2;
    [Header("計時")]
    float timer, beatime, uptime , songtime;
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
    public Material m_green;
    public Material m_red;
    public MeshRenderer m_render;
    SkinnedMeshRenderer render;
    [Header("相機")]
    public Camera main;
    public CinemachineTrackedDolly dolly;
    public CinemachineVirtualCamera cine;
    [Header("類別")]
    public List<GameObject> one;
    public List<GameObject> secand;
    public GameObject redObj, greenObj ,blueobj;
    public playermove Status;
    public int colornum = 1;
    public gameColor color;
    public Playecolor playecolor;
    [Header("分數")]
    public float maxScore = 100000;
    public GameObject endg;
    [Header("能量")]
    public EnergyBar energyBar;
    public int maxEnergy = 100;
    public int resetEnergy = 0;

    // 外部參數
    private int currentEnergy;
    private bool start_Timer3;
    private bool isEnergyMove;
    private float currentScore;
    private bool endGame;

    int layerMask = 1 << 8;
    public DesotybottomLine des;
    public GameObject deathPs;

    int dead;
    void Start()
    {
        // 載入全域變數
        currentEnergy = energyCollect.currentEnergy;
        start_Timer3 = energyCollect.start_Timer3;
        isEnergyMove = energyCollect.isEnergyMove;
        currentScore = endContral.currentScore;
        endGame = endContral.endGame;

        // 能量
        currentEnergy = resetEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        energyBar.SetResetEnergy(resetEnergy);

        dolly = cine.GetCinemachineComponent<CinemachineTrackedDolly>();
        render = transform.GetComponent<SkinnedMeshRenderer>();
        scale = transform.localScale;
        rb = transform.GetComponent<Rigidbody>();
        beatime = 1 / Bpm * 60;
        if (Status == playermove.red1)
        {
            StartCoroutine(r1Musicplay(sm_time1));
        }
        else if (Status == playermove.red2)
        {
            songtime = PlayerPrefs.GetFloat("songtime");
            red1.Play();
            red1.time = songtime;
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
            if (timer >= beatime)
            {
                timer = timer - beatime;
            }
            if (red1.time >= 163)
            {
                goWin();
                Status = playermove.death;
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
    void ground()
    {

    }
    void red_control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && pos < 2)
        {
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
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 25)
        {
            transform.DOBlendableLocalMoveBy(4 * Vector3.right, 0.1f).SetEase(Ease.OutQuad);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)&& transform.position.x > - 25)
        {
            transform.DOBlendableLocalMoveBy(4 * Vector3.left, 0.1f).SetEase(Ease.OutQuad);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z< 4591)
        {
            transform.DOBlendableLocalMoveBy(4 * Vector3.forward, 0.1f).SetEase(Ease.OutQuad);           
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.z > 4561)
        {
            transform.DOBlendableLocalMoveBy(4 * Vector3.back, 0.1f).SetEase(Ease.OutQuad);
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
            color = gameColor.red;
            playecolor = Playecolor.red;
            render.material = m_red;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            color = gameColor.green;
            playecolor = Playecolor.green;
            render.material = m_green;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            color = gameColor.blue;
            playecolor = Playecolor.blue;
            render.material = m_normal;
        }
    }
    void conColor()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            color = gameColor.red;
            playecolor = Playecolor.red;
            m_render.material = m_red;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            color = gameColor.green;
            playecolor = Playecolor.green;
            m_render.material = m_green;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            color = gameColor.blue;
            playecolor = Playecolor.blue;
            m_render.material = m_normal;
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
        StartCoroutine(changered2(0.5f));
    }
    public void goWin()
    {
        StartCoroutine(Win(0.5f));
    }
    IEnumerator Win(float time)
    {
        red1.Stop();
        yield return new WaitForSeconds(time);
    }
    IEnumerator changered2(float time)
    {
        transform.DOKill();
        transform.GetComponent<Rigidbody>().isKinematic = true;
       
        PlayerPrefs.SetFloat("songtime", red1.time);
        yield return new WaitForSeconds(0);        
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
    IEnumerator getThreecolor()
    {        
        yield return new WaitForSeconds(3f);
    }
    IEnumerator r1Musicplay(float time)
    {
        yield return new WaitForSeconds(time);
        go_foword();
    }
    IEnumerator waitDestory()
    {
        yield return new WaitForSeconds(waitdes);
        des.destoryline();
        yield return new WaitForSeconds(7);
        start_Timer3 = true;
        energyCollect.start_Timer1 = start_Timer3;
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
        Instantiate(deathPs, transform); endGame = true;
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
        Instantiate(deathPs, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
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
        green,
        blue
    }
    public enum Playecolor
    {
        red,
        green,
        blue
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "energy")
        {
            if (currentScore < maxScore)
            {
                currentScore += 50000 / 78;
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
