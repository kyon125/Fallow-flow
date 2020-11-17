using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class load_sence : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p;
    public void back_menu()
    {
        StartCoroutine(play());
    }
    IEnumerator play()
    {
        Tween t = p.transform.DOMoveY(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Tween t2 = p.transform.DOMoveY(-0.19f, 0.4f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.4f);
        Tween t3 = p.transform.DOMoveX(10.85F, 0.5f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("mainmenu");
    }
}
