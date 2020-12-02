using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class simpleb : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 oldScale, newScale;
    public float Bpm;
    float beatime , time , zoomtime;
    
    void Start()
    {
        oldScale = transform.localScale;
        beatime = 1 / Bpm * 60;
        zoomtime = beatime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= beatime)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(this.transform.DOScale(newScale, zoomtime)).SetEase(Ease.InQuart);
            seq.Append(this.transform.DOScale(oldScale, zoomtime)).SetEase(Ease.OutBack);
            time = time - beatime;
        }
    }
}
