using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class open : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float move_z , time, distant;
    float posX ;
    bool stay = false;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x - player.transform.position.x;
        if (posX <= distant && stay==false)
        {
            dooropen();
        }
    }
    void dooropen()
    {
        transform.DOBlendableMoveBy(new Vector3(0, 0, move_z), time).SetEase(Ease.Linear);
    }
}
