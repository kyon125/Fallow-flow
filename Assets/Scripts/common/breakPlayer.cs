using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isright;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isright == false)
        {
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 2.4f, transform.position.z), Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 6f) && hit.transform.name == "Player")
            {
                hit.transform.GetComponent<playerController>().Status = playerController.playermove.death;
                hit.transform.GetComponent<playerController>().forDeath();
            }
        }              
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isright == true)
        {
            if (collision.transform.name == "Player")
            {
                collision.transform.GetComponent<playerController>().Status = playerController.playermove.death;
                collision.transform.GetComponent<playerController>().forDeath();
            }
        }
    }
}
