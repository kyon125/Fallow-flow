using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layserThirdset : MonoBehaviour
{
    // Start is called before the first frame update
    public laycolor lay;
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
    public enum laycolor
    {
        red,
        green
    }
}
