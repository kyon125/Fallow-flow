using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DesotybottomLine : MonoBehaviour
{
    // Start is called before the first frame update
    public bool go;
    public GameObject one ,tetris;
    public float falltime , waittime;
    float timer;
    bool clear, godown;
    int count;
    void Start()
    {
        
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
        other.GetComponent<playerController>().Status = playerController.playermove.red2crash;
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
                }
            }
            Destroy(transform.GetChild(0).gameObject);
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
