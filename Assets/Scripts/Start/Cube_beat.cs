using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Cube_beat : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 oldScale, newScale;
    public float Bpm, switchTime, rotatetime;
    [Header("字幕顏色")]
    public List<Color> textColor;
    [Header("背景顏色")]
    public Material m_background;
    public List<Color> backColor;
    [Header("方塊顏色")]
    public Material m_player;
    public List<Color> cubeColor;

    float time ,beatime , zoomtime , rotation;
    int changetime, beatcount;
    Text tile , context;
    MeshRenderer background, player;

    void Start()
    {
        tile = GameObject.Find("Tile").GetComponent<Text>();
        context = GameObject.Find("Context").GetComponent<Text>();
        background = GameObject.Find("Background").GetComponent<MeshRenderer>();
        player = GameObject.Find("Player").GetComponent<MeshRenderer>();
        change_color();

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
            changetime++;
            change_color();
        }
    }
    void change_color()
    {        
        tile.color = textColor[changetime];
        context.color = textColor[changetime];

        m_background.SetColor("_BaseColor" , backColor[changetime]);
        background.material = m_background;

        m_player.SetColor("_BaseColor", cubeColor[changetime]);
        player.material = m_player ;
        if (changetime == 4)
        {
            changetime = -1;
        }
    }
}
