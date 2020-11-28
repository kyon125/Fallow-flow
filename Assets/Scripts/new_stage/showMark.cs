using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class showMark : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player , Tetris ;
    public List<GameObject> Mark;
    public float distant , pos , time;
    bool go;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go == true)
        {
            for (int i = 0; i < Mark.Count; i++)
            {                
                Mark[i].SetActive(true);
            }            
            if (Mathf.Abs(Tetris.transform.position.z - Player.transform.position.z) <= distant)
            {
                print("a");
                for (int i = 0; i < Mark.Count; i++)
                {
                    Mark[i].SetActive(false);
                }
                Tetris.transform.DOBlendableMoveBy(new Vector3(0, pos, 0), time);
                cinemachineShake.cameraShake.goShake(14, 0.5f);
                go = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            go = true;
        }
    }
    
}
