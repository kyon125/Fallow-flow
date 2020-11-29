using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = energy;
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetResetEnergy(int energy)
    {
        slider.value = energy;

        fill.color = gradient.Evaluate(1f);
    }
}
