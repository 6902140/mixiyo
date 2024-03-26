using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    float speed=5f;
    bool orintation=false;
    CameraSupport cameraSupport;
    float init_time;
    GameObject player1;
    GameObject player2;
    Vector3 direction;
    float timer=0f;
    void Start()
    {
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
        cameraSupport = Camera.main.GetComponent<CameraSupport>();
        if(Random.value>0.5)
            direction = (player1.transform.position - transform.position).normalized;
        else
            direction = (player2.transform.position - transform.position).normalized;
        init_time=Time.time;
    }
    void Update()
    {
        if(player1.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(player2.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(Vector3.Distance(player1.transform.position,transform.position)<1.3f)
            player1.GetComponent<Player>().Hit();
        if(Vector3.Distance(player2.transform.position,transform.position)<1.3f)
            player2.GetComponent<Player>().Hit();
        if(orintation)
            transform.position+=new Vector3(speed*Time.deltaTime,0f,0f);
        else
            transform.position-=new Vector3(speed*Time.deltaTime,0f,0f);
        Bounds myBound = GetComponent<Renderer>().bounds;
        CameraSupport.WorldBoundStatus status = cameraSupport.CollideWorldBound(myBound);
        if (status != CameraSupport.WorldBoundStatus.Inside)
            orintation=!orintation;
        if(Time.time-timer>0.5f)
        {
            GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            bullet.transform.position=transform.position-new Vector3(0f,1f,0f);
            if(Random.value>0.5)
                direction = (player1.transform.position - transform.position).normalized;
            else
                direction = (player2.transform.position - transform.position).normalized;
            bullet.transform.rotation=Quaternion.LookRotation(Vector3.forward, direction);
            timer=Time.time;
        }
        if(Time.time-init_time>15f)
            Destroy(gameObject);
    }
}
