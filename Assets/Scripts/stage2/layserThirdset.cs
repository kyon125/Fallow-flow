using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class layserThirdset : MonoBehaviour
{
    // Start is called before the first frame update
    public laycolor lay;
    Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (scene.name == "s3")
            {
                if (other.GetComponent<playerControllerS3>().Status == playerControllerS3.playermove.red2)
                {
                    switch (lay)
                    {
                        case (laycolor.red):
                            {
                                if (other.GetComponent<playerControllerS3>().playecolor != playerControllerS3.Playecolor.red)
                                {
                                    print("dead");
                                    other.GetComponent<playerControllerS3>().forDeath();
                                }

                                break;
                            }
                        case (laycolor.green):
                            {
                                if (other.GetComponent<playerControllerS3>().playecolor != playerControllerS3.Playecolor.green)
                                {
                                    other.GetComponent<playerControllerS3>().forDeath();
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (lay)
                    {
                        case (laycolor.red):
                            {
                                if (other.GetComponent<playerControllerS3>().playecolor != playerControllerS3.Playecolor.red)
                                {
                                    print("dead");
                                    other.GetComponent<playerControllerS3>().forDeaththird();
                                }

                                break;
                            }
                        case (laycolor.green):
                            {
                                if (other.GetComponent<playerControllerS3>().playecolor != playerControllerS3.Playecolor.green)
                                {
                                    other.GetComponent<playerControllerS3>().forDeaththird();
                                }
                                break;
                            }
                    }
                }                
            }
            else if (scene.name == "s2")
            {
                switch (lay)
                {
                    case (laycolor.red):
                        {
                            if (other.GetComponent<playerControllerS2>().playecolor != playerControllerS2.Playecolor.red)
                            {
                                print("dead");
                                other.GetComponent<playerControllerS2>().forDeaththird();
                            }

                            break;
                        }
                    case (laycolor.green):
                        {
                            if (other.GetComponent<playerControllerS2>().playecolor != playerControllerS2.Playecolor.green)
                            {
                                other.GetComponent<playerControllerS2>().forDeaththird();
                            }
                            break;
                        }
                }
            }         
        }
    }
    public enum laycolor
    {
        red,
        green, 
        blue
    }
}
