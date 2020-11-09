using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerscore, combo;
    float distant;
    public bool s_click = false;
    public GameObject player;
    controller con;
    public ParticleSystem ps;
    void Start()
    {
        con = player.GetComponent<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "add_1" && s_click == true)
        {
            Vector3 p, o;            
            p = player.transform.position;
            o = other.transform.position;
             distant = (p - o).magnitude;
            cheack();
            Instantiate(ps, other.transform.position, Quaternion.Euler(new Vector3(0, 74, 0)));

            Destroy(other.gameObject);
        }
    }

    void cheack()
    {
        float i = Mathf.Abs(distant - 7.4f);
        if (i < 0.4 && i >= 0)
        {
            print("prefect" + i);
            combo++;
        }
        else if (i < 0.8 && i >= 0.4)
        {
            combo++;
            print("good" + i);
        }
        else if (i < 1.2 && i >= 0.8)
        {
            combo = 0;
            print("bad" + i);
        }
        else if (i >= 1.2)
        {
            combo = 0;
            print("miss" +i);
        }
    }
}
