using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class layserMove : MonoBehaviour
{
    public List<lay> moveList;
    public float bpm;
    GameObject layser;
    float beattime, timer;
    int count;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        beattime = 60 / bpm;
        layser = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= beattime)
        {
            if (moveList[count].direction == Direction.horizontal)
            {
                transform.DOBlendableMoveBy(new Vector3(0, moveList[count].distant, 0), 0.1f);
                if (count == moveList.Count - 1)
                {
                    if (moveList[count].show == Show.show)
                    {
                        layser.SetActive(true);
                    }
                    else if (moveList[count].show == Show.disappear)
                    {
                        layser.SetActive(false);
                    }
                    count = 0;
                    timer -= beattime;
                }
                else
                {
                    if (moveList[count].show == Show.show)
                    {
                        layser.SetActive(true);
                    }
                    else if (moveList[count].show == Show.disappear)
                    {
                        layser.SetActive(false);
                    }
                    count++;
                    timer -= beattime;
                }
            }
            else if (moveList[count].direction == Direction.vertical)
            {
                transform.DOBlendableMoveBy(new Vector3(moveList[count].distant, 0, 0), 0.1f);
                if (count == moveList.Count - 1)
                {
                    if (moveList[count].show == Show.show)
                    {
                        layser.SetActive(true);
                    }
                    else if (moveList[count].show == Show.disappear)
                    {
                        layser.SetActive(false);
                    }
                    count = 0;
                    timer -= beattime;
                }
                else
                {
                    if (moveList[count].show == Show.show)
                    {
                        layser.SetActive(true);
                    }
                    else if (moveList[count].show == Show.disappear)
                    {
                        layser.SetActive(false);
                    }
                    count++;
                    timer -= beattime;
                }
            }            
        }
    }
    [System.Serializable]
    public class lay
    {
        public Direction direction;
        public float distant;
        public Show show;
    }
    public enum Direction
    {
        horizontal,
        vertical
    }
    public enum Show
    {
        show,
        disappear
    }
}
