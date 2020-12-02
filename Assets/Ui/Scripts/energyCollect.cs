using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyCollect : MonoBehaviour
{
    public EnergyBar energyBar;
    public static int currentEnergy = 0;

    public GameObject R;

    public Image rFill_c;
    public GameObject rFill;
    public EnergyLine energyLine;

    public GameObject rectTransform;

    int timer_i = 0;

    public static bool start_Timer1 = false;
    public static bool start_Timer2 = false;
    public static bool isEnergyMove = false;

    private bool moveSwitch1 = false;
    private bool moveSwitch2 = false;
    private void Start()
    {
        rFill_c.GetComponent<Renderer>();
    }

    private void Update()
    {

        energyBar.SetEnergy(currentEnergy);

        if (isEnergyMove)
        {
            StartCoroutine("energyMove");
        }

        if (start_Timer1)
        {
            moveSwitch1 = true;

            StartCoroutine("timer1");
            start_Timer1 = false;
            //Debug.Log(timer_i);
        }

        if (start_Timer2)
        {
            moveSwitch2 = true;

            StartCoroutine("timer2");
            start_Timer2 = false;
            //Debug.Log(timer_i);
        }

        print("Energy : "+currentEnergy);
    }

    // S1縮條
    IEnumerator timer1()
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        start_Timer1 = true;



        if (currentEnergy == 133)
        {
            rFill.SetActive(true);
        }

        if (currentEnergy > 0 && currentEnergy <= 133)
        {
            currentEnergy -= 25;

            if (currentEnergy < 0)
            {
                currentEnergy = 0;
                start_Timer1 = false;
            }

         //print("目前能量:" + currentEnergy);
        }


        if (energyBar.slider.value == 108)
        {
            R.transform.position += new Vector3(-103, 0, 0);

            energyLine.SetEnergy(2);
        }
        else if (energyBar.slider.value == 83)
        {
            R.transform.position += new Vector3(-103, 0, 0);

            energyLine.SetEnergy(1);
        }
        else if (energyBar.slider.value == 58)
        {
            R.transform.position += new Vector3(-103, 0, 0);

            energyLine.SetEnergy(0);
        }
        else if (energyBar.slider.value == 33)
        {
            R.transform.position += new Vector3(-103, 0, 0);
            start_Timer1 = false;
        }

        energyBar.SetEnergy(currentEnergy);
    }

    // S2縮條
    IEnumerator timer2()
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        start_Timer2 = true;

        if (currentEnergy == 72)
        {
            rFill.SetActive(true);
            rFill_c.color = Color.green;
        }  

        if (currentEnergy > 0 && currentEnergy <= 72)
        {
            currentEnergy -= 14;

            if (currentEnergy < 0)
            {
                currentEnergy = 0;
                start_Timer2 = false;

            }


            //print("目前能量:" + currentEnergy);
        }


        if (energyBar.slider.value == 58)
        {
            R.transform.position += new Vector3(-103, 0, 0);

            energyLine.SetEnergy(2);
        }
        else if (energyBar.slider.value == 44)
        {
            R.transform.position += new Vector3(-103, 0, 0);

            energyLine.SetEnergy(1);
        }
        else if (energyBar.slider.value == 30)
        {
            R.transform.position += new Vector3(-103, 0, 0);

            energyLine.SetEnergy(0);
        }
        else if (energyBar.slider.value == 16)
        {
            R.transform.position += new Vector3(-103, 0, 0);

        }

        energyBar.SetEnergy(currentEnergy);
    }

    IEnumerator energyMove()
    {
        yield return null;

        Vector2 aPos = rectTransform.transform.position;
        Vector2 aPosScale = rectTransform.transform.localScale;

        if (aPos.x >= 1489 && aPos.y >= 781 && moveSwitch1)
        {
            aPos += new Vector2(-37, -39.5f);
        }
        else if (aPos.x >= 1400 && aPos.y >= 770 && moveSwitch2)
        {
            aPos += new Vector2(-37, -39.5f);
        }
        else
        {
            isEnergyMove = false;
            start_Timer2 = false;
        }

        rectTransform.transform.position = aPos;
    }
}
