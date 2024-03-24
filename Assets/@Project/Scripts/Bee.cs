using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    float speed=5f;
    bool orintation=false;
    CameraSupport cameraSupport;
    float init_time;
    GameObject player;
    Vector3 direction;
    float timer=0f;
    void Start()
    {
        player=GameObject.Find("Player");
        cameraSupport = Camera.main.GetComponent<CameraSupport>();
        direction = (player.transform.position - transform.position).normalized;
        init_time=Time.time;
    }
    void Update()
    {
        if(orintation)
            transform.position+=new Vector3(speed*Time.deltaTime,0f,0f);
        else
            transform.position-=new Vector3(speed*Time.deltaTime,0f,0f);
        Bounds myBound = GetComponent<Renderer>().bounds;
        CameraSupport.WorldBoundStatus status = cameraSupport.CollideWorldBound(myBound);
        if (status != CameraSupport.WorldBoundStatus.Inside)
            orintation=!orintation;
        if(Time.time-timer>1f)
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            bullet.transform.position=transform.position-new Vector3(0f,1f,0f);
            direction = (player.transform.position - transform.position).normalized;
            bullet.transform.rotation=Quaternion.LookRotation(Vector3.forward, direction);
            timer=Time.time;
        }
        if(Time.time-init_time>30f)
            Destroy(gameObject);
    }
}
