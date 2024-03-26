using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    float speed=10f;
    GameObject player1;
    GameObject player2;
    CameraSupport cameraSupport;
    void Start()
    {
        cameraSupport=Camera.main.GetComponent<CameraSupport>();
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
    }

    void Update()
    {
        if(player1.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(player2.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(Vector3.Distance(player1.transform.position,transform.position)<0.8f)
            player1.GetComponent<Player>().Hit();
        if(Vector3.Distance(player2.transform.position,transform.position)<0.8f)
            player2.GetComponent<Player>().Hit();
        transform.position += Time.smoothDeltaTime * speed * transform.up.normalized;
        Bounds myBound = GetComponent<Renderer>().bounds;
        CameraSupport.WorldBoundStatus status = cameraSupport.CollideWorldBound(myBound);
        if (status != CameraSupport.WorldBoundStatus.Inside)
            Destroy(gameObject);
    }
}
