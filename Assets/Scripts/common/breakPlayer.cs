using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(new Vector3(transform.position.x ,transform.position.y+0.5f , transform.position.z) , Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f) && hit.transform.name == "Player")
        {
            hit.transform.GetComponent<playerController>().Status = playerController.playermove.death;
            hit.transform.GetComponent<playerController>().forDeath();
        }
    }
}
