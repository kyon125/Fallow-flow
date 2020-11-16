using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cine_change : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cine, cine2;
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
            StartCoroutine(wat());            
            other.GetComponent<S1_Basic>().Status = S1_Basic.playStatus.two;
        }        
    }
    IEnumerator wat()
    {
        yield return new WaitForSeconds(1.5f);
        cine2.SetActive(false);
    }
}
