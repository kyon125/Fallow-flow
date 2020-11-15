using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showimage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image test;
    public List<orgian> btn;
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
        Tween t1 = btn[0].obj.DOAnchorPosX(3, 1.5F).SetEase(Ease.InBack);
        btn[0].obj.transform.SetSiblingIndex(btn[0].obj.parent.childCount - 1);
        // go & retrun's animation
        Tween t3 = btn[3].obj.DOAnchorPosX(-450, 1.5F).SetEase(Ease.InBack);
        Tween t4 = btn[4].obj.DOAnchorPosX(443, 1.5F).SetEase(Ease.InBack);
    }
    public void s2_click()
    {
        s_name = "s2";
        Tween t1 = btn[0].obj.DOAnchorPosX(-1149, 1.5F).SetEase(Ease.InOutBack);
        Tween t2 = btn[2].obj.DOAnchorPosX(1154, 1.5F).SetEase(Ease.InOutBack);
        // go & retrun's animation
        Tween t3 = btn[3].obj.DOAnchorPosX(-450, 1.5F).SetEase(Ease.InOutBack);
        Tween t4 = btn[4].obj.DOAnchorPosX(443, 1.5F).SetEase(Ease.InOutBack);
    }
    public void s3_click()
    {
        s_name = "s3";
        Tween t1 = btn[2].obj.DOAnchorPosX(-8, 1.5F).SetEase(Ease.InBack);
        btn[2].obj.transform.SetSiblingIndex(btn[2].obj.parent.childCount - 1);
        // go & retrun's animation
        Tween t3 = btn[3].obj.DOAnchorPosX(-450, 1.5F).SetEase(Ease.InBack);
        Tween t4 = btn[4].obj.DOAnchorPosX(443, 1.5F).SetEase(Ease.InBack);
    }
    public void retrun_click()
    {
        s_name = "";
        Tween t1 = btn[0].obj.DOAnchorPosX(btn[0].ts.x, 1.5F).SetEase(Ease.InOutQuad);
        Tween t2 = btn[1].obj.DOAnchorPosX(btn[1].ts.x, 1.5F).SetEase(Ease.InOutQuad);
        Tween t3 = btn[2].obj.DOAnchorPosX(btn[2].ts.x, 1.5F).SetEase(Ease.InOutQuad);
        // go & retrun's animation
        Tween t4 = btn[3].obj.DOAnchorPosX(btn[3].ts.x, 1.5F).SetEase(Ease.InOutQuad);
        Tween t5 = btn[4].obj.DOAnchorPosX(btn[4].ts.x, 1.5F).SetEase(Ease.InOutQuad);
    }
    public void go_click()
    {
        SceneManager.LoadScene(s_name);
    }
}
[System.Serializable]

public class orgian
{
    [SerializeField]    
    public RectTransform obj;
    public Vector2 ts;
}