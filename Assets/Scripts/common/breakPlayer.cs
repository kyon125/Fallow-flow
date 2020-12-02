using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class breakPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isright;
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
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
                if (scene.name == "s1")
                {
                    hit.transform.GetComponent<playerController>().Status = playerController.playermove.death;
                    hit.transform.GetComponent<playerController>().forDeath();
                }
                else if (scene.name == "s2")
                {
                    hit.transform.GetComponent<playerControllerS2>().Status = playerControllerS2.playermove.death;
                    hit.transform.GetComponent<playerControllerS2>().forDeath();
                }                
            }
        }              
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isright == true)
        {
            if (collision.transform.name == "Player" && scene.name == "s1" && collision.transform.GetComponent<playerController>().Status == playerController.playermove.red2)
            {
                collision.transform.GetComponent<playerController>().Status = playerController.playermove.death;
                collision.transform.GetComponent<playerController>().forDeath();
            }
            else if (collision.transform.name == "Player" && scene.name == "s2" && collision.transform.GetComponent<playerControllerS2>().Status == playerControllerS2.playermove.red2)
            {
                collision.transform.GetComponent<playerControllerS2>().Status = playerControllerS2.playermove.death;
                collision.transform.GetComponent<playerControllerS2>().forDeath();
            }
            else if (collision.transform.name == "Player" && scene.name == "s3" && collision.transform.GetComponent<playerControllerS3>().Status == playerControllerS3.playermove.red2)
            {
                collision.transform.GetComponent<playerControllerS3>().Status = playerControllerS3.playermove.death;
                collision.transform.GetComponent<playerControllerS3>().forDeath();
            }
            else if (collision.transform.name == "3Dplayer" && scene.name == "s1" && collision.transform.GetComponent<playerController>().Status == playerController.playermove.red1)
            {                
                collision.transform.GetComponent<playerController>().Status = playerController.playermove.death;
                collision.transform.GetComponent<playerController>().forDeaththird();
            }
            else if (collision.transform.name == "3Dplayer" && scene.name == "s2" && collision.transform.GetComponent<playerControllerS2>().Status == playerControllerS2.playermove.red1)
            {
                collision.transform.GetComponent<playerControllerS2>().Status = playerControllerS2.playermove.death;
                collision.transform.GetComponent<playerControllerS2>().forDeaththird();
            }
            else if (collision.transform.name == "3Dplayer" && scene.name == "s3" && collision.transform.GetComponent<playerControllerS3>().Status == playerControllerS3.playermove.red1)
            {
                collision.transform.GetComponent<playerControllerS3>().Status = playerControllerS3.playermove.death;
                collision.transform.GetComponent<playerControllerS3>().forDeaththird();
            }
        }        
    }
}
