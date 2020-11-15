using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class disslove_set : MonoBehaviour
{
    // Start is called before the first frame update
    public Material m;
    public float speed;
    void Start()
    {
        m = transform.GetComponent<MeshRenderer>().material;
        appear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void appear()
    {
        m.DOFloat(1, "Vector1_438D5A3F", speed);
    }
}
