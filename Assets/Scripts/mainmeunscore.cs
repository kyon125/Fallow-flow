using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmeunscore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text s1, s2, s3;
    void Start()
    {
        s1.text = "BEST SCORE:" + PlayerPrefs.GetInt("s1_Score");
        s2.text = "BEST SCORE:" + PlayerPrefs.GetInt("s2_Score");
        s3.text = "BEST SCORE:" + PlayerPrefs.GetInt("s3_Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
