using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeStage : MonoBehaviour
{
    // Start is called before the first frame update
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        print(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" &&  scene.name == "s1" )
        {
            print("aa");
            other.gameObject.GetComponent<playerController>().goTored2();
        }
        else if (other.gameObject.tag == "Player" && scene.name == "s2")
        {
            print("aa");
            other.gameObject.GetComponent<playerControllerS2>().goTored2();
        }
        else if (other.gameObject.tag == "Player" && scene.name == "s3")
        {
            print("aa");
            other.gameObject.GetComponent<playerControllerS2>().goTored2();
        }
    }
}
