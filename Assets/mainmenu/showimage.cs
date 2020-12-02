using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showimage : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ad;
    public Image test;
    public List<orgian> btn;
    public List<Transform> S;
    string s_name;
    void Start()
    {
        for (int i = 0; i < btn.Count; i++)
        {
            btn[i].ts = new Vector2(btn[i].obj.localPosition.x, btn[i].obj.localPosition.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click() 
    {
        print("hit");
    }
    public void s1_click()
    {
        
        s_name = "s1";
        Tween t1 = btn[0].obj.DOAnchorPosX(3, 0.5F).SetEase(Ease.InBack);
        btn[0].obj.transform.SetSiblingIndex(btn[0].obj.parent.childCount - 1);
        ad.Play();
        // go & retrun's animation
        Tween t3 = btn[3].obj.DOAnchorPosX(-450, 0.5F).SetEase(Ease.InBack);
        Tween t4 = btn[4].obj.DOAnchorPosX(443, 0.5F).SetEase(Ease.InBack);
        S[0].DOScaleX(1F , 0.5F).SetEase(Ease.InBack);
    }
    public void s2_click()
    {
        ad.Play();
        s_name = "s2";
        Tween t1 = btn[0].obj.DOAnchorPosX(-1149, 0.5F).SetEase(Ease.InOutBack);
        Tween t2 = btn[2].obj.DOAnchorPosX(1154, 0.5F).SetEase(Ease.InOutBack);
        // go & retrun's animation
        Tween t3 = btn[3].obj.DOAnchorPosX(-450, 0.5F).SetEase(Ease.InOutBack);
        Tween t4 = btn[4].obj.DOAnchorPosX(443, 0.5F).SetEase(Ease.InOutBack);
        S[1].DOScaleX(1F, 0.5F).SetEase(Ease.InBack);
    }
    public void s3_click()
    {
        ad.Play();
        s_name = "s3";
        Tween t1 = btn[2].obj.DOAnchorPosX(-8, 0.5F).SetEase(Ease.InBack);
        btn[2].obj.transform.SetSiblingIndex(btn[2].obj.parent.childCount - 1);
        // go & retrun's animation
        Tween t3 = btn[3].obj.DOAnchorPosX(-450, 0.5F).SetEase(Ease.InBack);
        Tween t4 = btn[4].obj.DOAnchorPosX(443, 0.5F).SetEase(Ease.InBack);
        S[2].DOScaleX(1F, 0.5F).SetEase(Ease.InBack);
    }
    public void retrun_click()
    {
        ad.Play();
        s_name = "";
        Tween t1 = btn[0].obj.DOAnchorPosX(btn[0].ts.x, 0.5F).SetEase(Ease.InOutQuad);
        Tween t2 = btn[1].obj.DOAnchorPosX(btn[1].ts.x, 0.5F).SetEase(Ease.InOutQuad);
        Tween t3 = btn[2].obj.DOAnchorPosX(btn[2].ts.x, 0.5F).SetEase(Ease.InOutQuad);
        // go & retrun's animation
        Tween t4 = btn[3].obj.DOAnchorPosX(btn[3].ts.x, 0.5F).SetEase(Ease.InOutQuad);
        Tween t5 = btn[4].obj.DOAnchorPosX(btn[4].ts.x, 0.5F).SetEase(Ease.InOutQuad);
        S[0].DOScaleX(0F, 0.5F).SetEase(Ease.InBack);
        S[1].DOScaleX(0F, 0.5F).SetEase(Ease.InBack);
        S[2].DOScaleX(0F, 0.5F).SetEase(Ease.InBack);
    }
    public void go_click()
    {
        ad.Play();
        SceneManager.LoadScene(s_name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
[System.Serializable]

public class orgian
{
    [SerializeField]    
    public RectTransform obj;
    public Vector2 ts;
}