using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DesotybottomLine : MonoBehaviour
{
    // Start is called before the first frame update
    public bool go;
    public AudioSource ad;
    public GameObject one ,tetris;
    public float falltime , waittime;
    float timer;
    bool clear, godown;
    int count;
    Scene scene;
    
    // 外部參數
    private int currentEnergy;
    private float currentScore;


    public static bool plusSwitch1=false;
    public static bool plusSwitch2=false;

    void Start()
    {
        scene = SceneManager.GetActiveScene();

          // 載入全域變數
        currentEnergy = energyCollect.currentEnergy;
        currentScore = endContral.currentScore;
    }

    // Update is called once per frame
    void Update()
    {        
        timer += Time.deltaTime;
        if (godown == true && timer >falltime)
        {
            tetris.transform.DOBlendableMoveBy(new Vector3(0, 0, -4) , 0.1F);
            timer = 0;
            StartCoroutine(wait());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && scene.name == "s1")
        {
            other.GetComponent<playerController>().Status = playerController.playermove.red2crash;
        }
        else if (other.gameObject.tag == "Player" && scene.name == "s2")
        {
            other.GetComponent<playerControllerS2>().Status = playerControllerS2.playermove.red2crash;
        }
        
    }
    public void destoryline()
    {
        if (clear == false && transform.childCount != 0)
        {
            for (float f = -4*3.5F; f <4*3.5f; f+=4)
            {
                Ray ray = new Ray(new Vector3(transform.position.x + f, transform.position.y, transform.position.z), Vector3.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 4))
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                    hit.transform.parent = transform.GetChild(0);
                    ad.Play();
                }
            }

            // 消除方塊加分
            Destroy(transform.GetChild(0).gameObject);

            if (currentEnergy < 133 && plusSwitch1)
            {
                currentEnergy = currentEnergy + 7;
                currentScore = currentScore + 65000/15;
            }
            else if (currentEnergy >= 133 && plusSwitch1)
            {
                currentEnergy = 133;
                currentScore = currentScore + 65000 / 15;
            }
            else if (currentEnergy < 72 && plusSwitch2) 
            {
                currentEnergy = currentEnergy + 5;
                currentScore = currentScore + 65000 / 15;
            }
            else if (currentEnergy >= 72 && plusSwitch2) 
            {
                currentEnergy = 72;
                currentScore = currentScore + 65000 / 15;
            }
            energyCollect.currentEnergy = currentEnergy;
            endContral.currentScore = currentScore;

            timer = 0;
            clear = true;
            godown = true;            
        }        
    }
    
    IEnumerator wait()
    {
        godown = false;
        yield return new WaitForSeconds(waittime);        
        clear = false;
        timer = 0;
        count++;
        if (count <= 7)
        {
            waittime -= 0.1f;
        }
        if (count > 8)
        {
            waittime = falltime;
        }
    }
}
