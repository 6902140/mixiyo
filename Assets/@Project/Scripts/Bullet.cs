using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed=10f;
    CameraSupport cameraSupport;
    void Start()
    {
        cameraSupport=Camera.main.GetComponent<CameraSupport>();
    }

    void Update()
    {
        transform.position += Time.smoothDeltaTime * speed * transform.up.normalized;
        Bounds myBound = GetComponent<Renderer>().bounds;
        CameraSupport.WorldBoundStatus status = cameraSupport.CollideWorldBound(myBound);
        if (status != CameraSupport.WorldBoundStatus.Inside)
            Destroy(gameObject);
    }
}