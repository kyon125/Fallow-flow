using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addItem : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ad;
    public ParticleSystem PS ,PS2;
    public bool hasDoor;
    public List<GameObject> door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (hasDoor == true)
        {
            for (int i = 0; i < door.Count; i++)
            {
                door[i].GetComponent<thidTetrismove>().destoryAdditem++;
            }
            ad.Play();
            PS.Play();
            PS2.Play();
            Destroy(this.gameObject);
        }
        else if (hasDoor == false)
        {
            ad.Play();
            PS.Play();
            PS2.Play();
            Destroy(this.gameObject);
        }        
    }    
}
