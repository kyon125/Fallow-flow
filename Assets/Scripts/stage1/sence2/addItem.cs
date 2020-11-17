using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addItem : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ad;
    public GameObject PS;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ad.Play();
        Instantiate(PS , transform.position , Quaternion.identity);
        Destroy(this.gameObject);
    }    
}
