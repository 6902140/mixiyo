using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Stage2 : MonoBehaviour
{
    float speed=10f;
    CameraSupport cameraSupport;
    GameObject player1;
    GameObject player2;
    private BoxCollider2D m_collider;
    void Start()
    {
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
        cameraSupport=Camera.main.GetComponent<CameraSupport>();
        m_collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name.Contains("Player")){
            Debug.Log("Hit Player");
            other.gameObject.GetComponent<Player>().Dead();
            Destroy(gameObject);
        }
    }
}