using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class tetrisFallS2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform T, S, Slice;
    public AudioSource s_red1, s_red2;
    public float Bpm, fallcount, smallSize, cineMovetime, waitstart;
    float beatime, timer, timer2, m_timer;
    int num, num2, beatcount, beatcount2;
    public playerControllerS2 player;
    public CinemachineVirtualCamera cine;
    public List<GameObject> tetris, mark;

    bool red2_Start, red2_musicplay;
    float orgialSize;



    private void Awake()
    {
        beatime = 1 / Bpm * 60;
        orgialSize = cine.m_Lens.OrthographicSize;
    }
    void Start()
    {
        Slice.DOMoveX(-4 * 0.19f, 0.5f);
        for (int I = 0; I <= T.childCount - 1; I++)
        {
            tetris.Add(T.GetChild(I).gameObject);
        }
        for (int I = 0; I <= S.childCount - 1; I++)
        {
            mark.Add(S.GetChild(I).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Status == playerControllerS2.playermove.red2 && red2_musicplay == false)
        {
            StartCoroutine(redplay(waitstart));
            red2_musicplay = true;
        }
        else if (player.Status == playerControllerS2.playermove.red2 && red2_musicplay == true)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= 10.5F)
            {
                red2_Start = true;
            }
        }
        if (red2_Start == true)
        {
            timer += Time.deltaTime;
            timer2 += Time.deltaTime;
            markshow();
            tetrisfall();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        player.Status = playerControllerS2.playermove.red2jump;
        DOTween.To(() => cine.m_Lens.OrthographicSize, x => cine.m_Lens.OrthographicSize = x, cine.m_Lens.OrthographicSize = orgialSize, 0.5f);
        StartCoroutine(jumpdown());
    }
    void tetrisfall()
    {
        if (timer >= beatime)
        {
            timer -= beatime;
            beatcount++;
            if (beatcount == fallcount)
            {
                if (num <= tetris.Count - 1)
                {
                    mark[num].SetActive(false);
                    tetris[num].SetActive(true);
                    num++;
                    beatcount = 0;
                }
            }
        }
    }

    void markshow()
    {
        if (timer2 >= beatime)
        {
            timer2 -= beatime;
            if (beatcount == 0)
            {
                if (num2 <= mark.Count - 1)
                {
                    mark[num2].SetActive(true);
                    if (num2 == 13)
                    {
                        DOTween.To(() => cine.m_Lens.OrthographicSize, x => cine.m_Lens.OrthographicSize = x, smallSize, cineMovetime);
                    }
                    else if (num2 == 17)
                    {
                        Slice.DOMoveX(4 * 0.3f, 0.1f);
                    }
                    num2++;
                }
            }
        }
    }
    IEnumerator jumpdown()
    {
        s_red2.Stop();
        yield return new WaitForSeconds(0.5f);
        player.transform.DOBlendableMoveBy(new Vector3(0, 0, -64), 1f).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(1f);
        cinemachineShake.cameraShake.goShake(7, 0.5f);
    }
    IEnumerator redplay(float wait)
    {
        yield return new WaitForSeconds(wait);
        s_red2.Play();
        m_timer = 0;
    }
}
