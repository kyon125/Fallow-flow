using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class S3_2DcubMove : MonoBehaviour
{
    // Start is called before the first frame update
    public List<moveSet> moveList;
    public float bpm;
    float beattime, timer;
    int count;
    bool start;
    BoxCollider boxcollider;
    MeshRenderer render;

    void Start()
    {
        boxcollider = transform.GetComponent<BoxCollider>();
        render = transform.GetComponent<MeshRenderer>();
        beattime = 60 / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if (timer >= 3)
        //{
        //    start = true;
        //    timer = 0;
        //}
        if (timer >= beattime /*&& start ==true*/)
        {
            if (moveList[count].direction == Direction.horizontal)
            {
                transform.DOBlendableMoveBy(new Vector3(0, 0, moveList[count].distant), 0.1f);
                determineAppear();
                determineCount();
            }
            else if (moveList[count].direction == Direction.vertical)
            {
                transform.DOBlendableMoveBy(new Vector3(moveList[count].distant, 0, 0), 0.1f);
                determineAppear();
                determineCount();
            }
        }
    }
    void determineAppear()
    {
        if (moveList[count].appear == Appear.show)
        {
            boxcollider.enabled = true;
            render.enabled = true;
        }
        else if ((moveList[count].appear == Appear.disapper))
        {
            boxcollider.enabled = false;
            render.enabled = false;
        }
    }
    void determineCount()
    {
        if (count == moveList.Count - 1)
        {
            count = 0;
            timer -= beattime;
        }
        else
        {
            count++;
            timer -= beattime;
        }
    }
    [System.Serializable]
    public class moveSet
    {
        public Direction direction;
        public Appear appear;
        public float distant;
    }
    public enum Direction
    {
        horizontal,
        vertical
    }
    public enum Appear
    {
        show,
        disapper
    }
}
