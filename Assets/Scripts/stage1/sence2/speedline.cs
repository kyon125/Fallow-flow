using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class speedline : MonoBehaviour
{
    // Start is called before the first frame update
    public S1_Basic player;
    public type t; 
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<S1_Basic>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("A");
            switch (t)
            {
                case type.stright1:
                    {
                        player.go_foword();
                    }
                    break;
                case type.stright2:
                    {
                        player.go_foword2();
                    }
                    break;
                case type.trun1:
                    break;
                case type.trun2:
                    break;
                default:
                    break;
            }
        }
    }
    public enum type
    {
        stright1,
        stright2,
        trun1,
        trun2
    }
}
