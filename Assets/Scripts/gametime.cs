using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class gametime : MonoBehaviour
{
    public float time , roadlong, Timer;
    public AudioSource audio;  
    private float t;
    bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= Timer && start == true)
        {
            Tween t = transform.DOMoveX(roadlong, time).SetEase(Ease.Linear);
            audio.Play();
            start = false;
        }
        if (t > time + 5)
        {
            SceneManager.LoadScene("mainmenu");
        }
    }
}
