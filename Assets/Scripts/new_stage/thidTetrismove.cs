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
    public List<Color> change;
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
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[0]);
                        }
                        break;
                    }
                case (2):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[1]);
                        }
                        break;
                    }
                case (3):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor" , change[2]);
                        }
                        break;
                    }
                case (4):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[3]);

                        }
                        break;
                    }
                case (5):
                    {
                        if (Move == false)
                        {
                            for (int i = 0; i < transform.childCount; i++)
                            {
                                kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[4]);
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
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[0]);
                        }
                        break;
                    }
                case (2):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[1]);
                        }
                        break;
                    }
                case (3):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[2]);
                        }
                        break;
                    }
                case (4):
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[3]);
                        }
                        break;
                    }
                case (5):
                    {
                        if (Move == false)
                        {
                            for (int i = 0; i < transform.childCount; i++)
                            {
                                kids[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", change[4]);
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
