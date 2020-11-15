using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imagerange : Image
{
    // Start is called before the first frame update
    Collider2D range;
    void Start()
    {
        range = this.GetComponent<Collider2D>();
    }

    public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        return range.OverlapPoint(screenPoint);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
