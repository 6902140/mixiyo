using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    GameObject apple;
    GameObject orange;
    CameraSupport cameraSupport;
    float timerApple;
    float timerOrange;
    bool timerAppleBegin;
    bool timerOrangeBegin;

    private float timet = 3.0f;
    void Start()
    {
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
        cameraSupport=Camera.main.GetComponent<CameraSupport>();
        apple=Instantiate(Resources.Load("Prefabs/Apple") as GameObject);
        Vector3 pos=new Vector3();
        pos.x = cameraSupport.GetWorldBound().min.x + cameraSupport.GetWorldBound().size.x*0.1f+Random.value * cameraSupport.GetWorldBound().size.x*0.8f;
        pos.y = cameraSupport.GetWorldBound().min.y + cameraSupport.GetWorldBound().size.y*0.1f+Random.value * cameraSupport.GetWorldBound().size.y*0.4f;
        pos.z=0f;
        apple.transform.position=pos;
        orange=Instantiate(Resources.Load("Prefabs/Orange") as GameObject);
        pos.x = cameraSupport.GetWorldBound().min.x + cameraSupport.GetWorldBound().size.x*0.1f+Random.value * cameraSupport.GetWorldBound().size.x*0.8f;
        pos.y = cameraSupport.GetWorldBound().min.y + cameraSupport.GetWorldBound().size.y*0.1f+Random.value * cameraSupport.GetWorldBound().size.y*0.4f;
        orange.transform.position=pos;
        timerAppleBegin=false;
        timerOrangeBegin=false;
    }

    void Update()
    {
        if(player1.GetComponent<Player>().dead&&apple)
            Destroy(apple);
        if(player2.GetComponent<Player>().dead&&apple)
            Destroy(apple);
        if(!apple&&!timerAppleBegin)
        {
            timerAppleBegin=true;
            timerApple=Time.time;
        }
        if(!orange&&!timerOrangeBegin)
        {
            timerOrangeBegin=true;
            timerOrange=Time.time;
        }
        if(!apple&&Time.time-timerApple>timet&&timerAppleBegin)
        {
            apple=Instantiate(Resources.Load("Prefabs/Apple") as GameObject);
            Vector3 applePos=new Vector3();
            applePos.x = cameraSupport.GetWorldBound().min.x + cameraSupport.GetWorldBound().size.x*0.1f+Random.value * cameraSupport.GetWorldBound().size.x*0.8f;
            applePos.y = cameraSupport.GetWorldBound().min.y + cameraSupport.GetWorldBound().size.y*0.1f+Random.value * cameraSupport.GetWorldBound().size.y*0.4f;
            applePos.z=0f;
            apple.transform.position=applePos;
            timerAppleBegin=false;
        }
        if(!orange&&Time.time-timerOrange>timet&&timerOrangeBegin)
        {
            orange=Instantiate(Resources.Load("Prefabs/Orange") as GameObject);
            Vector3 orangePos=new Vector3();
            orangePos.x = cameraSupport.GetWorldBound().min.x + cameraSupport.GetWorldBound().size.x*0.1f+Random.value * cameraSupport.GetWorldBound().size.x*0.8f;
            orangePos.y = cameraSupport.GetWorldBound().min.y + cameraSupport.GetWorldBound().size.y*0.1f+Random.value * cameraSupport.GetWorldBound().size.y*0.4f;
            orangePos.z=0f;
            orange.transform.position=orangePos;
            timerOrange=Time.time;
            timerOrangeBegin=false;
        }
    }
}