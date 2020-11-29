using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layserSet : MonoBehaviour
{
    // Start is called before the first frame update
    public playerControllerS2 player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("a");
        if (other.tag == "Player")
        {
            player.forDeath();
        }
    }
}
