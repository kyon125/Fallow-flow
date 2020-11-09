using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class break_obscale : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Transform obj;
    public float power;
    public playercontroller player;
    public score sc;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        for (int i = 0; i < obj.childCount; i++)
        {
            Physics.IgnoreCollision(this.transform.GetComponent<Collider>(), obj.GetChild(i).GetComponent<Collider>(), true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" &&player.status == player_status.fronting)
        {
            rb.isKinematic = false;
            Physics.IgnoreCollision(this.transform.GetComponent<Collider>(), collision.transform.GetChild(0).GetComponent<Collider>(), true);
            rb.AddForce(transform.up * power);
            if (this.tag == "core")
            {
                sc.combo++;
            }            
        }
        if (collision.gameObject.tag == "Player" && player.status != player_status.fronting)
        {
            SceneManager.LoadScene("End");
        }
    }
}
