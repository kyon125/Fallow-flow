using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        red2_control();
    }
    void red2_control()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.DOBlendableLocalMoveBy(Vector3.right, 0.5f).SetEase(Ease.OutQuad);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.DOBlendableLocalMoveBy(Vector3.left, 0.5f).SetEase(Ease.OutQuad);
        }
    }
    public enum playermove
    {
        red1,
        red2,
        inpass
    }
}
