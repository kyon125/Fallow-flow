using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyCollect : MonoBehaviour
{

    public EnergyBar energyBar;
    public static int currentEnergy;

    private void Update()
    {
        energyBar.SetEnergy(currentEnergy);
    }
}
