using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_sence : MonoBehaviour
{
    // Start is called before the first frame update
    public void back_menu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
