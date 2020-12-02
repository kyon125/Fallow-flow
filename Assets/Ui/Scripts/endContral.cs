using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endContral : MonoBehaviour
{
    int timer_i = 0;
    bool Life_Timer = true;
    public static bool endGame = false;
    public Text lifetext;

    public static float currentScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (endGame)
        {
            StartCoroutine("end");
        }

        if (!endGame)
        {
            if (Life_Timer)
            {

                StartCoroutine("timer1");
                Life_Timer = false;
                Debug.Log("Life time : " + timer_i);
            }
        }
       
              
        
    }

    IEnumerator timer1()
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        Life_Timer = true;
    }

    IEnumerator end()
    {
        yield return null;
        if (timer_i <= 60)
        {
            lifetext.text = timer_i + "";
        }
        else if (timer_i > 60)
        {
            int min, sec;

            sec = timer_i % 60;
            min = (int)(timer_i / 60);

            lifetext.text = min + ":" + sec;
        }

        scoreText.text = (int)currentScore + "";

        int i = PlayerPrefs.GetInt("s1_Score");
        if (i < (int)currentScore)
        {
            PlayerPrefs.SetInt("s1_Score", (int)currentScore);
        }
    }
}
