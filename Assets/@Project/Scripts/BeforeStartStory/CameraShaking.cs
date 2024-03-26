using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    public GameObject Camera = null;
    public float maxTime = 0.5f;
    public float maxD = 10f;
    Vector3 pos;
    Vector3 direction;
    float startTime;

    void OnEnable()
    {
        pos = Camera.transform.position;
        startTime = Time.time;
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        float dt;
        do
        {
            dt = Time.time - startTime;
            Debug.Log(dt);
            float dx = Mathf.Exp(-dt * 2.5f / maxTime) * Mathf.Sin(dt * 2f * (float)Math.PI * 5f / maxTime) * maxD;
            Vector3 npos = new(pos.x + dx, pos.y - dx, pos.z);
            Debug.Log(npos);

            Camera.transform.position = npos;

            yield return null;
        }while (dt < maxTime);
    }
}
