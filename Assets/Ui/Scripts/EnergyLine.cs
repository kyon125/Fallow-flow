using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyLine : MonoBehaviour
{
    public Slider slider;

    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = energy;
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;

    }

    public void SetResetEnergy(int energy)
    {
        slider.value = energy;

        
    }
}
