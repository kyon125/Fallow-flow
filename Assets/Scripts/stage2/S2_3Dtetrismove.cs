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
    void Start()
    {
        beattime = bpm / 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= beattime)
        {
            if (moveList[count].direction == Direction.horizontal) ;
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
