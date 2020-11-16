using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cine_change : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cine;
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
            cine.SetActive(false);
        }        
    }
}
