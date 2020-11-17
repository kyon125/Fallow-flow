using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject red, blue;
    public VolumeProfile rp, bp;
    public Material M_red, M_blue, M_start;
    public status show;

    public Cinemachine.PostFX.CinemachineVolumeSettings cine;
    
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
        //RenderSettings.skybox = M_blue;
        cine.m_Profile = bp;
        red.SetActive(false);
        blue.SetActive(true);
    }
    void showred()
    {
        //RenderSettings.skybox = M_red;
        cine.m_Profile = rp;
        red.SetActive(true);
        blue.SetActive(false);
    }
    public enum status
    {
        showred,
        showblue
    }
}
