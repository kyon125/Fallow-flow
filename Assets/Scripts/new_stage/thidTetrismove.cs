using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class thidTetrismove : MonoBehaviour
{
    // Start is called before the first frame update
    Material m;
    public int destoryAdditem;
    public float movePos, moveTime;
    bool Move;
    List<GameObject> kids;
    void Start()
    {
        m = transform.GetComponent<Material>();
        kids = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            kids.Add(this.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (destoryAdditem)
        {
            case (1):
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A",0.5f);
                        kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0);
                        kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_443DFAAE", 0);
                    }                    
                    break;
                }
            case (2):
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 1F);
                    }
                    break;
                }
            case (3):
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 1.5F);
                    }
                    break;
                }
            case (4):
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 2F);
                    }
                    break;
                }
            case (5):
                {
                    if (Move == false)
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 2.5F);
                        }
                        transform.DOBlendableMoveBy(new Vector3(movePos, 0, 0), moveTime);
                        cinemachineShake.cameraShake.goShake(7, 0.5f);
                        Move = true;
                    }                    
                    break;
                }
        }
    }
}
