using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update
    public float posX , time;

    private void Awake()
    {
        Tween t = this.transform.DOMoveX(posX, time).SetEase(Ease.Linear);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x >= posX)
        {
            Destroy(this.transform.gameObject);
        }
    }
}
