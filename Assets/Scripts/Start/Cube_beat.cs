using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube_beat : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 oldScale, newScale;
    public float Bpm , switchTime , rotatetime, beatcount;
    float time , posTime ,beatime , zoomtime , rotation ;
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
            beatcount++;
            time = time - beatime;            
        }
        if (beatcount >= switchTime)
        {
            transform.DORotate(new Vector3(0 , rotation +45 , 0) , beatime / 2 ).SetEase(Ease.OutExpo);
            rotation += 45;
            beatcount = 0;
        }
    } 
}
