using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float baseWidth = 1920;
    public float baseHeight = 1080;
    public float baseOrthographicSize = 5.49f;
    public Camera cam;

    void Awake()
    {

        cam.aspect = this.baseWidth / this.baseHeight;
    }
}
