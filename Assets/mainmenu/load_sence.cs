using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class load_sence : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject p;
    public AudioSource ad;
    public void back_menu()
    {
        StartCoroutine(play());
    }
    public void back_menu2()
    {
        StartCoroutine(end());
    }
    IEnumerator play()
    {
        ad.Play();
        Tween t = p.transform.DOMoveY(0.21f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Tween t2 = p.transform.DOMoveY(-1.24f, 0.4f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.4f);
        Tween t3 = p.transform.DOMoveX(10.85F, 0.5f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("mainmenu");
    }
    IEnumerator end()
    {
        ad.Play();
        yield return new WaitForSeconds(0.5f);       
        SceneManager.LoadScene("mainmenu");
    }
}
