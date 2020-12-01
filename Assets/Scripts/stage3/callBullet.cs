using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ad;
    public List<Group> group;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(ad.time);
        for (int i = 0; i < group.Count; i++)
        {
            if (ad.time >= group[i].time  && group[i].Awake == false)
            {
                for (int a = 0; a < group[i].obj.Count; a++)
                {
                    group[i].obj[a].SetActive(true);
                    group[i].Awake = true;
                }
            }
        }
    }
}
[System.Serializable]
public class Group
{
    public float time;
    public List<GameObject> obj;
    public bool Awake;
}
