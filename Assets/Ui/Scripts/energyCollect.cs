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


    int timer_i = 0;

    public static bool start_Timer3 = false;

    private void Start()
    {
        rFill_c.GetComponent<Renderer>();
    }

    private void Update()
    {

        energyBar.SetEnergy(currentEnergy);

        if (start_Timer3)
        {
            StartCoroutine("timer3");
            start_Timer3 = false;
            Debug.Log(timer_i);
        }
    }

    IEnumerator timer3()
    {
        yield return new WaitForSeconds(1);
        timer_i++;
        start_Timer3 = true;

        energyBar.SetEnergy(currentEnergy);

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
                start_Timer3 = false;
            }


            print("目前能量:" + currentEnergy);
        }


        if (energyBar.slider.value == 108)
        {
            R.transform.position += new Vector3(-100, 0, 0);

            energyLine.SetEnergy(2);
        }
        else if (energyBar.slider.value == 83)
        {
            R.transform.position += new Vector3(-100, 0, 0);

            energyLine.SetEnergy(1);
        }
        else if (energyBar.slider.value == 58)
        {
            R.transform.position += new Vector3(-100, 0, 0);

            energyLine.SetEnergy(0);
        }
        else if (energyBar.slider.value == 33)
        {
            R.transform.position += new Vector3(-100, 0, 0);
        }
    }
}
