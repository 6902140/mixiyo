using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float initialPosY;
    float startTime;
    private float boarder = 40f;
    private float freq = 900f;
    void Start()
    {
        initialPosY = transform.position.y;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float pastTime = Time.time - startTime;
        pos.y = initialPosY + Mathf.Sin(pastTime) * boarder;

        transform.position = pos;
    }
}
