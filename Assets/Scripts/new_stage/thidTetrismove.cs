using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class thidTetrismove : MonoBehaviour
{
    // Start is called before the first frame update
    Material m;
    public int destoryAdditem;
    public float movePos, moveTime;
    bool Move;
    List<GameObject> kids;
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
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
        if (scene.name == "s1")
        {
            switch (destoryAdditem)
            {
                case (1):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0);
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_443DFAAE", 0);
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 0.1f);
                        }
                        break;
                    }
                case (2):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 0.2F);
                        }
                        break;
                    }
                case (3):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 0.3F);
                        }
                        break;
                    }
                case (4):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 0.4F);
                        }
                        break;
                    }
                case (5):
                    {
                        if (Move == false)
                        {
                            for (int i = 0; i < transform.childCount; i++)
                            {
                                kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 0.5F);
                            }
                            transform.DOBlendableMoveBy(new Vector3(movePos, 0, 0), moveTime);
                            cinemachineShake.cameraShake.goShake(7, 0.5f);
                            Move = true;
                        }
                        break;
                    }
            }
        }
        else if (scene.name == "s2")
        {
            switch (destoryAdditem)
            {
                case (1):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_CC5FEA5A", 0);
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_443DFAAE", 0);
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0.1f);
                        }
                        break;
                    }
                case (2):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0.2F);
                        }
                        break;
                    }
                case (3):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0.3F);
                        }
                        break;
                    }
                case (4):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0.4F);
                        }
                        break;
                    }
                case (5):
                    {
                        if (Move == false)
                        {
                            for (int i = 0; i < transform.childCount; i++)
                            {
                                kids[i].GetComponent<MeshRenderer>().material.SetFloat("Vector1_90955845", 0.5F);
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
}
