using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    enum States
    {
        Idle,
        Attack
    };
    GameObject chief;
    GameObject player1;
    GameObject player2;
    States state;
    void Start()
    {
        chief=GameObject.Find("Chief");
        player1=GameObject.Find("Player1");
        player2=GameObject.Find("Player2");
        state=States.Idle;
    }

    void Update()
    {
        if(player1.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(player2.GetComponent<Player>().dead)
            Destroy(gameObject);
        if(Vector3.Distance(player1.transform.position,transform.position)<0.9f)
            state=States.Attack;
        if(Vector3.Distance(player2.transform.position,transform.position)<0.9f)
            state=States.Attack;
        if(state==States.Idle)
            transform.Rotate(Vector3.forward, 300f * Time.smoothDeltaTime);
        else if(state==States.Attack)
        {
            if(Vector3.Distance(chief.transform.position,transform.position)<0.8f)
            {
                Destroy(gameObject);
                chief.GetComponent<Chief>().Hit();
            }
            transform.Rotate(Vector3.forward, 2000f * Time.smoothDeltaTime);
            Vector3 direction=(chief.transform.position-transform.position).normalized;
            transform.position += Time.smoothDeltaTime * 20f * direction;
        }
    }
}
