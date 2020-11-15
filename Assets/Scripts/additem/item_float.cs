using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class item_float : MonoBehaviour
{
    public float up, down, time ,e_time;
    bool ing = false;
    // Start is called before the first frame update
    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Append(this.transform.DOMoveY(down, time).SetEase(Ease.InBack));
        s.Append(this.transform.DOMoveY(up, time).SetEase(Ease.InBack));
        s.SetLoops(20);
    }

    // Update is called once per frame
    void Update()
    {        
        //StartCoroutine(wait());        
    }
    IEnumerator wait()
    {
        if (ing == false)
        {
            ing = true;
            yield return new WaitForSeconds(e_time);                  
            ing = false;
        }        
    }
}
