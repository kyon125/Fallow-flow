using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject red, blue;
    public Material M_red, M_blue, M_start;
    public status show;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {        
        if(other.tag == "Player")
        {
            switch (show)
            {
                case status.showred:
                    {
                        showred();
                        break;
                    }
                case status.showblue:
                    {
                        showblue();
                        break;
                    }
            }
        }
        Destroy(this.gameObject);
    }
    void showblue()
    {
        RenderSettings.skybox = M_blue;
        red.SetActive(false);
        blue.SetActive(true);
    }
    void showred()
    {
        RenderSettings.skybox = M_red;
        red.SetActive(true);
        blue.SetActive(false);
    }
    public enum status
    {
        showred,
        showblue
    }
}
