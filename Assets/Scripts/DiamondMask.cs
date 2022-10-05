using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMask : MonoBehaviour
{
    private float k = 0.448f ;//0.893f;
    private float p = 1.225f; //2.497f;
    private void Update() 
    {
        Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mpos.x = (int)(mpos.x / k) * k - 0.366f;
        mpos.y = (int)(mpos.y / p) *p + 0.012f;
        transform.position = mpos;
    }
}
