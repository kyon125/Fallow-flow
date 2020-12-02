using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    // 外部參數
    private bool start_Timer3;
    private bool isEnergyMove;
    public GameObject energyObj;

    // Start is called before the first frame update
    void Start()
    {
        // 載入全域變數
        start_Timer3 = energyCollect.start_Timer3;
        isEnergyMove = energyCollect.isEnergyMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator energyShort()
    {
        start_Timer3 = true;
        energyCollect.start_Timer3 = start_Timer3;
        yield return new WaitForSeconds(4.8f);
        isEnergyMove = true;
        energyCollect.isEnergyMove = isEnergyMove;
        yield return new WaitForSeconds(0.5f);
        energyObj.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("energyShort");
        }
    }
}
