using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class S2_3Dtetrismove : MonoBehaviour
{
    // Start is called before the first frame update
    public List<moveSet> moveList;
    public float bpm;
    float beattime , timer;
    int count;
    bool start;
    void Start()
    {
        beattime = 60/bpm;
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
                transform.DOBlendableMoveBy(new Vector3(0, moveList[count].distant, 0), 0.1f);
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
            else if (moveList[count].direction == Direction.vertical)
            {
                transform.DOBlendableMoveBy(new Vector3(moveList[count].distant, 0, 0), 0.1f);
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
        }
    }
    [System.Serializable]
    public class moveSet
    {
        public Direction direction;
        public float distant;
    }
    public enum Direction
    {
        horizontal,
        vertical
    }
}
